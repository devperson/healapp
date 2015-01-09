using HealthDemo.Pages;
using System;
using Xamarin.Forms;

namespace HealthDemo
{

    /// <summary>
    /// This class does not represents any functionality and used for keeping referances of page instances.
    /// </summary>
	public class PageViewLocator
	{
		public static NavigationPageEx NavigationPage { get; set; }        
        public static DoctorListPage DoctorListPage { get; set; }        
        public static ProfilePage ProfilePage { get; set; }        
        public static HealthTipListPage HealthTipListPage { get; set; }
        public static TipDetailPage TipDetailPage { get; set; }        
        public static FaqDetailPage FaqDetailPage { get; set; }        
        public static InsuranceDetailPage InsuranceDetailPage { get; set; }        
        public static NewsDetailPage NewsDetailPage { get; set; }

        public static bool ReadyToPush { get; set; }
        public static Page PushingPage { get; set; }
	}
}

