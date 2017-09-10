using System;
using System.Collections.Generic;
using Prism.Navigation;
using Xamarin.Forms;

namespace PrismForms.Views
{
    public partial class AppShell : MasterDetailPage, IMasterDetailPageOptions
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="T:PrismForms.Views.AppShell"/> is presented after navigation.
        /// </summary>
        /// <remarks>
        /// Required by <see cref="T:Prism.Navigation.IMasterDetailPageOptions"/>
        /// </remarks>
        /// <value><c>true</c> if is presented after navigation; otherwise, <c>false</c>.</value>
        public bool IsPresentedAfterNavigation => Device.Idiom != TargetIdiom.Phone;

        public AppShell()
        {
            InitializeComponent();
        }
    }

    public class AppShellNavigationPage : NavigationPage, INavigationPageOptions, IDestructible
    {
        public AppShellNavigationPage()
        {
            BarTextColor = Color.White;
            BarBackgroundColor = Color.FromHex("#394A76");
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