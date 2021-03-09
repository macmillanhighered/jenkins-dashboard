using System.Web;
using System.Web.Optimization;

namespace Amideploy2._0
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                        "~/Scripts/jquery-{version}.min.js",
                        "~/Scripts/bundlescripts/bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/btdt").Include(
                     "~/Content/bundlecss/bootstrap.min.css",
                     "~/Content/bundlecss/bootstrap-select.css",
                     "~/Content/bundlecss/dataTables.bootstrap.min.css",
                     "~/Content/bundlecss/responsive.bootstrap.min.css"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/btdt").Include(
                     "~/Scripts/jquery-{version}.min.js",
                     "~/Scripts/bundlescripts/bootstrap.bundle.min.js",
                     "~/Scripts/bundlescripts/bootstrap-select.min.js",
                     "~/Scripts/bundlescripts/jquery.dataTables.min.js",
                     "~/Scripts/bundlescripts/dataTables.bootstrap4.min.js"                     
                     ));
        }
    }
}
