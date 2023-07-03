using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using MudBlazorOnlineShop.Objects;

namespace MudBlazorOnlineShop.Interfaces
{
	public interface ICatalogCart
	{
		/// <summary>
		/// Retrieves a list of catalog products asynchronously.
		/// </summary>
		/// <param name="clock">The clock object used for time-related operations.</param>
		/// <returns>A task representing the asynchronous operation that returns a list of catalog products.</returns>
		Task<List<Product>> GetCatalogProductsAsync(IClock clock);

		/// <summary>
		/// Retrieves a list of cart products asynchronously.
		/// </summary>
		/// <param name="clock">The clock object used for time-related operations.</param>
		/// <returns>A task representing the asynchronous operation that returns a list of cart products.</returns>
		Task<List<Product>> GetCartProductsAsync(IClock clock);

		/// <summary>
		/// Retrieves a catalog product by its ID asynchronously.
		/// </summary>
		/// <param name="productId">The ID of the catalog product to retrieve.</param>
		/// <param name="clock">The clock object used for time-related operations.</param>
		/// <returns>A task representing the asynchronous operation that returns the catalog product.</returns>
		Task<Product> GetCatalogProductByIdAsync(Guid productId, IClock clock);

		/// <summary>
		/// Retrieves a cart product by its ID asynchronously.
		/// </summary>
		/// <param name="productId">The ID of the cart product to retrieve.</param>
		/// <param name="clock">The clock object used for time-related operations.</param>
		/// <returns>A task representing the asynchronous operation that returns the cart product.</returns>
		Task<Product> GetCartProductByIdAsync(Guid productId, IClock clock);

		/// <summary>
		/// Adds a product to the catalog asynchronously.
		/// </summary>
		/// <param name="product">The product to add to the catalog.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		Task AddProductToCatalog(Product product);

		/// <summary>
		/// Adds a product to the cart asynchronously.
		/// </summary>
		/// <param name="product">The product to add to the cart.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		Task AddProductToCart(Product product);

		/// <summary>
		/// Deletes a catalog product by its ID asynchronously.
		/// </summary>
		/// <param name="productId">The ID of the catalog product to delete.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		Task DeleteCatalogProductById(Guid productId);

		/// <summary>
		/// Deletes a cart product by its ID asynchronously.
		/// </summary>
		/// <param name="productId">The ID of the cart product to delete.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		Task DeleteCartProductById(Guid productId);

		/// <summary>
		/// Clears all catalog products asynchronously.
		/// </summary>
		/// <returns>A task representing the asynchronous operation.</returns>
		Task ClearCatalogProducts();

		/// <summary>
		/// Clears all cart products asynchronously.
		/// </summary>
		/// <returns>A task representing the asynchronous operation.</returns>
		Task ClearCartProducts();

		/// <summary>
		/// Updates a catalog product by its ID asynchronously.
		/// </summary>
		/// <param name="productId">The ID of the catalog product to update.</param>
		/// <param name="newProduct">The updated product information.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		Task UpdateCatalogProductById(Guid productId, Product newProduct);

		/// <summary>
		/// Updates a cart product by its ID asynchronously.
		/// </summary>
		/// <param name="productId">The ID of the cart product to update.</param>
		/// <param name="newProduct">The updated product information.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		Task UpdateCartProductById(Guid productId, Product newProduct);
	}
}
