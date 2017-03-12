﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobStreet.Models
{
    public class Jobseeker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string  MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PermanentAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Nationality Nationality { get; set; }
    }
}