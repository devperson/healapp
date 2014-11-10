using System;
using System.Net;
using System.Windows;

namespace HealthDemo.ViewModels
{
    public class ViewModelLocator
    {
        private static DoctorViewModel _doctorVM;
        public static DoctorViewModel DoctorVM
        {
            get
            {
                if (_doctorVM == null)
                    _doctorVM = new DoctorViewModel();
                return _doctorVM;
            }
        }

        private static TipViewModel _tipVM;
        public static TipViewModel TipVM
        {
            get
            {
                if (_tipVM == null)
                    _tipVM = new TipViewModel();
                return _tipVM;
            }
        }

    }
}
