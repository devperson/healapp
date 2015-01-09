using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Dependency
{
    /// <summary>
    /// Interface is used for abstracting Phone call functionality.
    /// </summary>
    public interface ITel
    {
        void Tel(string number);
    }
}
