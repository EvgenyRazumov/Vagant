using System.Web.Optimization;

namespace Vagant.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js-libraries")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/knockout.js"));

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
                      "~/Content/Common/site.css",
                      "~/Content/Common/reset.css"));

            RegisterProfileBundles(bundles);
            RegisterEventBundles(bundles);
        }

        public static void RegisterProfileBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Profile")
                .Include("~/Scripts/Custom/Models/Profile/achievements.js")
                .Include("~/Scripts/Custom/Models/Profile/contactInformation.js")
                .Include("~/Scripts/Custom/Models/Profile/profileHistory.js")
                .Include("~/Scripts/Custom/Models/Profile/profile.js"));

            bundles.Add(new StyleBundle("~/Content/css/Profile")
                .IncludeDirectory("~/Content/Profile/", "*.css"));
        }

        public static void RegisterEventBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/CreateEvent")
                .Include("~/Scripts/Custom/Models/Event/createEvent.js"));

            bundles.Add(new ScriptBundle("~/bundles/Event")
                .Include("~/Scripts/Custom/Models/Event/event.js"));

            bundles.Add(new StyleBundle("~/bundles/css/CreateEvent")
                .Include("~/Content/Event/createEvent.css"));

            bundles.Add(new StyleBundle("~/bundles/css/Event")
                .Include("~/Content/Event/Event.css"));
        }
    }
}
