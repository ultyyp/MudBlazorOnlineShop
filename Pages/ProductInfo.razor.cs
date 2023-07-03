using Microsoft.AspNetCore.Components;
using MudBlazorOnlineShop.Objects;

namespace MudBlazorOnlineShop.Pages
{
    public partial class ProductInfo
    {
        [Parameter]
        public Guid ProductId { get; set; }

        [Parameter]
        public string OpenedFrom { get; set; }

        private Product _product { get; set; }

        private string ButtonText;

		protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if(OpenedFrom == "catalog")
            {
				_product = await _catalogCart.GetCatalogProductByIdAsync(ProductId, _clock);
                ButtonText = "Add To Cart";
			}
            else if(OpenedFrom == "cart")
            {
				_product = await _catalogCart.GetCartProductByIdAsync(ProductId, _clock);
				ButtonText = "Remove From Cart";
			}
        }

		private Task ManageProduct()
		{
			if (OpenedFrom == "catalog")
			{
                _catalogCart.AddProductToCart(_product);
                _catalogCart.DeleteCatalogProductById(_product.Id);
				NavigationManager.NavigateTo($"/catalog");
			}
			else if (OpenedFrom == "cart")
			{
                _catalogCart.DeleteCartProductById(_product.Id);
				_catalogCart.AddProductToCatalog(_product);
				NavigationManager.NavigateTo($"/cart");
			}
            return Task.CompletedTask;
		}

		private Task ReturnToLastPage()
        {
            if (OpenedFrom == "catalog")
            {
                NavigationManager.NavigateTo($"/catalog");
            }
            else if (OpenedFrom == "cart")
            {
                NavigationManager.NavigateTo($"/cart");
            }
            return Task.CompletedTask;
        }
    }
}