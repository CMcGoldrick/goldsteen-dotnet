using System.Web;
using System.Web.Optimization;

namespace PotOfMcGold
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/custom-scripts").Include(
                        "~/Scripts/Site.js"
                ));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            var googleFont = "https://fonts.googleapis.com/css?family=Kanit&display=swap";
                       
            bundles.Add(new StyleBundle("~/Content/css", googleFont).Include(
                //"~/Content/font-awesome.min.css",
                "~/Content/bootstrap.css",
                "~/Content/site.css",
                "~/Content/cryptos-page.css"
                ));
        }
    }
}
