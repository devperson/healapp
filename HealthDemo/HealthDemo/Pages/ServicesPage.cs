using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Controls;

namespace HealthDemo.Pages
{
    public class ServicesPage : MasterPage
    {
        ImageButton btnOpenFile, btnRequest, btnViewAppointment;
        public static string HeaderTitle = "e-Service";
        public ServicesPage()
			: base(false)
		{
			lblTitle.Text = HeaderTitle;

			btnOpenFile.Clicked += (s, e) => {
				if (this.DoubleClickDetecter.IsDoubleClick ())
					return;

				Navigation.PushAsync (new NewFilePage ());
			};
			btnRequest.Clicked += (s, e) => {
				if (this.DoubleClickDetecter.IsDoubleClick ())
					return;

				Navigation.PushAsync (new AppointmentDetailPage ());
			};
			btnViewAppointment.Clicked += (s, e) => {
				if (this.DoubleClickDetecter.IsDoubleClick ())
					return;

			};
		}

        protected override void RenderContentView(StackLayout parent)
        {
            ScrollView scrollview = new ScrollView() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stackLayout = new StackLayout() { Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };

            var itemContent = MainPage.CreateItemStacklayout();

            btnRequest = MainPage.CreateButton(ImageSource.FromFile(Device.OnPlatform("appoint.png", "appoint.png", "Images/appoint.png")), "Appointment");
            btnOpenFile = MainPage.CreateButton(ImageSource.FromFile(Device.OnPlatform("document_add.png", "document_add.png", "Images/document_add.png")), "New File");
            itemContent.Children.Add(btnRequest);
            itemContent.Children.Add(btnOpenFile);

            var itemContent2 = MainPage.CreateItemStacklayout();
            btnViewAppointment = MainPage.CreateButton(ImageSource.FromFile(Device.OnPlatform("appointlist.png", "appointlist.png", "Images/appointlist.png")), "Find Doctors");
            itemContent2.Children.Add(btnViewAppointment);

            stackLayout.Children.Add(itemContent);
            //stackLayout.Children.Add(itemContent2);

            scrollview.Content = stackLayout;
            if (Device.OS == TargetPlatform.Android)
            {
                var f = Font.SystemFontOfSize(14);
                btnRequest.Font = f;
                btnOpenFile.Font = f;
                btnViewAppointment.Font = f;
                scrollview.IsClippedToBounds = true;
            }
            parent.Children.Add(scrollview);
        }
    }
}
