using Microsoft.AspNetCore.Components;
using MudBlazorOnlineShop.Interfaces;
using MudBlazorOnlineShop.Objects;

namespace MudBlazorOnlineShop.Pages
{
    public partial class Catalog
    {
        [Inject]
        ICatalogCart CatalogCart { get; set; }

        [Inject]
        IClock Clock { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        private List<Product>? _products;
        protected override async Task OnInitializedAsync()
        {
            _products = await CatalogCart.GetCatalogProductsAsync(Clock);
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