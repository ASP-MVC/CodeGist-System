namespace CG.Common
{
    using System.Web;

    public class DirectoryLocator
    {
        public static string GetCurrentDirectory(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
}