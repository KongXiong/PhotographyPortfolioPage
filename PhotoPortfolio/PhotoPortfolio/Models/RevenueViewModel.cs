using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PhotoPortfolio.Models
{
    public class RevenueViewModel
    {
        [DisplayName("Client")]
        public Client Client { get; set; }
        public double? Total { get; set; }
        public DateTime Date { get; set; }
        public RevenueCategory RevenueCategory { get; set; }

    }
}