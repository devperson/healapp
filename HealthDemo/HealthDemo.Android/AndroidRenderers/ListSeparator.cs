using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using HealthDemo.Droid.AndroidRenderers;
using HealthDemo.Cells;

[assembly: ExportRenderer(typeof(CustomCell), typeof(DoctorCellRenderer))]
namespace HealthDemo.Droid.AndroidRenderers
{
    /// <summary>
    /// Cell renderer allows customizing cell visual for android.
    /// </summary>
    public class DoctorCellRenderer : ViewCellRenderer
    {
        /// <summary>
        /// System method and called for each cell.
        /// </summary>        
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            //Get Android's ListView 
            var thisCellsListView = (Android.Widget.ListView)parent;

            thisCellsListView.Divider = new ColorDrawable(Xamarin.Forms.Color.Black.ToAndroid());
            thisCellsListView.DividerHeight = 1;

            var cell = base.GetCellCore(item, convertView, parent, context);
            return cell;
        }
    }
}