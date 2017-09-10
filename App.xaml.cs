using DryIoc;
using Prism.DryIoc;
using Prism.Logging;
using Xamarin.Forms;

namespace PrismForms
{
    public partial class App : PrismApplication
    {
		public static new App Current => Application.Current as App;

        public App()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Logging provided by <see cref="Prism.Logging"/>
        /// </summary>
        /// <value>The logger</value>
		public new ILoggerFacade Logger
		{
			get { return base.Logger; }
		}

        /// <summary>
        /// With Prism, we navigate using a URI format to preserve the stack. We can also
        /// reset or rearrage the stack by manipulating the URI
        /// </summary>
		protected override void OnInitialized()
		{
            NavigationService.NavigateAsync($"Root/Navigation/{nameof(Views.HomePage)}", animated: false);
		}

        /// <summary>
        /// Registers the types. Notice that we can set the name explicity by providing the 
        /// name parameter, or just use the nameof property for the page
        /// </summary>
		protected override void RegisterTypes()
		{
            // Register Navigation page
            Container.RegisterTypeForNavigation<Views.AppShellNavigationPage>("Navigation");

            // Register Views
            Container.RegisterTypeForNavigation<Views.AppShell>("Root");
			Container.RegisterTypeForNavigation<Views.HomePage>();
            Container.RegisterTypeForNavigation<Views.SamplePage>();
			Container.RegisterTypeForNavigation<Views.SettingsPage>();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
    }
}
