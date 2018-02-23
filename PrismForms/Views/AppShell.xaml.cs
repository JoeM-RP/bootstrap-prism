using System;
using System.Collections.Generic;
using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PrismForms.Views
{
    public partial class AppShell : MasterDetailPage, IMasterDetailPageOptions
    {
        public AppShell()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:PrismForms.Views.AppShell"/> is presented after navigation.
        /// </summary>
        /// <remarks>
        /// Required by <see cref="T:Prism.Navigation.IMasterDetailPageOptions"/>
        /// </remarks>
        /// <value><c>true</c> if is presented after navigation; otherwise, <c>false</c>.</value>
        public bool IsPresentedAfterNavigation => Device.Idiom != TargetIdiom.Phone;
    }

    public class AppShellNavigationPage : Xamarin.Forms.NavigationPage, INavigationPageOptions, IDestructible
    {
        public AppShellNavigationPage()
        {
            BarTextColor = (Color)App.Current.Resources["White"];
            BarBackgroundColor = (Color) App.Current.Resources["BrandColor"];
        }

        public bool ClearNavigationStackOnNavigation
        {
            get { return false; }
        }

        public void Destroy()
        {

        }
    }
}