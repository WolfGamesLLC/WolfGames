using System;

namespace WolfGamesSite.DAL
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