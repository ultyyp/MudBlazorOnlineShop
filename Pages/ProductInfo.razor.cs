using Microsoft.AspNetCore.Components;
using MudBlazorOnlineShop.Interfaces;
using MudBlazorOnlineShop.Objects;

namespace MudBlazorOnlineShop.Pages
{

    public partial class ProductInfo
    {
        [Inject]
        ICatalogCart CatalogCart { get; set; }

        [Inject]
        IClock Clock { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

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
				_product = await CatalogCart.GetCatalogProductByIdAsync(ProductId, Clock);
                ButtonText = "Add To Cart";
			}
            else if(OpenedFrom == "cart")
            {
				_product = await CatalogCart.GetCartProductByIdAsync(ProductId, Clock);
				ButtonText = "Remove From Cart";
			}
        }

		private Task ManageProduct()
		{
			if (OpenedFrom == "catalog")
			{
                CatalogCart.AddProductToCart(_product);
                CatalogCart.DeleteCatalogProductById(_product.Id);
				NavigationManager.NavigateTo($"/catalog");
			}
			else if (OpenedFrom == "cart")
			{
                CatalogCart.DeleteCartProductById(_product.Id);
				CatalogCart.AddProductToCatalog(_product);
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