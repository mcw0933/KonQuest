using System.Web;
using System.Web.Optimization;

namespace KonTwo
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // http://erraticdev.blogspot.ie/2010/12/sending-complex-json-objects-to-aspnet.html
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.*", "~/Scripts/toDictionary.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// use this BundleConfig OR add the 3 lines below to your existing BundleConfig.cs and delete this file.
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // http://www.seankilleen.com/2012/12/how-to-quickly-update-mvc4-project-with.html
            //var css = new StyleBundle("~/Content/css").Include("~/Content/site.less");
            var css = new StyleBundle("~/Content/css").Include("~/Content/site.less", "~/Content/font-awesome.css");
            css.Transforms.Add(new LessMinify());
            bundles.Add(css);  

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}