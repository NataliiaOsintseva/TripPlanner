using AutoMapper;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Travel.Models;
using Travel.ViewModels;

namespace Travel.Controllers.Api
{
    [Authorize]
    [Route("api/trips")]
    public class TripController : Controller
    {
        private ILogger<TripController> _logger;
        private ITravelRepository _repository;

        public TripController(ITravelRepository repository, ILogger<TripController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var trips = _repository.GetUserTripsWithStops(User.Identity.Name);
            var results = Mapper.Map<IEnumerable<TripViewModel>>(trips);
            return Json(results);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]TripViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newTrip = Mapper.Map<Trip>(vm);
                    newTrip.UserName = User.Identity.Name;

                    // Save to the DB
                    _logger.LogInformation("Attempting to save trip");
                    _repository.AddTrip(newTrip);

                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<TripViewModel>(newTrip));
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Failed to save a trip", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = "Failed", ModelState = ModelState });

          }
    
    }
}
