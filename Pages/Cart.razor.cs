using Microsoft.AspNetCore.Components;
using MudBlazorOnlineShop.Objects;

namespace MudBlazorOnlineShop.Pages
{
    public partial class Cart
    {
        private List<Product>? _products;
        protected override async Task OnInitializedAsync()
        {
            _products = await _catalogCart.GetCartProductsAsync(_clock);
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
                    await _catalogCart.DeleteCartProductById(product.Id);
                    await _catalogCart.AddProductToCatalog(product);
                    _products = await _catalogCart.GetCartProductsAsync(_clock);
				}
            }
			NavigationManager.NavigateTo($"/cart");
		}
    }
}