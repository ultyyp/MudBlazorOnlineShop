using Microsoft.AspNetCore.Components;
using MudBlazorOnlineShop.Objects;

namespace MudBlazorOnlineShop.Pages
{
    public partial class Catalog
    {
        private List<Product>? _products;
        protected override async Task OnInitializedAsync()
        {
            _products = await _catalogCart.GetCatalogProductsAsync(_clock);
        }

        private Task OpenProductById(Product product)
        {
            NavigationManager.NavigateTo($"/productinfo/catalog/{product.Id.ToString()}");
            return Task.CompletedTask;
        }

        private Task OpenAddProduct()
        {
			NavigationManager.NavigateTo($"/addproduct");
			return Task.CompletedTask;
        }
    }
}