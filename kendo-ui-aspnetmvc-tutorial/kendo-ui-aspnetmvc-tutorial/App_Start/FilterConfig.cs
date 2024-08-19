using System.Web;
using System.Web.Mvc;

namespace kendo_ui_aspnetmvc_tutorial
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
