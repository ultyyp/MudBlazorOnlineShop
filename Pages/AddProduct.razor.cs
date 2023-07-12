using Microsoft.AspNetCore.Components;
using OnlineShopFrontend.Interfaces;
using OnlineShopFrontend.Entities;

namespace OnlineShopFrontend.Pages
{
    public partial class AddProduct
    {
		[Inject]
		IMyShopClient MyShopClient { get; set; }

		[Inject]
		NavigationManager NavigationManager { get; set; }

		private string Name { get; set; }
        private decimal Price { get; set; }

        private async Task AddProductToCatalog()
        {
            var Product = new Product();

			Product.Id = Guid.NewGuid();
			Product.Name = Name;
            Product.Price = Price;
            
            await MyShopClient.AddProduct(Product);
            NavigationManager.NavigateTo("/catalog");
        }

        private Task BackToCatalog()
        {
            NavigationManager.NavigateTo("/catalog");
            return Task.CompletedTask;
        }
    }
}