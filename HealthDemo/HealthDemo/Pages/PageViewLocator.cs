using HealthDemo.Pages;
using System;
using Xamarin.Forms;

namespace HealthDemo
{
	public class PageViewLocator
	{
		public static NavigationPageEx NavigationPage { get; set; }

        public static MainPage MainPage { get; set; }
        public static ContactPage ContactPage { get; set; }
        public static AboutPage AboutPage { get; set; }
        public static LocationPage LocationPage { get; set; }
        public static DoctorListPage DoctorListPage { get; set; }
        public static SearchDoctorPage SearchDoctorPage { get; set; }
        public static ProfilePage ProfilePage { get; set; }
        public static CategoryListPage CategoryListPage { get; set; }
        public static HealthTipListPage HealthTipListPage { get; set; }
        public static TipDetailPage TipDetailPage { get; set; }
        public static FaqListPage FaqListPage { get; set; }
        public static FaqDetailPage FaqDetailPage { get; set; }
        public static InsuranceListPage InsuranceListPage { get; set; }
        public static InsuranceDetailPage InsuranceDetailPage { get; set; }
        public static NewsListPage NewsListPage { get; set; }
        public static NewsDetailPage NewsDetailPage { get; set; }

        public static bool ReadyToPush { get; set; }
        public static Page PushingPage { get; set; }
	}
}

