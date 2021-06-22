using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_App.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC_App.Services
{
	public class ProductsService : IService<Products, int>
	{
		private readonly CitusTrainingContext ctx;

		/// <summary>
		/// Inject the CitusTrainingContext as ctor injection in the Service class
		/// </summary>
		public ProductsService(CitusTrainingContext c)
		{
			ctx = c;
		}


		public async Task<Products> CreateAsync(Products entity)
		{
			var res = await ctx.Products.AddAsync(entity);
			await ctx.SaveChangesAsync();
			return res.Entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var res = await ctx.Products.FindAsync(id);
			if (res == null) return false;
			return true;
		}

		public async Task<IEnumerable<Products>> GetAsync()
		{
			return await ctx.Products.ToListAsync();
		}

		public async Task<Products> GetAsync(int id)
		{
			var res = await ctx.Products.FindAsync(id);
			return res;
		}

		public async Task<Products> UpdateAsync(int id, Products entity)
		{
			var res = await ctx.Products.FindAsync(id);
			if (res == null) return res;

			ctx.Entry<Products>(entity).State = EntityState.Modified;
			await ctx.SaveChangesAsync();
			return entity;
		}
	}
}
