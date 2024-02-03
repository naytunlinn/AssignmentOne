using AssignmentOne.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentOne.Controllers
{
    public class AssignmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CurrencyExchanger()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CurrencyExchanger(CurrencyExchangerViewModel currency)
        {

            List<string> errors = new List<string>();
            if (string.IsNullOrEmpty(currency.FromCurrency) || string.IsNullOrEmpty(currency.ToCurrency))
            {
                errors.Add("please select a currency");
            }
            if (currency.Amount <= 0)
            {
                errors.Add("invalid amount");
            }
            if (errors != null)
            {
                ViewBag.Errors = errors;
               // return View();
            }
      

            decimal result = 0;

            decimal fromValue = 0;
            //base on Myanmar Kayt
            decimal MMK = 1;
            decimal USD = 3000;
            decimal TBH = 100;
            decimal SGD = 1500;

            switch (currency.FromCurrency)
            {
                case "USD": fromValue = USD; break;
                case "SGD": fromValue = SGD; break;
                case "TBH": fromValue = TBH; break;
                case "MMK": fromValue = MMK; break;
            }
            switch (currency.ToCurrency)
            {
                case "USD": result = (fromValue * currency.Amount) / USD; break;
                case "SGD": result = (fromValue * currency.Amount) / SGD; break;
                case "TBH": result = (fromValue * currency.Amount) / TBH; break;
                case "MMK": result = (fromValue * currency.Amount) / MMK; break;
            }
            //string Result = $"{result} {Unit}";
            // string Result = result;

            return Json(result);
        }
        public IActionResult FormRegister()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FormRegister(string name,string email, string password,string coPassword)
            {
            if (password == coPassword)
            {
                ViewBag.Result = " Successfully Created - " + name + " " + email;
            }
            else
            {
                ViewBag.Result = "Check Your Password, must be same";
            }
            return View();
        }

        public IActionResult IncomeTaxCalculator()
        {
            return View();
        }
        [HttpPost]
        public IActionResult IncomeTaxCalculator(decimal Salary, int NoOfChildren, bool IsFather = false, bool IsMother = false)
        {
            ViewBag.Salary=Salary;
            ViewBag.IsFather=IsFather;
            ViewBag.IsMother=IsMother;
            ViewBag.NoOfChildren=NoOfChildren;
            decimal tax = 0;
            decimal deduction = 0;
            if(Salary >= 500000) {
                tax = Salary / 10;
            }
            if (IsFather)
            {
                deduction += 50000;
            }
            if (IsMother)
            {
                deduction += 50000;
            }
            if(NoOfChildren > 0)
            {
                deduction += NoOfChildren * 30000;
            }

            decimal result = (tax * 12) - deduction;
            ViewBag.Result=result;
            ViewBag.Tax = tax;

            return View();
        }
    }
}