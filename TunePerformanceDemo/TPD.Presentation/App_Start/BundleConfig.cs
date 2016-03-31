using System.Web;
using System.Web.Optimization;

namespace TPD.Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            var jqueryBundle = new ScriptBundle("~/bundles/jquery", "//code.jquery.com/jquery-1.10.2.min.js").Include(
                "~/Scripts/jquery-{version}.js");
            jqueryBundle.CdnFallbackExpression = "window.jquery";
            bundles.Add(jqueryBundle);

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            var myStyles = new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/generalspeaker.css",
                      "~/Content/schedulecard.css",
                      "~/Content/topspeaker.css");
            //myStyles.Transforms.Add(new CssMinify());
            bundles.Add(myStyles);

            var myScripts = new ScriptBundle("~/bundles/myscripts").Include(
                      "~/Scripts/demo/script1.js",
                      "~/Scripts/demo/script2.js",
                      "~/Scripts/demo/script3.js",
                      "~/Scripts/lazyload.js");
            //myScripts.Transforms.Add(new JsMinify());
            bundles.Add(myScripts);
        }
    }
}
