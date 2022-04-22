using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practice_4.Models;


namespace Practice_4.Controllers
{
    public class HomeController : Controller
    {
        Orders_and_customersContext db = new Orders_and_customersContext();
        static string str = "";
        static float x = 0;
        static string zn = "";
        static float rez = 0;

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            str = "";
            x = 0;
            zn = "";
            rez = 0;
            return View();
        }

        [HttpPost]
        public ActionResult Task2()
        {
            return View();
        }

		[HttpPost]
		public List<Customer> GetAllClients()
        {
			List<Customer> clients = new List<Customer>();
			foreach(Customer c in db.Customers)
			{
				Customer client = new Customer();
				client.Id = c.Id;
				client.Name = c.Name;
				client.Surname = c.Surname;
				client.Address = c.Address;
				clients.Add(client);
			}

			return clients;
		}

		[HttpPost]
        public ActionResult Calculator(string button, Calculator calc)
        {
			switch (button)
			{
				case "+":
					if (rez == 0 && zn == "") rez = x;
					else
					{
						if (zn == "-") rez -= x;
						if (zn == "+") rez += x;
						if (zn == "/")
						{
							if (x == 0)
							{
								str = "ERROR!";
								rez = 0;
								zn = "";
								x = 0;
								break;
							}
							else rez /= x;
						}
						if (zn == "*") rez *= x;
					}
					x = 0;
					zn = "+";
					str = rez + "+";
					break;

				case "-":
					if (rez == 0 && zn == "") rez = x;
					else
					{
						if (zn == "-") rez -= x;
						if (zn == "+") rez += x;
						if (zn == "/")
						{
							if (x == 0)
							{
								str = "ERROR!";
								rez = 0;
								zn = "";
								x = 0;
								break;
							}
							else rez /= x;
						}
						if (zn == "*") rez *= x;
					}
					str = rez + "-";
					zn = "-";
					x = 0;
					break;

				case "*":
					if (rez == 0 && zn == "") rez = x;
					else
					{
						if (zn == "-") rez -= x;
						if (zn == "+") rez += x;
						if (zn == "/")
						{
							if (x == 0)
							{
								str = "ERROR!";
								rez = 0;
								zn = "";
								x = 0;
								break;
							}
							else rez /= x;
						}
						if (zn == "*") rez *= x;
					}
					str = rez + "*";
					x = 0;
					zn = "*";
					break;

				case "/":
					if (rez == 0 && zn == "") rez = x;
					else
					{
						if (zn == "-") rez -= x;
						if (zn == "+") rez += x;
						if (zn == "/")
						{
							if (x == 0)
							{
								str = "ERROR!";
								rez = 0;
								zn = "";
								x = 0;
								break;
							}
							else rez /= x;
						}
						if (zn == "*") rez *= x;
					}
					str = rez + "/";
					x = 0;
					zn = "/";
					break;

				case "C":
					str = " ";
					zn = "";
					rez = 0;
					x = 0;
					break;

				case "=":
					if (zn == "-") rez -= x;
					if (zn == "+") rez += x;
					if (zn == "/")
					{
						if (x == 0)
						{
							str = "ERROR!";
							rez = 0;
							zn = "";
							x = 0;
							break;
						}
						else rez /= x;
					}
					if (zn == "*") rez *= x;
					if (rez != 0) str = rez + "";
					else str = "0";
					rez = 0;
					zn = "";
					x = 0;
					break;

				default:
					x = x * 10 + int.Parse(button);
					if (rez != 0)
						str = rez + " " + zn + " " + x;
					else str = zn + x;
					break;
			}
			calc.CalculatorString = str;            
            ViewBag.Calculator = str;
            return View("Index", calc);
        }    }
}