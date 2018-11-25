using System;
using Prism.Commands;
using Prism.Navigation;
using PrismForms.Models;

namespace PrismForms.ViewModels
{
    public class SamplePageViewModel : BaseViewModel
    {
		/*
         * Define Fields
         */
		// TODO: this is a good place to define services that will be initialized or injected in the constructor

		/*
         * Define Properites
         */
		private string _subject;
		public string Subject
		{
            get { return _subject; }
			set { SetProperty(ref _subject, value); }
		}

        private string _copy;
        public string Copy
		{
			get { return _copy; }
            set { SetProperty(ref _copy, value); }
		}

		/*
         * Define Commands
         */
		public DelegateCommand NavigateCommand { get; set; }

        public SamplePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Sample Page";
        }

        /*
         * Define Methods
         */
        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            // Intentionally empty
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            this.Copy = parameters.GetValue<string>("content");
            this.Subject = parameters.GetValue<string>("subject");
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            // Intentionally empty
        }
    }
}
