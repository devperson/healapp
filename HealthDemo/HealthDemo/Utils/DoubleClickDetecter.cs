using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Utils
{
    public class DoubleClickDetecter
    {
        public long DoubleClickSpeed = 500;
        private long lastClickTicks = 0;
        
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
