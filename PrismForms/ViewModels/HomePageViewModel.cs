using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PrismForms.Models;
using Prism.Navigation;
using Prism.Commands;
using Prism.Services;

namespace PrismForms.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        /*
         * Define Fields
         */
        IPageDialogService _dialogService;

        /*
         * Define Properites
         */
        private ObservableCollection<CopyItem> _copyItems = new ObservableCollection<CopyItem>();
        public ObservableCollection<CopyItem> CopyItems
        {
            get { return _copyItems; }
            set { SetProperty(ref _copyItems, value); }
        }

        private CopyItem _selectedItem;
        public CopyItem SelectedItem
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
        public DelegateCommand ShowActionSheetCommand { get; set; }
        public DelegateCommand ShowAlertCommand { get; set; }
        public DelegateCommand<CopyItem> SelectItemCommand { get; set; }

        public HomePageViewModel(IPageDialogService dialogService, INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Home";
            _dialogService = dialogService;

            ShowAlertCommand = new DelegateCommand(async () => await ShowAlert());
            ShowActionSheetCommand = new DelegateCommand(async () => await ShowActionSheet());
            SelectItemCommand = new DelegateCommand<CopyItem>((param) => Navigate(param));

            Init();
        }

        /*
         * Define Methods
         */
        private async Task ShowAlert()
        {
            var response = await _dialogService.DisplayAlertAsync("Yikes!", "This is a fake error to demonstrate the alert", "Retry", "Cancel");

            if (response)
            {
                // TODO: If response is true, the user wants to "retry" the action. 
                // Do something here to attempt the action again
            }
            else
            {
                // TODO: If response is false, the user has canceled the attempted action
                // So perform an action here that makes sense; we may want to naviagte to 
                // a previous page or just sit idle
            }
        }

        private async Task ShowActionSheet()
        {

            var response = await _dialogService.DisplayActionSheetAsync("Actions", "Cancel", "Destroy", new string[] { "Action1", "Action2" });

            // TODO: Like with the Error Dialog, we want to perform different actions based on the user selection
            switch (response)
            {
                case ("Action1"):
                case ("Action2"):
                default:
                    await _dialogService.DisplayAlertAsync("I did it!", $"Selected {response}", "Ok");
                    break;
            }
        }

        private async void Navigate(CopyItem parameter)
        {
            // Pass the parameters as part of the navigation string. A typical example would be to pass only the ID of an object, which
            // the resulting page would lookup/resolve via a service 
            await _navigationService.NavigateAsync($"{nameof(Views.SamplePage)}?subject={parameter.Title}&content={parameter.Body}");

            // Or, we can declare them explicity using a strongly typed object, which is ideal for passing 
            // a more complex model that the next page won't lookup on its own
            /*
			var payload = new NavigationParameters();
			payload.Add("content", parameter);

            await _navigationService.NavigateAsync($"Navigation/{nameof(Views.SamplePage)}", payload);
            */
        }

        private void Init()
        {
            _copyItems.Add(new CopyItem()
            {
                Title = "About Me",
                Body = "I’m Joe; full-time developer, part-time hobby-jogger, Tsar of awful check-in comments. I like cooking, exploring Chicago, and a good story. I write code sometimes."
            });

            _copyItems.Add(new CopyItem()
            {
                Title = "About Prism.Forms",
                Body = "Prism is a framework for building loosely coupled, maintainable, and testable XAML applications in WPF, Windows 10 UWP, and Xamarin Forms. Separate releases are available for each platform and those will be developed on independent timelines. Prism provides an implementation of a collection of design patterns that are helpful in writing well-structured and maintainable XAML applications, including MVVM, dependency injection, commands, EventAggregator, and others. "
            });

            _copyItems.Add(new CopyItem()
            {
                Title = "About Shakespeare",
                Body = "William Shakespeare was an English poet, playwright, and actor, widely regarded as the greatest writer in the English language and the world's pre-eminent dramatist. He is often called England's national poet, and the \"Bard of Avon\". His extant works, including collaborations, consist of approximately 38 plays, 154 sonnets, 2 long narrative poems, and a few other verses, some of uncertain authorship. His plays have been translated into every major living language and are performed more often than those of any other playwright."
            });

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