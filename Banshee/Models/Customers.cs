using System;
using System.ComponentModel.DataAnnotations;

namespace Banshee.Models
{
    public class Customers
    {
        [Key]
        public int ClientID { get; set; }
        public string Nit { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int CityID { get; set; }
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public int CreditLimit { get; set; }
        public int AvailableCredit { get; set; }
        public int VisitPercentage { get; set; }

        public Customers()
        {

        }
    }
}
