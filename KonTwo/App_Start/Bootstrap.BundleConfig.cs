using System.Web;
using System.Web.Optimization;

namespace KonTwo
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;   //enable CDN support

            // https://developers.google.com/speed/libraries/devguide
            var jQueryCDN = "//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js";
            var jQueryUICDN = "//ajax.googleapis.com/ajax/libs/jqueryui/1.10.2/jquery-ui.min.js";
            var jQueryUICSSCDN = "//ajax.googleapis.com/ajax/libs/jqueryui/1.10.2/themes/ui-lightness";

            bundles.Add(new ScriptBundle("~/bundles/jquery", jQueryCDN).Include(
                        "~/Scripts/jquery-{version}.js", "~/Scripts/toDictionary.js"));
            // http://erraticdev.blogspot.ie/2010/12/sending-complex-json-objects-to-aspnet.html
            
            bundles.Add(new ScriptBundle("~/bundles/jqueryui", jQueryUICDN).Include(
                        "~/Scripts/jquery-ui*"));

            // http://cdnjs.com

            var jQueryValCDN = "//cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.11.0/jquery.validate.min.js";
            var modernizrCDN = "//cdnjs.cloudflare.com/ajax/libs/modernizr/2.6.2/modernizr.min.js";
            
            var fontAwesomeCDN = "//cdnjs.cloudflare.com/ajax/libs/font-awesome/3.0.2/css/font-awesome.min.css";

            bundles.Add(new ScriptBundle("~/bundles/jqueryval", jQueryValCDN).Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr", modernizrCDN).Include(
                        "~/Scripts/modernizr-*"));

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// use this BundleConfig OR add the 3 lines below to your existing BundleConfig.cs and delete this file.
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // http://www.seankilleen.com/2012/12/how-to-quickly-update-mvc4-project-with.html
            //var css = new StyleBundle("~/Content/css").Include("~/Content/site.less");
            var css = new StyleBundle("~/Content/css", fontAwesomeCDN).Include("~/Content/site.less", "~/Content/font-awesome.css");
            css.Transforms.Add(new LessMinify());
            bundles.Add(css);

            bundles.Add(new StyleBundle("~/Content/themes/base/css", jQueryUICSSCDN).Include(
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