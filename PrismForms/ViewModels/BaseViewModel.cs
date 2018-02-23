using System.Collections.ObjectModel;
using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismForms.ViewModels
{
	public abstract class BaseViewModel : BindableBase, INavigationAware
	{
		/* 
         * Define Fields
         */
		private ObservableCollection<string> _errors;
        protected INavigationService _navigationService { get; }

		/* 
         * Define Properties
         */
		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		/// <summary>
        /// Notice that we can use RaisePropertyChanged to update the value of a related property, in this case <see cref="IsNotBusy"/>
		/// </summary>
        private bool _isLoading;
		public bool IsLoading
		{
			get { return _isLoading; }
			set { SetProperty(ref _isLoading, value, () => RaisePropertyChanged(nameof(IsNotBusy))); }
		}

		public bool IsNotBusy
		{
			get { return !IsLoading; }
		}

		/*
         * Define Commands
         */
		// TODO:


		public BaseViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		/*
         * Define Methods
         */
        public virtual void OnNavigatedFrom(NavigationParameters parameters)
		{
            // Do something cool here when we naviagte away from the ViewModel
		}

		public virtual void OnNavigatedTo(NavigationParameters parameters)
		{
            // Do something cool here when we have finished navigating to the ViewModel
		}

		public virtual void OnNavigatingTo(NavigationParameters parameters)
		{
            // Do something cool here when we start navigating to the ViewModel
		}
	}
}
