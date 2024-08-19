using KendoQsBoilerplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

public class HomeController : Controller
    {
        private readonly NorthwindDBContext db = new NorthwindDBContext();
        public ActionResult Index()
        {
            return View();
        }

        #region Quick Start Primer
        // These methods were added to assist with the quickstart guide.
        private IEnumerable<MonthlySalesByEmployeeViewModel> EmployeeAverageSalesQuery(int employeeId, DateTime statsFrom, DateTime statsTo)
        {
            return (from allSales in
                               (from o in db.Orders
                                join od in db.Order_Details on o.OrderID equals od.OrderID
                                where o.EmployeeID == employeeId && o.OrderDate >= statsFrom && o.OrderDate <= statsTo
                                select new
                                {
                                    EmployeeID = o.EmployeeID,
                                    Date = o.OrderDate,
                                    Sales = od.Quantity * od.UnitPrice
                                }
                                   ).ToList()
                    group allSales by new DateTime(allSales.Date.Value.Year, allSales.Date.Value.Month, 1) into g
                    select new MonthlySalesByEmployeeViewModel
                    {
                        EmployeeID = g.FirstOrDefault().EmployeeID,
                        EmployeeSales = g.Sum(x => x.Sales),
                        Date = g.Key,
                    }
            );
        }

        private IEnumerable<QuarterToDateSalesViewModel> EmployeeQuarterSalesQuery(int employeeId, DateTime statsTo, DateTime startDate)
        {
            var sales = db.Orders.Where(w => w.EmployeeID == employeeId)
                .Join(db.Order_Details, orders => orders.OrderID, orderDetails => orderDetails.OrderID, (orders, orderDetails) => new { Order = orders, OrderDetails = orderDetails })
                .Where(d => d.Order.OrderDate >= startDate && d.Order.OrderDate <= statsTo).ToList()
                .Select(o => new QuarterToDateSalesViewModel
                {
                    Current = (o.OrderDetails.Quantity * o.OrderDetails.UnitPrice) - (o.OrderDetails.Quantity * o.OrderDetails.UnitPrice * (decimal)o.OrderDetails.Discount)
                });
            //TODO: Generate the target based on team's average sales
            return new List<QuarterToDateSalesViewModel>() {
                     new QuarterToDateSalesViewModel {Current = sales.Sum(s=>s.Current), Target = 15000, OrderDate = statsTo}
            };
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        #endregion
    }