﻿using HealthDemo.Models;
using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Pages
{
    /// <summary>
    /// This class creates UI page for Appointment detail page.
    /// </summary>
    public class AppointmentDetailPage : MasterPage
    {        
        private Picker btnComboClinical;
        private Button btnSubmit { get; set; }
        private Grid contentGrid;
        private Label lblReferal, idLbl;
        private Entry refEntry, idEntry;

        public AppointmentDetailPage()
            : base()
        {
            //Bind page with data and handle button click events

            ViewModelLocator.AppointmentVM.NewAppointment = new Appointment();
            lblTitle.Text = AppResources.Appointment_Title;
            this.BindingContext = ViewModelLocator.AppointmentVM;
            this.contentGrid.BindingContext = ViewModelLocator.AppointmentVM.NewAppointment;

           
            btnComboClinical.SelectedIndexChanged += (sender, args) =>
            {
                if (btnComboClinical.SelectedIndex != -1)
                {
                    var title = btnComboClinical.Items[btnComboClinical.SelectedIndex];
                    ViewModelLocator.AppointmentVM.NewAppointment.Clinic = title;
                }
            };

            btnSubmit.Clicked += (s, e) =>
            {
                ViewModelLocator.AppointmentVM.SendAppointment(async (success) =>
                {
                    if (success)
                    {
                        await this.DisplayAlert(AppResources.Appointment_SUBMIT_DLG_Title, AppResources.Appointment_SUBMIT_DLG_Msg, "OK");
                        Navigation.PopToRootAsync();
                    }
                });
            };            
        }

        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
        protected override void RenderContentView(StackLayout parent)
        {
            ScrollView scrollview = new ScrollView() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stlayout = new StackLayout() { Spacing = 0, Padding = new Thickness(0, 0, 0, 15), Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand };            
            contentGrid = new Grid
            {
                Padding = new Thickness(5, 10, 15, 25),
                ColumnSpacing = 7,
                RowSpacing = 15,
                VerticalOptions = LayoutOptions.Start,                
                RowDefinitions = 
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }                    
                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width =  new GridLength(1, GridUnitType.Star)}
                }
            };
            if (!this.IsEn())
            {                
                contentGrid.ColumnDefinitions = new ColumnDefinitionCollection()
                {
                    new ColumnDefinition { Width =  new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition { Width = GridLength.Auto }
                };
            }
            contentGrid.AddLabel(AppResources.Appointment_FORM_Head, 0);
            contentGrid.AddLabel(string.Empty, 0, 1);
            contentGrid.AddLabel(AppResources.Appointment_FORM_Name, 1);
            contentGrid.AddTextField("Name", 1);
            contentGrid.AddLabel(AppResources.Appointment_FORM_MRN, 2);
            contentGrid.AddTextField("MRN", 2);
            contentGrid.AddLabel(AppResources.Appointment_FORM_Phone, 3);
            contentGrid.AddTextField("Phone", 3, Keyboard.Telephone);
            contentGrid.AddLabel(AppResources.Appointment_FORM_Thiqa, 4);
            contentGrid.AddSwitchField("ThiqaYes", 4);

            this.lblReferal = contentGrid.AddLabel(AppResources.Appointment_FORM_Referral, 5);
            this.lblReferal.YAlign = TextAlignment.Center;
            this.lblReferal.HeightRequest = 45;
            this.lblReferal.WidthRequest = 75;
            this.lblReferal.XAlign = TextAlignment.End;
            this.refEntry = contentGrid.AddTextField("Refference", 5);

            this.idLbl = contentGrid.AddLabel(AppResources.Appointment_FORM_ID, 5);
            this.idLbl.YAlign = TextAlignment.Center;
            this.idLbl.HeightRequest = 45;
            this.idLbl.WidthRequest = 75;
            this.idLbl.XAlign = TextAlignment.End;
            this.idLbl.IsVisible = false;
            this.idEntry = contentGrid.AddTextField("ID", 5);
            this.idEntry.IsVisible = false;

            contentGrid.AddLabel(AppResources.Appointment_FORM_Clinical, 6);
            AddComboField(6);
            contentGrid.AddLabel(AppResources.Appointment_FORM_Email, 7);
            contentGrid.AddTextField("Email", 7, Keyboard.Email);

            btnSubmit = new Button()
            {
                BackgroundColor = Color.FromHex("FF54A6D3"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                WidthRequest = 200,
                HeightRequest = 40,
                TextColor = Color.Black,
                Text = AppResources.Appointment_FORM_Submit
            };

            stlayout.Children.Add(contentGrid);
            stlayout.Children.Add(btnSubmit);

            scrollview.Content = stlayout;
            if (Device.OS == TargetPlatform.Android)
            {
                btnSubmit.Font = Font.SystemFontOfSize(16);
                scrollview.IsClippedToBounds = true;
            }
            parent.Children.Add(scrollview);

            
        }

        /// <summary>
        /// This is a system method and is executed right before page appears.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModelLocator.AppointmentVM.ShowAlert = this.DisplayAlert;

            ViewModelLocator.AppointmentVM.NewAppointment.PropertyChanged += NewAppointment_PropertyChanged;            
        }

        /// <summary>
        /// This is a system method and is executed right before page disappears.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.AppointmentVM.ShowAlert = null;
            ViewModelLocator.AppointmentVM.NewAppointment.PropertyChanged -= NewAppointment_PropertyChanged;        
        }

        /// <summary>
        /// Event handler method fires when model property changes.
        /// </summary>        
        private void NewAppointment_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ThiqaYes")
            {
                var model = sender as Appointment;
                if(model.ThiqaYes)
                {
                    lblReferal.IsVisible = false;
                    refEntry.IsVisible = false;
                    idLbl.IsVisible = true;
                    idEntry.IsVisible = true;
                }
                else
                {
                    lblReferal.IsVisible = true;
                    refEntry.IsVisible = true;
                    idLbl.IsVisible = false;
                    idEntry.IsVisible = false;
                }
            }
        }

        /// <summary>
        /// Helper method adds combo box like control to specified row in grid panel.
        /// </summary>        
        public void AddComboField(int row)
        {
            var comboLayouyt = this.CreateComboBox(ref btnComboClinical);
            for (int i = 1; i < 7; i++)
			{
                btnComboClinical.Items.Add(AppResources.Appointment_FORM_Clinical + " " + i.ToString());
			}
            int col = 1;
            if (!contentGrid.IsEn()) col = 0;
            contentGrid.Children.Add(comboLayouyt, col, row);
		}

	}
}
