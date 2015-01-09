using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Dependency
{
    /// <summary>
    /// Interface abstracts loading of app's main page.
    /// </summary>
    public interface IAppLoader
    {
        void ShowMainPage();
    }
}
