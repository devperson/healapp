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
        
        public ServicesPage()
			: base(false)
		{            
            lblTitle.Text = AppResources.MasterPage_FOOTER_Service;

			btnOpenFile.Clicked += (s, e) => 
            {
				if (this.DoubleClickDetecter.IsDoubleClick ())
					return;

				Navigation.PushAsync (new NewFilePage ());
			};
			btnRequest.Clicked += (s, e) => 
            {
				if (this.DoubleClickDetecter.IsDoubleClick ())
					return;

				Navigation.PushAsync (new AppointmentDetailPage ());
			};
			btnViewAppointment.Clicked += (s, e) => 
            {
				if (this.DoubleClickDetecter.IsDoubleClick ())
					return;
                Navigation.PushAsync(new SearchAppointmentPage());
			};
		}

        protected override void RenderContentView(StackLayout parent)
        {
            ScrollView scrollview = new ScrollView() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stckLayout = new StackLayout() {Spacing = 0, Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };

            var itemContent = MainPage.CreateItemStacklayout();

            btnRequest = MainPage.CreateButton(ImageSource.FromFile(Device.OnPlatform("appoint.png", "appoint.png", "Images/appoint.png")), AppResources.Appointment_Title);
            btnOpenFile = MainPage.CreateButton(ImageSource.FromFile(Device.OnPlatform("document_add.png", "document_add.png", "Images/document_add.png")), AppResources.NewFile_Title);
            itemContent.Children.Add(btnRequest);
            itemContent.Children.Add(btnOpenFile);

            var itemContent2 = MainPage.CreateItemStacklayout();
            itemContent2.Padding = 0;
            btnViewAppointment = MainPage.CreateButton(ImageSource.FromFile(Device.OnPlatform("appointlist.png", "appointlist.png", "Images/appointlist.png")), AppResources.View_Appointment);
            itemContent2.Children.Add(btnViewAppointment);
            stckLayout.Children.Add(itemContent);
            stckLayout.Children.Add(itemContent2);

            scrollview.Content = stckLayout;
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
