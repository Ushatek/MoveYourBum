using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.ExerciseTypeVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ExerciseTypeV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseTypeEditPage : ContentPage
    {
        public ExerciseTypeForView Item { get; set; }
        public ExerciseTypeEditPage()
        {
            InitializeComponent();

            BindingContext = new ExerciseTypeEditViewModel();
        }
    }
}