using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using mftracker_ws.Model.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace mftracker_ws.Model
{
    [Table("mutualfunds")]
    public class Scheme : IScheme
    {
        [Column("mf_id")]
        public int SchemeID { get; set; }

        [Column("amc_id")]
        public int AmcID { get; set; }

        [Column("mf_scheme_name")]
        public string SchemeName { get; set; }

        [Column("mf_isin")]
        public string SchemeISIN { get; set; }

        [Column("mf_scheme_code")]
        public string SchemeCode { get; set; }

        [Column("mf_scheme_type")]
        public string SchemeType { get; set; }

        //public Amc Amc { get; set; }

        //public List<Nav> Navs { get; set; }
    }
}
