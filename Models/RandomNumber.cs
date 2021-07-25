using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Models
{
    public class RandomNumber
    {

        public RandomNumber(double randomNumb)
        {
            RandomNumb = randomNumb;
        }

        public int Id { get; set; }
        public double RandomNumb { get; set; }

    }
}