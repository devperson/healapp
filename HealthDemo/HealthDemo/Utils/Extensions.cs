using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Pages
{
    public static class PageExtensions
    {
        public static AbsoluteLayout CreateComboBox(this Page p, ref Picker btnComboFor)
        {
            var comboLayout = new AbsoluteLayout() { HeightRequest = 35, HorizontalOptions = LayoutOptions.FillAndExpand};
            var comboBackground = new Image()
            {
                Aspect = Aspect.Fill,
                Source = Device.OnPlatform("comboback.png", "comboback.png", "Images/comboback.png"),
                HeightRequest = 35,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            btnComboFor = new CustomPicker() { HeightRequest = 35, HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, Title = string.Empty };

            comboLayout.Children.Add(comboBackground, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            comboLayout.Children.Add(btnComboFor, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            return comboLayout;
        }

        public static Label AddLabel(this Grid contentGrid, string title, int row, int col = 0)
        {
            var lbl = new Label
            {
                Text = title,
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            contentGrid.Children.Add(lbl, col, row);

            return lbl;
        }

        public static Label AddLabelWithBinding(this Grid contentGrid, string binding, int row, int col = 0)
        {
            var lbl = new Label
            {   
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            lbl.SetBinding(Label.TextProperty, new Binding(binding));
            contentGrid.Children.Add(lbl, col, row);

            return lbl;
        }

        public static Entry AddTextField(this Grid contentGrid, string binding, int row, Keyboard key = null)
        {
            var entry = new CustomTextBox
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            if (key != null)
                entry.Keyboard = key;
            entry.SetBinding(Entry.TextProperty, binding, BindingMode.TwoWay);
            contentGrid.Children.Add(entry, 1, row);
            return entry;
        }

        public static void AddSwitchField(this Grid contentGrid, string binding, int row)
        {
            var switchControl = new Switch()
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            switchControl.SetBinding(Switch.IsToggledProperty, binding, BindingMode.TwoWay);
            contentGrid.Children.Add(switchControl, 1, row);
        }
    }
}
