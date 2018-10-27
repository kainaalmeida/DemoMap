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
using DemoMap.Droid.Renderers;
using DemoMap.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(NavegacaoPage), typeof(KANavigationPageRenderer))]
namespace DemoMap.Droid.Renderers
{
    public class KANavigationPageRenderer : NavigationPageRenderer
    {
        private Android.Support.V7.Widget.Toolbar toolbar;

        public KANavigationPageRenderer(Context context) : base(context)
        {
        }

        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);

            if (child.GetType() == typeof(Android.Support.V7.Widget.Toolbar))
            {
                toolbar = (Android.Support.V7.Widget.Toolbar)child;
                toolbar.SetForegroundGravity(GravityFlags.Center);
                toolbar.ChildViewAdded += Toolbar_ChildViewAdded;
            }

        }

        private void Toolbar_ChildViewAdded(object sender, ChildViewAddedEventArgs e)
        {
            if (e.Child.GetType() == typeof(Android.Widget.TextView))
            {

                var textView = (Android.Widget.TextView)e.Child;
                textView.Gravity = GravityFlags.Center;

                //toolbar.SetBackgroundColor(Color.White.ToAndroid());
                toolbar.ChildViewAdded -= Toolbar_ChildViewAdded;
            }
            toolbar.SetForegroundGravity(GravityFlags.Center);
            toolbar.SetBackgroundColor(Color.Black.ToAndroid());
            toolbar.SetForegroundGravity(GravityFlags.Center);
            toolbar.Background.SetAlpha(122);
        }
    }
}