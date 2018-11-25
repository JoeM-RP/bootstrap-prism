using System.Collections.ObjectModel;
using PrismForms.Models;
using Prism.Navigation;
using Prism.Commands;

namespace PrismForms.ViewModels
{
	public class AppShellViewModel : BaseViewModel
	{
		/*
         * Define Fields
         */
		// TODO: this is a good place to define services that will be initialized or injected in the constructor

		/*
         * Define Properties
         */
		private ObservableCollection<NavigationMenuItem> _menuItems = new ObservableCollection<NavigationMenuItem>();
		public ObservableCollection<NavigationMenuItem> MenuItems
		{
			get { return _menuItems; }
			set { SetProperty(ref _menuItems, value); }
		}

		private NavigationMenuItem _selectedItem;
		public NavigationMenuItem SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				SetProperty(ref _selectedItem, value);
				if (_selectedItem == null)
					return;
				this.SelectItemCommand.Execute(value);
				SelectedItem = null;
			}
		}

		/*
         * Define Commands
         */
		public DelegateCommand<NavigationMenuItem> SelectItemCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PrismForms.ViewModels.MenuPageViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
		public AppShellViewModel(INavigationService navigationService) : base(navigationService)
		{
            this.Title = "Prism.Forms Bootstrap";

			// Commands
			SelectItemCommand = new DelegateCommand<NavigationMenuItem>((s) => Navigate(s));

			Initialize();
		}

		/* 
         * Define Methods
         */
		private void Initialize()
		{
			MenuItems.Add(new NavigationMenuItem()
			{
				Key = "Home",
				Title = "Home",
                Image = "home.png"
			});

			MenuItems.Add(new NavigationMenuItem()
			{
				Key = "Settings",
				Title = "Settings",
                Image = "settings.png"
			});
		}

        /// <summary>
        /// Navigate the specified args. Since we are triggering navigation outside the Detail view, we specify the URI "path"
        /// of the new page we are navigating to
        /// </summary>
        /// <returns>The navigate.</returns>
        /// <param name="args">Arguments.</param>
		private void Navigate(NavigationMenuItem args)
		{
			switch (args.Key)
			{
				case ("Settings"):
                    this._navigationService.NavigateAsync($"Navigation/{nameof(Views.SettingsPage)}");
					break;
				default:
                    this._navigationService.NavigateAsync($"Navigation/{nameof(Views.HomePage)}");
                    break;
			}
		}

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            // Intentionally empty
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            // Intentionally empty
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            // Intentionally empty
        }
    }
}
