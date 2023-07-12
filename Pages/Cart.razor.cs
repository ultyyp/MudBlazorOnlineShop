using Microsoft.AspNetCore.Components;
using OnlineShopFrontend.Interfaces;
using OnlineShopFrontend.Entities;

namespace OnlineShopFrontend.Pages
{
    public partial class Cart
    {
		[Inject]
		ICatalog Catalog { get; set; }

		[Inject]
		IClock Clock { get; set; }

		[Inject]
		NavigationManager NavigationManager { get; set; }

		private List<OldProduct>? _products;
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }   
    }
}