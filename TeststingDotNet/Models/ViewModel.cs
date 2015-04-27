using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeststingDotNet.Models
{
    public class ViewModel
    {
        public IEnumerable<Room> Room { get; set; }
        public IEnumerable<Booking> Booking { get; set; }
    }
}