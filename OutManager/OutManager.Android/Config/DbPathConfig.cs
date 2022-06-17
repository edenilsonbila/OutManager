using OutManager.Config;
using Xamarin.Forms;

[assembly: Dependency(typeof(OutManager.Droid.Config.DbPathConfig))]
namespace OutManager.Droid.Config
{
    public class DbPathConfig : IDbPathConfig
    {
        private string _path;

        public string Path
        {
            get
            {
                if (string.IsNullOrEmpty(_path))
                {
                    _path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return _path;
            }
        }
    }
}
