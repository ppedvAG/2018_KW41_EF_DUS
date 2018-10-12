using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.ElenasUwe.Model.Exceptions
{
    public class MyConcurrencyException : Exception
    {
        public Action UserWins { get; set; }
        public Action DbWins { get; set; }
    }
}
