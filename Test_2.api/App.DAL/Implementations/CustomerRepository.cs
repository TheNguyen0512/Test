using App.DAL.Interface;
using App.Entity.DTO;
using App.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.DAL;
using TFU.EntityFramework;

namespace App.DAL.Implementations
{
	public class CustomerRepository : AppBaseRepository, ICustomerRepository
	{
		private readonly ApplicationDbContext _dbAppContext;
		public CustomerRepository(IConfiguration config, TFUDbContext dbTFUContext, ApplicationDbContext dbAppContext) : base(config, dbTFUContext, dbAppContext)
		{
			_dbAppContext = dbAppContext;
		}

		public async Task<bool> CreateUpdateCustomer(CustomersDTO dto)
		{
			var anyDTO = await _dbAppContext.Customers.AnyAsync(x => x.CustomerID == dto.CustomerID);
			if (anyDTO)
			{
				_dbAppContext.Customers.Update(dto);
			}
			else
			{
				_dbAppContext.Customers.Add(dto);
			}
			return await _dbAppContext.SaveChangesAsync() > 0;
		}

		public async Task<List<CustomersDTO>> GetAllCustomer()
		{
			return await _dbAppContext.Customers.ToListAsync();
		}
	}

}
