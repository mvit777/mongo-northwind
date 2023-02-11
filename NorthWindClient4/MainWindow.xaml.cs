using Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NorthWindClient4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private HttpClient httpClient { get; set; }
        private string _ServiceUrl = "https://localhost:7128/api";
        private string OrdersEndPoint = "/orders";

        public event PropertyChangedEventHandler? PropertyChanged;

        public  ObservableCollection<Orders> ? OrdersList {get; set; }
        public MainWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_ServiceUrl);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json;charset=UTF-8");
            //dgOrders.DataContext = this;
            OrdersList = new ObservableCollection<Orders>();
            PopulateOrders();    
        }
        public async void PopulateOrders()
        {
            using (HttpResponseMessage HttpResponseMessage = await httpClient.GetAsync(string.Concat(_ServiceUrl, OrdersEndPoint), HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
            {
                if (HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK) { 
                    using (HttpContent HttpContent = HttpResponseMessage.Content)
                    {
                        string MyContent = await HttpContent.ReadAsStringAsync();
                        OrdersList = JsonConvert.DeserializeObject<ObservableCollection<Orders>>(MyContent);
                        RaisePropertyChanged("OrdersList");
                    }
                }
                
            }
        }

        private void RaisePropertyChanged(string collectionName)
        {
            switch (collectionName)
            {
                case "OrdersList":
                    this.Dispatcher.Invoke(() =>
                    {
                        
                        dgOrders.ItemsSource = OrdersList;
                        
                    });

                    break;
            }
            
        }
    }
}
