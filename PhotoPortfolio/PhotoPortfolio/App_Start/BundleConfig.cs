using System.Web;
using System.Web.Optimization;

namespace PhotoPortfolio
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/Chart").Include("~/Scripts/Chart.js"));

            bundles.Add(new ScriptBundle("~/bundles/Stellar").Include("~/Scripts/jquery.stellar.js"));

            //bundles.Add(new ScriptBundle("~/bundles/core").Include("~/Scripts/jquery.ui.core.js"));

            //bundles.Add(new ScriptBundle("~/bundles/widget").Include("~/Scripts/jquery.ui.widget.js"));

            //bundles.Add(new ScriptBundle("~/bundles/datepicker").Include("~/Scripts/jquery.ui.datepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/dropzonescripts").Include("~/Scripts/dropzone/dropzone.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/dropzonecss").Include("~/Scripts/dropzone/basic.css", "~/Scripts/dropzone/dropzone.css"));

        }
    }
}
