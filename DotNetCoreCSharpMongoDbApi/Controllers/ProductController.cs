using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreCSharpMongoDbApi.IServices;
using DotNetCoreCSharpMongoDbApi.Model;
using DotNetCoreCSharpMongoDbApi;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCSharpMongoDbApi.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService = null;


		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		[Route("api/Product")]
		public string ProductApi()
		{
			return "Product Api Working";
		}

		[HttpGet]
		[Route("api/Product/GetAllProducts")]
		public async Task<List<Product>> GetAllProducts()
		{
			return await _productService.GetAllProducts();
		}

		[HttpGet]
		[Route("api/Product/GetProductById/{id}")]
		public async Task<Product> GetProductById(int id)
		{
			return await _productService.GetProductById(id);
		}

		[HttpPost]
		[Route("api/Product/SaveProduct")]
		public async Task<bool> SaveProduct([FromBody]Product product)
		{
			var result = await _productService.InsertOneProduct(product);
			if (result)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		[HttpPut]
		[Route("api/Product/UpdateProduct")]
		public async Task<bool> UpdateProduct([FromBody]Product product)
		{
			if (product == null)
			{
				return false;
			}

			var result = await _productService.UpdateOneProduct(product);
			if (result)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		[HttpDelete]
		[Route("api/Product/DeleteProduct/{id}")]
		public async Task<bool> DeleteProduct(int id)
		{
			var result = await _productService.DeleteOneProduct(id);
			if (result)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


	}
}
