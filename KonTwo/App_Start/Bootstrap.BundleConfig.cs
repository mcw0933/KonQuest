using System.Web;
using System.Web.Optimization;

namespace KonTwo
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            // https://developers.google.com/speed/libraries/devguide
            var jQueryCDN = "//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js";

            bundles.Add(new ScriptBundle("~/bundles/jquery", jQueryCDN).Include(
                        "~/Scripts/jquery-{version}.js"));

            // http://erraticdev.blogspot.ie/2010/12/sending-complex-json-objects-to-aspnet.html
            bundles.Add(new ScriptBundle("~/bundles/jqueryplugins").Include(
                        "~/Scripts/toDictionary.js"));

            // http://cdnjs.com
            var modernizrCDN = "//cdnjs.cloudflare.com/ajax/libs/modernizr/2.6.2/modernizr.min.js";
            var fontAwesomeCDN = "//cdnjs.cloudflare.com/ajax/libs/font-awesome/3.0.2/css/font-awesome.min.css";

            bundles.Add(new ScriptBundle("~/bundles/modernizr", modernizrCDN).Include(
                        "~/Scripts/modernizr-*"));

            // http://www.seankilleen.com/2012/12/how-to-quickly-update-mvc4-project-with.htmls
            var css = new StyleBundle("~/Content/css").Include("~/Content/site.less");
            css.Transforms.Add(new LessMinify());
            bundles.Add(css);

            bundles.Add(new StyleBundle("~/Content/fontawesome", fontAwesomeCDN).Include(
                        "~/Content/font-awesome.css"));
        }
    }
}