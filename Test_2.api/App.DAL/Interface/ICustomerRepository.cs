using App.Entity.DTO;
using App.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Interface
{
	public interface ICustomerRepository
	{
		Task<bool> CreateUpdateCustomer(CustomersDTO dto);
		Task<List<CustomersDTO>> GetAllCustomer();
	}
}
