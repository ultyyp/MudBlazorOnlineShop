using Microsoft.AspNetCore.Components;
using MudBlazorOnlineShop.Interfaces;
using MudBlazorOnlineShop.Objects;

namespace MudBlazorOnlineShop.Pages
{
    public partial class Cart
    {

        private List<Product>? _products;
        protected override async Task OnInitializedAsync()
        {
            _products = await CatalogCart.GetCartProductsAsync(Clock);
        }

        private Task OpenProductById(Product product)
        {
            NavigationManager.NavigateTo($"/productinfo/cart/{product.Id.ToString()}");
            return Task.CompletedTask;
        }

        private async Task ClearCart()
        {
            if( _products != null && _products.Count > 0)
            {
                foreach(var product in _products)
                {
                    await CatalogCart.DeleteCartProductById(product.Id);
                    await CatalogCart.AddProductToCatalog(product);
                    _products = await CatalogCart.GetCartProductsAsync(Clock);
				}
            }
			NavigationManager.NavigateTo($"/cart");
		}
    }
}