using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Models.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
        
    }
}