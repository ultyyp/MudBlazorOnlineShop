
using Microsoft.AspNetCore.Components;
using MudBlazorOnlineShop.Interfaces;
using MudBlazorOnlineShop.Objects;

namespace MudBlazorOnlineShop.Pages
{
    public partial class AddProduct
    {
        [Inject]
        ICatalogCart CatalogCart { get; set; }

        [Inject] 
        NavigationManager NavigationManager { get; set; }


        private string Name { get; set; }
        private string Description { get; set; }
        private decimal Price { get; set; }
        private DateTime ProducedAt { get; set; }
        private DateTime ExpiredAt { get; set; }
        private double Stock { get; set; }

        private Task AddProductToCatalog()
        {
            var Product = new Product(Name, Description, Price, ProducedAt, ExpiredAt, Stock);
            CatalogCart.AddProductToCatalog(Product);
            NavigationManager.NavigateTo("/catalog");
            return Task.CompletedTask;
        }

        private Task BackToCatalog()
        {
            NavigationManager.NavigateTo("/catalog");
            return Task.CompletedTask;
        }
    }
}