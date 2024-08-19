
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
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = Enumerable.Range(1, 50).Select(i => new Invoice
            {
                OrderID = i,
                CustomerName = "Customer" + i,
                OrderDate = new DateTime(2016, 9, 15).AddDays(i % 7),
                ProductName = "Product " + i,
                UnitPrice = i * 10,
                Quantity = Convert.ToInt16(i),
                Salesperson= "Salesperson" + i
            });

            var dsResult = result.ToDataSourceResult(request);
            return Json(dsResult);
        }

    }
}

