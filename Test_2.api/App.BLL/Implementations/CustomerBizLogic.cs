using App.BLL.Interface;
using App.DAL.Interface;
using App.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Implementations
{
	public class CustomerBizLogic : ICustomerBizLogic
	{
		private readonly ICustomerRepository _customerRepository;
		public CustomerBizLogic(ICustomerRepository customerRepository)
		{

			_customerRepository = customerRepository;

		}

		public async Task<List<CustomerModel>> GetAllCustomer()
		{
			var data = await _customerRepository.GetAllCustomer();
			return data?.Select(x => new CustomerModel(x)).ToList();
		}
	}
}
