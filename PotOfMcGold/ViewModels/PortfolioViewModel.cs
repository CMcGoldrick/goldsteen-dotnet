using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PotOfMcGold.Models;

namespace PotOfMcGold.ViewModels
{
	public class PortfolioViewModel
	{
        //public IndexClass Crypto { get; set; }
        public IEnumerable<IndexClass> Crypto { get; set; }
        public Portfolio Portfolio { get; set; }
    }
}