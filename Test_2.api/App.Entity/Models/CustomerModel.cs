using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;

namespace App.Entity.Models
{
	public class CustomersModel : IEntity<CustomersDTO>
	{
		public string CustomerID { get; set; }
		public string CompanyName { get; set; }
		public string ContactName { get; set; }
		public string ContactTitle { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Region { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
		public string Phone { get; set; }
		public string Fax { get; set; }

		public CustomersModel() { }

		public CustomersModel(CustomersDTO dto)
		{
			CustomerID = dto.CustomerID;
			CompanyName = dto.CompanyName;
			ContactName = dto.ContactName ?? string.Empty;
			ContactTitle = dto.ContactTitle ?? string.Empty;
			Address = dto.Address ?? string.Empty;
			City = dto.City ?? string.Empty;
			Region = dto.Region ?? string.Empty;
			PostalCode = dto.PostalCode ?? string.Empty;
			Country = dto.Country ?? string.Empty;
			Phone = dto.Phone ?? string.Empty;
			Fax = dto.Fax ?? string.Empty;
		}


		public CustomersDTO GetEntity()
		{
			return new CustomersDTO { CustomerID = CustomerID, CompanyName = CompanyName, ContactName = ContactName, ContactTitle = ContactTitle, Address = Address, City = City, Region = Region, PostalCode = PostalCode, Country = Country, Phone = Phone, Fax = Fax };
		}
	}
}
