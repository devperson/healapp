using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Dependency
{
    /// <summary>
    /// Interface is used for abstracting setting device UI localization.
    /// </summary>
    public interface ILocalize
    {
        void SetLocale(string local);
    }
}
