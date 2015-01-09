using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Utils
{
    /// <summary>
    /// Helper class used within click event to determine is whether its double click or single click.
    /// </summary>
    public class DoubleClickDetecter
    {
        public long DoubleClickSpeed = 500;
        private long lastClickTicks = 0;
        
        /// <summary>
        /// Returns false if single click and true if double click.
        /// </summary>        
        public bool IsDoubleClick()
        {
            var clickTicks = DateTime.Now.Ticks;
            var elapsedTicks = clickTicks - lastClickTicks;
            var elapsedTime = elapsedTicks / TimeSpan.TicksPerMillisecond;
            bool quickClick = (elapsedTime <= DoubleClickSpeed);

            lastClickTicks = clickTicks + 500;

            return quickClick;                
        }       
    }
}
