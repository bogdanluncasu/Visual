//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeststingDotNet.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Room
    {
        public Room()
        {
            this.Bookings = new HashSet<Booking>();
        }
    
        public int Id { get; set; }
        public bool Reserved { get; set; }
        public bool SeaSide { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public bool Meniu { get; set; }
        public double Pricemeniu { get; set; }
        public int Persons { get; set; }
    
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
