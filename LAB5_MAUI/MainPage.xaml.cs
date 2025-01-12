using LAB5_MAUI.ViewModels;

namespace LAB5_MAUI
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _viewModel;
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = viewModel;
        }

    }

}
