using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WolfGamesProjectSite.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public DateTime DttmCreated { get; set; }
        public DateTime DttmUpdated { get; set; }
        public DateTime BirthDay { get; set; }
        public long Score { get; set; }
    }
}