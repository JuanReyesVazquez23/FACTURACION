using System.Web.Optimization;

namespace FACTURACION
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                            "~/Scripts/jquery-3.7.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                            "~/Scripts/site.js"));
        }
    }
}
