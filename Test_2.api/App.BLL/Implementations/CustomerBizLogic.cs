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

		public async Task<bool> CreateUpdateCustomer(CustomersModel model)
		{
			var dto = model.GetEntity();
			return await _customerRepository.CreateUpdateCustomer(dto);
		}

		public async Task<List<CustomersModel>> GetAllCustomer()
		{
			var data = await _customerRepository.GetAllCustomer();
			return data.Select(x => new CustomersModel(x)).ToList();
		}
	}
}
