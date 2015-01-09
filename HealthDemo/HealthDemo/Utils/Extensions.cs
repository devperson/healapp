using HealthDemo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo
{
    /// <summary>
    /// This class represents helper methods for all pages.
    /// </summary>
    public static class PageExtensions
    {
        /// <summary>
        /// Helper method for creating combo box like control.
        /// </summary>        
        public static AbsoluteLayout CreateComboBox(this Page p, ref Picker btnComboFor)
        {
            var comboLayout = new AbsoluteLayout() { HeightRequest = 35, HorizontalOptions = LayoutOptions.FillAndExpand};
            var comboBackground = new Image()
            {
                Aspect = Aspect.Fill,
                Source = p.IsEn() ? "comboback.png" : "combobackar.png",
                HeightRequest = 35,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            btnComboFor = new CustomPicker() { HeightRequest = 35, HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, Title = string.Empty };

            comboLayout.Children.Add(comboBackground, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            comboLayout.Children.Add(btnComboFor, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            return comboLayout;
        }

        /// <summary>
        /// Adds basic text label with specified text, row, col parameters to Grid panel
        /// </summary>        
        public static Label AddLabel(this Grid contentGrid, string title, int row, int col = 0)
        {
            var lbl = new Label
            {
                Text = title,
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            if (!contentGrid.IsEn()) col = col == 0 ? 1 : 0;
            contentGrid.Children.Add(lbl, col, row);

            return lbl;
        }

        /// <summary>
        /// Adds basic text label with specified data binding path, row, col parameters to Grid panel
        /// </summary>       
        public static Label AddLabelWithBinding(this Grid contentGrid, string binding, int row, int col = 0)
        {
            var lbl = new Label
            {   
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            lbl.SetBinding(Label.TextProperty, new Binding(binding));
            if (!contentGrid.IsEn()) col = col == 0 ? 1 : 0;
            contentGrid.Children.Add(lbl, col, row);

            return lbl;
        }

        /// <summary>
        /// Adds basic text field with specified data binding path, row parameters to Grid panel
        /// </summary>       
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
            var col = 1;
            if (!contentGrid.IsEn()) col = 0;
            contentGrid.Children.Add(entry, col, row);
            return entry;
        }

        /// <summary>
        /// Adds basic switch control with specified data binding path, row parameters to Grid panel
        /// </summary>  
        public static void AddSwitchField(this Grid contentGrid, string binding, int row)
        {
            var switchControl = new Switch()
            {
                HorizontalOptions = contentGrid.IsEn() ? LayoutOptions.Start : LayoutOptions.End,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            switchControl.SetBinding(Switch.IsToggledProperty, binding, BindingMode.TwoWay);
            var col = 1;
            if (!contentGrid.IsEn()) col = 0;
            contentGrid.Children.Add(switchControl, col, row);
        }

        /// <summary>
        /// Creates simple button with specified text.
        /// </summary>  
        public static Button CreateButton(this Page p, string title)
        {
            return new Button()
            {
                BackgroundColor = Color.FromHex("FF54A6D3"),
                WidthRequest = 120,
                HeightRequest = 40,
                TextColor = Color.Black,
                Text = title
            };
        }

        /// <summary>
        /// Finds all labels and reverses their aligment.
        /// </summary>        
        public static void ReverseLabelesAligment(this IViewContainer<View> root)
        {
            foreach (var lbl in root.GetAllLables())
            {                
                if (lbl.XAlign == TextAlignment.End || lbl.HorizontalOptions.Alignment == LayoutAlignment.End)
                {
                    lbl.XAlign = TextAlignment.Start;
                    lbl.HorizontalOptions = LayoutOptions.StartAndExpand;
                    continue;
                }

                lbl.XAlign = TextAlignment.End;
                lbl.HorizontalOptions = LayoutOptions.EndAndExpand;
            }
        }

        /// <summary>
        /// Finds all labels in specified panel.
        /// </summary>        
        public static List<Label> GetAllLables(this IViewContainer<View> root)
        {
            List<Label> lbls = new List<Label>();
            foreach (var item in root.Children)
            {
                View child = item;

                while(child is ScrollView || child is ContentView)
                {
                    if (child is ScrollView)
                        child = (child as ScrollView).Content;
                    if (child is ContentView)
                        child = (child as ContentView).Content;
                }                
                
                if (child is Label)
                    lbls.Add(child as Label);
                if (child is IViewContainer<View>)
                    lbls.AddRange((child as IViewContainer<View>).GetAllLables());                
            }

            return lbls;
        }

        /// <summary>
        /// Finds all controls with padding set and reverses their values.
        /// </summary>        
        public static void ReverseLayoutPaddings(this Layout root)
        {
            foreach (var layout in root.GetAllLayouts())
            {
                if (layout.Padding.Left > 0 || layout.Padding.Right > 0)
                {
                    layout.Padding = new Thickness(layout.Padding.Right, layout.Padding.Top, layout.Padding.Left, layout.Padding.Bottom);
                }
            }
        }

       
        #region VisualTree Helper
        /// <summary>
        /// Helper method for getting all controls from specified control by traversing visual tree
        /// </summary>        
        public static IEnumerable<Layout> GetAllLayouts(this Layout root)
        {
            Queue<Layout> remaining = new Queue<Layout>();
            remaining.Enqueue(root);

            while (remaining.Count > 0)
            {
                var layout = remaining.Dequeue();
                yield return layout;

                foreach (var child in layout.GetLayoutChildren())
                {
                    if (child is Layout)
                        remaining.Enqueue(child as Layout);
                }
            }
        }

        /// <summary>
        /// Retrives any possible child of specified control.
        /// </summary>        
        public static List<View> GetLayoutChildren(this Layout root)
        {
            if (root is ContentView)
                return new List<View> { (root as ContentView).Content };
            if (root is ScrollView)
                return new List<View> { (root as ScrollView).Content };

            if (root is IViewContainer<View>)
            {
                return (root as IViewContainer<View>).Children.ToList();
            }
            return new List<View>();
        }
        #endregion

        /// <summary>
        /// Indicates is whether English localization being used.
        /// </summary>        
        public static bool IsEn(this object p)
        {
            return App.CurrentLanguage == Languages.En;
        }
    }
}
