using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;

namespace App.Entity.Models
{
	public class CustomerModel : IEntity<CustomerDTO>
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

		public CustomerModel() { }

		public CustomerModel(CustomerDTO dto)
		{
			CustomerID = dto.CustomerID;
			CompanyName = dto.CompanyName;
			ContactName = dto.ContactName;
			ContactTitle = dto.ContactTitle;
			Address = dto.Address;
			City = dto.City;
			Region = dto.Region;
			PostalCode = dto.PostalCode;
			Country = dto.Country;
			Phone = dto.Phone;
			Fax = dto.Fax;
		}

		public CustomerDTO GetEntity()
		{ return new CustomerDTO { CustomerID = CustomerID, CompanyName = CompanyName, ContactName = ContactName, ContactTitle = ContactTitle, Address = Address, City = City, Region = Region, PostalCode = PostalCode, Country = Country, Phone = Phone, Fax = Fax };}
	}
}
