using InfiniteListView.ViewModels;
using Xamarin.Forms;

namespace InfiniteListView
{
    public partial class InfiniteListViewPage : ContentPage
    {
        public InfiniteListViewPage()
        {
            InitializeComponent();

            BindingContext = new InfiniteListViewViewModel();
        }
    }
}
