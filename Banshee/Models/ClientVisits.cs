﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Banshee.Models
{
    public class ClientVisits
    {
        [Key]
        public int VisitID {get; set;}
        public DateTime Date { get; set; }
        public int SalesRepresentativeID { get; set; }
        public int Net { get; set; }
        public int TotalVisit { get; set; }
        public int ClientID { get; set; }

        public ClientVisits()
        {
        }
    }
}
