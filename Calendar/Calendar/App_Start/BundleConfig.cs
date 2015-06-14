using System.Web.Optimization;

namespace Calendar
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                        "~/Scripts/libs/jquery/jquery-{version}.js",
                        "~/Scripts/libs/jquery/jquery.validate*",
                        "~/Scripts/libs/bootstrap.js",
                        "~/Scripts/libs/angular.js",
                        "~/Scripts/libs/underscore.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Scripts/plugins/jquery.calendario.js",
                        "~/Scripts/plugins/ui-bootstrap-tpls-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/modules/homePageApp.js",
                        "~/Scripts/modules/eventApp.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/events.css"));

            bundles.Add(new StyleBundle("~/Content/css/calendar").Include(
                        "~/Content/calendar.css",
                      "~/Content/custom_calendar.css"));
        }
    }
}
