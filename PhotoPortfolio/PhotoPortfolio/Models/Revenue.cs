using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoPortfolio.Models
{
    public class Revenue
    {

        public int ID { get; set; }
        public double? Total { get; set; }
        public DateTime Date { get; set; }

        public string RegisteredUserID { get; set; }
        public virtual RegisteredUser RegisteredUser { get; set; }
        public int RevenueCategoryID { get; set; }
        public virtual RevenueCategory RevenueCategory { get; set; }

    }
}