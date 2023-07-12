using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShopFrontend.Entities;

namespace OnlineShopFrontend.Interfaces
{
	public interface ICatalog
	{
		/// <summary>
		/// Retrieves a list of catalog products asynchronously.
		/// </summary>
		/// <param name="clock">The clock object used for time-related operations.</param>
		/// <returns>A task representing the asynchronous operation that returns a list of catalog products.</returns>
		Task<List<OldProduct>> GetProductsAsync(IClock clock);

		/// <summary>
		/// Retrieves a catalog product by its ID asynchronously.
		/// </summary>
		/// <param name="productId">The ID of the catalog product to retrieve.</param>
		/// <param name="clock">The clock object used for time-related operations.</param>
		/// <returns>A task representing the asynchronous operation that returns the catalog product.</returns>
		Task<OldProduct> GetProductByIdAsync(Guid productId, IClock clock);

		/// <summary>
		/// Adds a product to the catalog asynchronously.
		/// </summary>
		/// <param name="product">The product to add to the catalog.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		Task AddProduct(OldProduct product);

		/// <summary>
		/// Deletes a catalog product by its ID asynchronously.
		/// </summary>
		/// <param name="productId">The ID of the catalog product to delete.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		Task DeleteProductById(Guid productId);

		/// <summary>
		/// Clears all catalog products asynchronously.
		/// </summary>
		/// <returns>A task representing the asynchronous operation.</returns>
		Task ClearProducts();

		/// <summary>
		/// Updates a catalog product by its ID asynchronously.
		/// </summary>
		/// <param name="productId">The ID of the catalog product to update.</param>
		/// <param name="newProduct">The updated product information.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		Task UpdateProductById(Guid productId, OldProduct newProduct);

		
	}
}
