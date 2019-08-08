using System;
//using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PotOfMcGold.Models
{
    public class Investment
    {
        public int Id { get; set; }
        //public int UserId { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        
        public DateTime Date { get; set; }

        public float? Volume { get; set; }

        public string Exchange { get; set; }
        public string Notes { get; set; }
    }
}

