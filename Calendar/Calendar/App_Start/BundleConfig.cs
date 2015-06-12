using System.Web.Optimization;

namespace Calendar
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                        "~/Scripts/libs/jquery/jquery-{version}.js",
                        "~/Scripts/libs/jquery/jquery.validate*",
                        "~/Scripts/libs/bootstrap.js",
                        "~/Scripts/libs/angular.js.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Scripts/plugins/jquery.calendario.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/calendar.css",
                      "~/Content/custom_calendar.css"));
        }
    }
}
