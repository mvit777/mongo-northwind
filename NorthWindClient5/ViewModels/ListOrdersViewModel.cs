namespace NorthWindClient5.ViewModels
{

    public partial class ListOrdersViewModel : BaseViewModel
    {
        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        ObservableCollection<SampleItem> items;
    }
}
