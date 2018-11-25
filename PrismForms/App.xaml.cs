using DryIoc;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Logging;
using Xamarin.Forms;

namespace PrismForms
{
    public partial class App : PrismApplication
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:PrismForms.App"/> class.
        /// </summary>
        /// <remarks>
        /// Used when no additional parmeters are needed
        /// </remarks>
        public App()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PrismForms.App"/> class.
        /// </summary>
        /// <param name="platformInitializer">Platform initializer.</param>
        /// <remarks>
        /// Used when  platfrom specific initializer is required - this will be used if you are using 
        /// very platform-focused libraries like ARKit that you want to resolve using DI
        /// </remarks>
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PrismForms.App"/> class.
        /// </summary>
        /// <param name="platformInitializer">Platform initializer.</param>
        /// <param name="setFormsDependencyResolver">If set to <c>true</c> set forms dependency resolver.</param>
        public App(IPlatformInitializer platformInitializer, bool setFormsDependencyResolver) : base(platformInitializer, setFormsDependencyResolver)
        {
        }

        public static new App Current => Application.Current as App;

        /// <summary>
        /// Logging provided by <see cref="Prism.Logging"/>
        /// </summary>
        /// <value>The logger</value>
		public new ILoggerFacade Logger
		{
			// get { return base.Logger; } // Prism 6 - delet this
            get { return this.Logger; } // Prism 7
		}

        /// <summary>
        /// With Prism, we navigate using a URI format to preserve the stack. We can also
        /// reset or rearrage the stack by manipulating the URI, or perform "deep linking"
        /// when the app is launched with parameters (i.e - email link, push notification, etc)
        /// </summary>
		protected override void OnInitialized()
		{
            InitializeComponent();

            NavigationService.NavigateAsync($"myapp:///Root/Navigation/{nameof(Views.HomePage)}");
		}

        /// <summary>
        /// Registers the types. Notice that we can set the name explicity by providing the 
        /// name parameter, or just use the nameof property for the page
        /// </summary>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register Navigation page
            containerRegistry.RegisterForNavigation<Views.AppShellNavigationPage>("Navigation");

            // Register Views
            containerRegistry.RegisterForNavigation<Views.AppShell>("Root");
            containerRegistry.RegisterForNavigation<Views.HomePage>();
            containerRegistry.RegisterForNavigation<Views.SamplePage>();
            containerRegistry.RegisterForNavigation<Views.SettingsPage>();
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
