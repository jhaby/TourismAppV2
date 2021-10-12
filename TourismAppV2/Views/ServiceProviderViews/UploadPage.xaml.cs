using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismAppV2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TourismAppV2.Views.ServiceProviderViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UploadPage : ContentPage
    {
        private UploadViewModel viewModel;

        public UploadPage()
        {
            InitializeComponent();
            viewModel = new UploadViewModel();
            BindingContext = viewModel;
        }
    }
}