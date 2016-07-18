using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Travel.Models
{
    public class TravelUser : IdentityUser
    {
        public DateTime FirstTrip { get; set; }

    }
}