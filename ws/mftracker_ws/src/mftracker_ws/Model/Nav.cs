using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using mftracker_ws.Model.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace mftracker_ws.Model
{
    [Table("Nav")]
    public class Nav : INav
    {
        [Column("nav_id")]
        public int NavID { get; set; }

        [Column("mf_id")]
        public int SchemeID { get; set; }

        [Column("nav_date")]
        public DateTime NavDate { get; set; }

        [Column("nav")]
        public double NavValue { get; set; }

        [Column("nav_repurchase")]
        public double NavRepurchase { get; set; }

        [Column("nav_sales_price")]
        public double NavSale { get; set; }

        public Scheme Scheme { get; set; } 
    }
}
