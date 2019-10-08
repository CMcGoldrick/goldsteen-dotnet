using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PotOfMcGold.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        //public int UserId { get; set; }
        public string Name { get; set; }
        public float Volume { get; set; }
        public string Notes { get; set; }
        public int CurrentValue { get; set; }

    }
}
