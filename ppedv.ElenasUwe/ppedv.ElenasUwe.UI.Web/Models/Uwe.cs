using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ppedv.ElenasUwe.UI.Web.Models
{
    public class Uwe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime GebDatum { get; set; }
        public decimal Preis { get; set; }
    }
}