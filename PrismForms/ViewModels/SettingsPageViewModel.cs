using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;

namespace PrismForms.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
		/*
         * Define Fields
         */
		// TODO: this is a good place to define services that will be initialized or injected in the constructor

		/*
         * Define Properites
         */
		private string _settingOne;
        public string SettingOne
		{
			get { return _settingOne; }
			set { SetProperty(ref _settingOne, value); }
		}

        private bool _settingTwo;
        public bool SettingTwo
		{
			get { return _settingTwo; }
			set { SetProperty(ref _settingTwo, value); }
		}

        private bool _settingThree;
        public bool SettingThree
		{
			get { return _settingThree; }
			set { SetProperty(ref _settingThree, value); }
		}

		/*
         * Define Commands
         */
		public DelegateCommand SaveCommand { get; set; }

        public SettingsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Settings";

            SaveCommand = new DelegateCommand( async () =>  await SaveAndNavigate(), () => !IsLoading );
        }

        /*
         * Define Methods
         */
        private async Task<bool> SaveAndNavigate()
        {
            IsLoading = true;

            // TODO: do something to save settings here.
            await Task.Delay(2000);
            //\

            IsLoading = false;

            await this._navigationService.GoBackAsync();

            return true;
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
