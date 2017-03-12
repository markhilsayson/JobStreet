using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobStreet.Models;

namespace JobStreet.ViewModels
{
    public class JobseekerViewModel
    {
        public IEnumerable<Nationality> Nationalities { get; set; } 
        public Jobseeker Jobseeker { get; set; }
    }
}