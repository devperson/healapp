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

        private static InsuranceViewModel _insuranceVM;
        public static InsuranceViewModel InsuranceVM
        {
            get
            {
                if (_insuranceVM == null)
                    _insuranceVM = new InsuranceViewModel();
                return _insuranceVM;
            }
        }

        private static FaqViewModel _FaqVM;
        public static FaqViewModel FaqVM
        {
            get
            {
                if (_FaqVM == null)
                    _FaqVM = new FaqViewModel();
                return _FaqVM;
            }
        }

        private static NewsViewModel _newsVM;
        public static NewsViewModel NewsVM
        {
            get
            {
                if (_newsVM == null)
                    _newsVM = new NewsViewModel();
                return _newsVM;
            }
        }

        private static AppointmentViewModel _appointVM;
        public static AppointmentViewModel AppointmentVM
        {
            get
            {
                if (_appointVM == null)
                    _appointVM = new AppointmentViewModel();
                return _appointVM;
            }
        }

        private static FileViewModel _fileVM;
        public static FileViewModel FileVM
        {
            get
            {
                if (_fileVM == null)
                    _fileVM = new FileViewModel();
                return _fileVM;
            }
        }

    }
}
