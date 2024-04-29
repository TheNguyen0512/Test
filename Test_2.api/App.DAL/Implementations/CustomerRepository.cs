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
		public async Task<List<CustomerDTO>> GetAllCustomer()
		{
			return await _dbAppContext.Customer.ToListAsync();
		}
	}

}
