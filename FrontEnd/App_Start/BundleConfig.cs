using System.Web.Optimization;

namespace FrontEnd
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/assets/jquery").Include(
                      "~/assets/jquery/jquery.min.js",
                      "~/assets/bootstrap3/js/bootstrap.min.js"));

            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/themes/base/jquery-ui.css"));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-1.10.2.min.js",
                "~/Scripts/jquery-ui-1.10.0.min.js"
                ));

            // The Kendo JavaScript bundle
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                    "~/Scripts/kendo/kendo.all.min.js",
                    "~/Scripts/kendo/kendo.aspnetmvc.min.js"));

            // The Kendo CSS bundle
            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
                    "~/Content/kendo/kendo.common.min.css",
                    "~/Content/kendo/kendo.default.min.css",
                    "~/Content/kendo/kendo.rtl.min.css",
                    "~/Content/kendo/kendo.dataviz.min.css",
                    "~/Content/kendo/Kendo.custom.css"));

            bundles.IgnoreList.Clear();
        }
    }
}



