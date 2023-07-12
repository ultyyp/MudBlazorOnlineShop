using Microsoft.AspNetCore.Components;
using OnlineShopFrontend.Interfaces;
using OnlineShopFrontend.Entities;

namespace OnlineShopFrontend.Pages
{
    public partial class Catalog
    {
		[Inject]
		IMyShopClient MyShopClient { get; set; }

		[Inject]
		NavigationManager NavigationManager { get; set; }

		private List<Product>? _products;
        protected override async Task OnInitializedAsync()
        {
            _products = await MyShopClient.GetProducts();
        }

        private Task OpenProductById(Product product)
        {
            NavigationManager.NavigateTo($"/productinfo/{product.Id}");
            return Task.CompletedTask;
        }

        private Task OpenAddProduct()
        {
			NavigationManager.NavigateTo($"/addproduct");
			return Task.CompletedTask;
        }
    }
}