using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystemUsingLinq
{
    public class Contact
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public double phoneNumber { get; set; }
        public int zipCode { get; set; }
        public string emailId { get; set; }
    }
}
