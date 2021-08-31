using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BundlesApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            Bundle bundle = new ScriptBundle("~/myscripts")
                            .Include("~/Scripts/bootstrap.min")
                            .Include("~/Scripts/jquery-3.6.0.min.js");

            bundle.Orderer = new NonOrderingBundleOrderer();

            bundles.Add(bundle);

            BundleTable.EnableOptimizations = false;

            // CSS - StyleBundle
            //bundles.Add(new StyleBundle("~/css/all").Include(
            //    "~/Content/bootstrap.css",
            //    "~/Content/bootstrap-theme.css",
            //    "~/Content/Site.css"));

            //bundles.Add(new StyleBundle("~/css/basic").Include(
            //    "~/Content/bootstrap.css",
            //    "~/Content/Site.css"));


            // JS - ScriptBundle
            //bundles.UseCdn = true;
            //string jqCdn = "https://code.jquery.com/jquery-2.2.4.js";

            //bundles.Add(new ScriptBundle("~/js/all").Include(
            //    "~/Scripts/jquery-{version}.js"));



            //bundles.Add(new ScriptBundle("~/js/all").IncludeDirectory(
            //    "~/Scripts", "*.js", true));



            //bundles.Add(new ScriptBundle("~/js/all").Include(
            //    "~/Scripts/jquery-{version}.js",
            //    "~/Scripts/bootstrap.js",
            //    "~/Scripts/modernizr-{version}.js"));

        }
    }

    internal class NonOrderingBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            List<BundleFile> result = new List<BundleFile>();

            result.Add(files.FirstOrDefault(x => x.VirtualFile.Name == "jquery-3.6.0.min.js"));
            result.AddRange(files.Where(x => x.VirtualFile.Name != "jquery-3.6.0.min.js"));

            return files;
        }
    }
}