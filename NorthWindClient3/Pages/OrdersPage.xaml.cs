using Domain.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;

namespace NorthWindClient3.Pages;

public partial class OrdersPage : ContentPage
{
	private string endpoint = "";
	private List<Orders> orders = new List<Orders>();

    public OrdersPage()
	{
		InitializeComponent();
        //BindingContext = new MainViewModel();
        GetOrders();
	}

	public async Task GetOrders()
	{
        var client = new HttpClient();
		 orders = await client.GetFromJsonAsync<List<Orders>>(endpoint);
    }
}