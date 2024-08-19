
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Scaffolders.Models.Grid;
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

        public ActionResult Create([DataSourceRequest] DataSourceRequest request, Invoice model)
        {
            if (model != null && ModelState.IsValid)
            {
                // service.Create(model); //save to DB
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Update([DataSourceRequest] DataSourceRequest request, Invoice model)
        {
            if (model != null && ModelState.IsValid)
            {
                // service.Update(model); //update model to DB
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, Invoice model)
        {
            if (model != null && ModelState.IsValid)
            {
                // service.Delete(model); //delete from DB
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

    }
}

