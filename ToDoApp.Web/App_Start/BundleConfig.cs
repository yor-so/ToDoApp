using System.Web;
using System.Web.Optimization;

namespace ToDoApp.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/kendoJs")
                .Include(
                        "~/assets/js/libs/kendo-ui/js/jquery.min.js",
                        "~/assets/js/libs/kendo-ui/js/kendo.all.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/assets/js/libs/kendo-ui/styles/kendo.default-main.min.css"));
        }
    }
}
