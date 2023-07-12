using Microsoft.AspNetCore.Components;
using OnlineShopFrontend.Interfaces;
using OnlineShopFrontend.Entities;

namespace OnlineShopFrontend.Pages
{

    public partial class ProductInfo
    {
        [Inject]
        IMyShopClient MyShopClient { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Guid ProductId { get; set; }

        [Parameter]
        public string OpenedFrom { get; set; }

        private Product _product { get; set; }

		protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _product = await MyShopClient.GetProduct(ProductId);
        }

		private Task ReturnToLastPage()
        {
			NavigationManager.NavigateTo($"/catalog");
			return Task.CompletedTask;
		}
    }
}