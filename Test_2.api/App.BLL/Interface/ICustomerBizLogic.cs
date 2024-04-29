using App.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Interface
{
	public interface ICustomerBizLogic
	{
		Task<bool> CreateUpdateCustomer(CustomersModel model);
		Task<List<CustomersModel>> GetAllCustomer();
	}
}

