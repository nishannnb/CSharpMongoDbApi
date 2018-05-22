using CSharpMongoDbApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpMongoDbApi.IServices
{
	public interface IProductService
	{

		Task<List<Product>> GetAllProducts();
		//Task<Product> GetProductById(int id);
		//Task<bool> SaveProduct(Product product);
		//Task<bool> SaveProducts(List<Product> products);
		//Task<bool> UpdateProduct(Product product);
		//Task<bool> UpdateProducts(List<Product> products);
		//Task<bool> DeleteProduct(int product);
		//Task<bool> DeleteProducts();

	}
}
