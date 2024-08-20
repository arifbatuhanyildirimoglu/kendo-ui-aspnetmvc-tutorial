
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using KendoQsBoilerplate;

namespace Telerik.Scaffolders.Controllers
{
	public class InvoiceController : Controller
	{
		private readonly NorthwindDBContext db = new NorthwindDBContext();

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Read([DataSourceRequest] DataSourceRequest request, string salesPerson, DateTime statsFrom, DateTime statsTo)
		{
			var invoices = db.Invoices.Where(inv => inv.Salesperson == salesPerson).Where(inv => inv.OrderDate >= statsFrom && inv.OrderDate <= statsTo);
			DataSourceResult result = invoices.ToDataSourceResult(request, invoice => new {
				OrderID = invoice.OrderID,
				CustomerName = invoice.CustomerName,
				OrderDate = invoice.OrderDate,
				ProductName = invoice.ProductName,
				UnitPrice = invoice.UnitPrice,
				Quantity = invoice.Quantity,
				Salesperson = invoice.Salesperson
			});

			return Json(result);
		}

	}
}

