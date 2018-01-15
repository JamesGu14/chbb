using System.Web;
using System.Web.Optimization;

namespace CHBB.WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // Home page css bundle
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/animate.css",
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/flaticon.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/hover.css",
                      "~/Content/css/jquery.fancybox.css",
                      "~/Content/css/owl.css",
                      "~/Content/css/responsive.css",
                      "~/Content/css/style.css"));

            // Home page revolution slider bundle
            bundles.Add(new ScriptBundle("~/bundles/slider-js").Include(
                      "~/Content/plugins/revolution/js/jquery.themepunch.revolution.min.js",
                      "~/Content/plugins/revolution/js/jquery.themepunch.tools.min.js",
                      "~/Content/plugins/revolution/js/extensions/revolution.extension.actions.min.js",
                      "~/Content/plugins/revolution/js/extensions/revolution.extension.carousel.min.js",
                      "~/Content/plugins/revolution/js/extensions/revolution.extension.kenburn.min.js",
                      "~/Content/plugins/revolution/js/extensions/revolution.extension.layeranimation.min.js",
                      "~/Content/plugins/revolution/js/extensions/revolution.extension.migration.min.js",
                      "~/Content/plugins/revolution/js/extensions/revolution.extension.navigation.min.js",
                      "~/Content/plugins/revolution/js/extensions/revolution.extension.parallax.min.js",
                      "~/Content/plugins/revolution/js/extensions/revolution.extension.slideanims.min.js",
                      "~/Content/plugins/revolution/js/extensions/revolution.extension.video.min.js",
                      "~/Content/js/main-slider-script.js"));
        }
    }
}
