using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFirstBotApplication.Domain.Models
{
    public class Reservation
    {
        [Key]
        public Guid Id { get; set; }
        public Campsite Campsite {get; set;}
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartueDate { get; set; }
    }
}