using MoveYourBum.ViewModels.DayVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.DayV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayPage : ContentPage
    {
        private DayViewModel _viewModel;
        public DayPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new DayViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}