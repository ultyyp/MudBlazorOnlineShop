using MudBlazorOnlineShop.Interfaces;
using MudBlazorOnlineShop.Objects;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MudBlazorOnlineShop.Services
{
    /// <summary>
    /// Represents a catalog and a cart of products in an online shop.
    /// </summary>
    public class InMemoryCatalog : ICatalogCart
    {
        private ConcurrentDictionary<Guid, Product> _products = GenerateProducts(20);

		private ConcurrentDictionary<Guid, Product> _cart = new();

		/// <summary>
		/// Gets all the products in the catalog.
		/// </summary>
		/// <returns>A concurrent dictionary containing the products.</returns>
		public async Task<List<Product>> GetCatalogProductsAsync(IClock clock)
        {
            if (clock.GetLocalDate().DayOfWeek == DayOfWeek.Monday)
            {
                List<Product> newProducts = new List<Product>(_products.Values.ToList().Count);
                _products.Values.ToList().ForEach((item) =>
                {
                    var newItem = (Product)item.Clone();
                    newItem.Price *= (decimal)0.70;
                    newProducts.Add(newItem);
                });
                return newProducts;
            }
            else
            {
                return _products.Values.ToList();
            }
        }

		/// <summary>
		/// Gets all the products in the cart.
		/// </summary>
		/// <returns>A concurrent dictionary containing the products.</returns>
		public async Task<List<Product>> GetCartProductsAsync(IClock clock)
		{
			if (clock.GetLocalDate().DayOfWeek == DayOfWeek.Monday)
			{
				List<Product> newProducts = new List<Product>(_cart.Values.ToList().Count);
				_cart.Values.ToList().ForEach((item) =>
				{
					var newItem = (Product)item.Clone();
					newItem.Price *= (decimal)0.70;
					newProducts.Add(newItem);
				});
				return newProducts;
			}
			else
			{
				return _cart.Values.ToList();
			}
		}

		/// <summary>
		/// Gets a product from the catalog by its ID.
		/// </summary>
		/// <param name="productId">The ID of the product.</param>
		/// <returns>The product with the specified ID.</returns>
		public async Task<Product> GetCatalogProductByIdAsync(Guid productId, IClock clock)
        {
            if (!_products.TryGetValue(productId, out var product))
            {
                throw new KeyNotFoundException($"Key '{productId}' not found in the dictionary.");
            }
            else
            {
                if (clock.GetLocalDate().DayOfWeek == DayOfWeek.Monday)
                {
                    var newProduct = (Product)product.Clone();
                    newProduct.Price *= (decimal)0.70;
                    return newProduct;
                }
                else
                {
                    return product;
                }
            }
        }

		/// <summary>
		/// Gets a product from the cart by its ID.
		/// </summary>
		/// <param name="productId">The ID of the product.</param>
		/// <returns>The product with the specified ID.</returns>
		public async Task<Product> GetCartProductByIdAsync(Guid productId, IClock clock)
		{
			if (!_cart.TryGetValue(productId, out var product))
			{
				throw new KeyNotFoundException($"Key '{productId}' not found in the dictionary.");
			}
			else
			{
				if (clock.GetLocalDate().DayOfWeek == DayOfWeek.Monday)
				{
					var newProduct = (Product)product.Clone();
					newProduct.Price *= (decimal)0.70;
					return newProduct;
				}
				else
				{
					return product;
				}
			}
		}

		/// <summary>
		/// Adds a new product to the catalog.
		/// </summary>
		/// <param name="product">The product to be added.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		public Task AddProductToCatalog(Product product)
        {
            if (!_products.TryAdd(product.Id, product))
            {
                throw new ArgumentException("Product already exists in the dictionary.", nameof(product));
            };
            return Task.CompletedTask;
        }

		/// <summary>
		/// Adds a new product to the cart.
		/// </summary>
		/// <param name="product">The product to be added.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		public Task AddProductToCart(Product product)
		{
			if (!_cart.TryAdd(product.Id, product))
			{
				throw new ArgumentException("Product already exists in the dictionary.", nameof(product));
			};
			return Task.CompletedTask;
		}

		/// <summary>
		/// Deletes a product from the catalog by its ID.
		/// </summary>
		/// <param name="productId">The ID of the product to be deleted.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		public Task DeleteCatalogProductById(Guid productId)
        {
            if (!_products.TryRemove(productId, out _))
            {
                throw new InvalidOperationException("Product not found in the dictionary.");
            }
            return Task.CompletedTask;
        }

		/// <summary>
		/// Deletes a product from the cart by its ID.
		/// </summary>
		/// <param name="productId">The ID of the product to be deleted.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		public Task DeleteCartProductById(Guid productId)
		{
			if (!_cart.TryRemove(productId, out _))
			{
				throw new InvalidOperationException("Product not found in the dictionary.");
			}
			return Task.CompletedTask;
		}

		/// <summary>
		/// Clears all products from the catalog.
		/// </summary>
		/// <returns>A task that represents the asynchronous operation.</returns>
		public Task ClearCatalogProducts()
        {
            _products.Clear();
            return Task.CompletedTask;
        }

		/// <summary>
		/// Clears all products from the cart.
		/// </summary>
		/// <returns>A task that represents the asynchronous operation.</returns>
		public Task ClearCartProducts()
		{
			_cart.Clear();
			return Task.CompletedTask;
		}

		/// <summary>
		/// Updates a product in the catalog by its ID.
		/// </summary>
		/// <param name="productId">The ID of the product to be updated.</param>
		/// <param name="newProduct">The updated product information.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		public Task UpdateCatalogProductById(Guid productId, Product newProduct)
        {
            if (!_products.TryGetValue(productId, out var oldProductValue))
            {
                throw new KeyNotFoundException($"Key '{newProduct.Id}' not found in the dictionary.");
            }

            if (_products.TryUpdate(newProduct.Id, newProduct, oldProductValue))
            {
                throw new InvalidOperationException("Update operation failed.");
            }
            return Task.CompletedTask;
        }

		/// <summary>
		/// Updates a product in the cart by its ID.
		/// </summary>
		/// <param name="productId">The ID of the product to be updated.</param>
		/// <param name="newProduct">The updated product information.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		public Task UpdateCartProductById(Guid productId, Product newProduct)
		{
			if (!_cart.TryGetValue(productId, out var oldProductValue))
			{
				throw new KeyNotFoundException($"Key '{newProduct.Id}' not found in the dictionary.");
			}

			if (_cart.TryUpdate(newProduct.Id, newProduct, oldProductValue))
			{
				throw new InvalidOperationException("Update operation failed.");
			}
			return Task.CompletedTask;
		}


		/// <summary>
		/// Generates products for the list.
		/// </summary>
		/// <param name="count">The ammount of products we want to generate.</param>
		/// /// <returns>A concurrent discitionnary containing the products.</returns>
		private static ConcurrentDictionary<Guid, Product> GenerateProducts(int count)
        {
            /// <summary> Array of product names. </summary>
            var productNames = new string[]
            {
                "Milk",
                "Bread",
                "Apples",
                "Bananas",
                "Cheese",
                "Eggs",
                "Tomatoes",
                "Potatoes",
                "Chicken",
                "Beef",
                "Pork",
                "Rice",
                "Pasta",
                "Biscuits",
                "Yogurt",
                "Oranges",
                "Cucumbers",
                "Onions",
                "Carrots",
                "Spinach",
                "Salmon",
                "Lettuce",
                "Strawberries",
                "Watermelon",
                "Coffee",
                "Tea",
                "Sugar",
                "Salt",
                "Pepper",
                "Olive Oil"
            };

            //Check that the count is less than the amount of available products
            if (count > productNames.Length)
            {
                throw new ArgumentOutOfRangeException($"Amount of generated products exceeded available product names.");
            }


            var random = new Random();
            var products = new ConcurrentDictionary<Guid, Product>();

            for (int i = 0; i < count; i++)
            {
                var name = productNames[i];
                var price = random.Next(50, 500);
                var producedAt = DateTime.Now.AddDays(-random.Next(1, 30));
                var expiredAt = producedAt.AddDays(random.Next(1, 365));
                var stock = random.NextDouble() * 100;

                var product = new Product(name, price);
                product.Description = "Description " + name;
                product.ProducedAt = producedAt;
                product.ExpiredAt = expiredAt;
                product.Stock = stock;
                products.TryAdd(product.Id, product);
            }

            return products;
        }


    }
}
