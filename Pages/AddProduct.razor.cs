using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazorOnlineShop;
using MudBlazorOnlineShop.Shared;
using MudBlazorOnlineShop.Services;
using MudBlazorOnlineShop.Components;
using MudBlazorOnlineShop.Interfaces;
using MudBlazorOnlineShop.Objects;

namespace MudBlazorOnlineShop.Pages
{
    public partial class AddProduct
    {
        private string Name { get; set; }
        private string Description { get; set; }
        private decimal Price { get; set; }
        private DateTime ProducedAt { get; set; }
        private DateTime ExpiredAt { get; set; }
        private double Stock { get; set; }

        private Task AddProductToCatalog()
        {
            var Product = new Product(Name, Description, Price, ProducedAt, ExpiredAt, Stock);
            _catalogCart.AddProductToCatalog(Product);
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