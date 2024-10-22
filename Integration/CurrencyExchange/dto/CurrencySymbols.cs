using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace urban_leo.Integration.CurrencyExchange.dto
{
    public class CurrencySymbols
    {
        public bool success { get; set; }
        public Dictionary<string, string> Symbols { get; set; }

    }

}