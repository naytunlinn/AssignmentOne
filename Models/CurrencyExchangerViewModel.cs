using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentOne.Models
{
    public class CurrencyExchangerViewModel
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal Amount { get; set; }

    }
}