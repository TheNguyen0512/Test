using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test_2.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly CustomerDbContext _context;

		public CustomersController(CustomerDbContext context)
		{
			_context = context;
		}

		// GET: api/Customers
		/// <summary>
		/// Hàm C# này sử dụng Entity Framework để truy xuất danh sách khách hàng và trả về chúng dưới dạng một
		/// phản hồi, xử lý các ngoại lệ với một thông báo lỗi nếu cần.
		/// </summary>
		/// <returns>
		/// Phương thức GetCustomers trả về một ActionResult chứa một danh sách các đối tượng Khách hàng. Nếu
		/// thao tác thành công, nó trả về một phản hồi Ok với danh sách khách hàng. Nếu có ngoại lệ
		/// xảy ra trong quá trình thực hiện, nó trả về một phản hồi Lỗi Nội bộ 500 với thông báo lỗi.
		/// </returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
		{
			try
			{
				var customers = await _context.Customers.ToListAsync();
				return Ok(customers); 

			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers
		/// <summary>
		/// Hàm này lấy danh sách khách hàng dựa trên một truy vấn tìm kiếm, bằng ID hoặc tên, và
		/// trả về tất cả khách hàng nếu không có truy vấn được cung cấp.
		/// </summary>
		/// <param name="query">Đoạn mã bạn cung cấp là một điểm cuối GET trong một bộ điều khiển tìm kiếm
		/// khách hàng dựa trên một tham số truy vấn. Nếu có truy vấn được cung cấp, nó tìm kiếm khách hàng theo
		/// CustomerID, CompanyName, hoặc ContactName chứa chuỗi truy vấn. Nếu không có truy vấn được cung cấp,
		/// nó trả về tất cả khách hàng.</param>
		/// <returns>
		/// Đoạn mã cung cấp là một phương thức C# xử lý yêu cầu GET để tìm kiếm khách hàng dựa trên một tham số truy vấn.
		/// </returns>
		[HttpGet("Search")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSearch(string query)
		{
			try
			{
				if (!string.IsNullOrEmpty(query))
				{
					// Nếu có query được cung cấp, tìm khách hàng theo ID hoặc tên
					var customers = await _context.Customers
						.Where(c => c.CustomerID == query || EF.Functions.Like(c.CompanyName, $"%{query}%") || EF.Functions.Like(c.ContactName, $"%{query}%"))
						.ToListAsync();

					if (customers == null || !customers.Any())
					{
						return NotFound($"No customers found matching '{query}'.");
					}

					return Ok(customers);
				}
				else
				{
					// Nếu không có query được cung cấp, trả về tất cả khách hàng
					var customers = await _context.Customers.ToListAsync();
					return Ok(customers);
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}


		// GET: api/Customers/SortedByIdAsc
		/// <summary>
		/// Hàm C# này lấy danh sách khách hàng được sắp xếp theo CustomerID của họ theo thứ tự tăng dần.
		/// </summary>
		/// <returns>
		/// Mã này trả về một danh sách khách hàng được sắp xếp theo thứ tự tăng dần bởi CustomerID của họ. Nếu
		/// thao tác thành công, nó sẽ trả về một phản hồi Ok với danh sách khách hàng đã sắp xếp. Nếu có
		/// ngoại lệ xảy ra trong quá trình, nó sẽ trả về một phản hồi Lỗi Nội bộ 500 với thông báo lỗi.
		/// </returns>
		[HttpGet("SortedByCustomerIdAsc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByCustomersIdAscending()
		{
			try
			{
				var customers = await _context.Customers.OrderBy(c => c.CustomerID).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByIdDesc
		/// <summary>
		/// Hàm C# này lấy danh sách khách hàng được sắp xếp theo CustomerID của họ theo thứ tự giảm dần.
		/// </summary>
		/// <returns>
		/// Mã này trả về một danh sách khách hàng được sắp xếp theo thứ tự giảm dần bởi CustomerID của họ. Nếu
		/// thao tác thành công, nó sẽ trả về một phản hồi Ok với danh sách khách hàng đã sắp xếp. Nếu có
		/// ngoại lệ xảy ra trong quá trình, nó sẽ trả về một phản hồi Lỗi Nội bộ 500 với thông báo lỗi.
		/// </returns>
		[HttpGet("SortedByCustomerIdDesc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByCustomersIdDescending()
		{
			try
			{
				var customers = await _context.Customers.OrderByDescending(c => c.CustomerID).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByCompanyNameAsc
		[HttpGet("SortedByCompanyNameAsc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByCompanyNameAscending()
		{
			try
			{
				var customers = await _context.Customers.OrderBy(c => c.CompanyName).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByCompanyNameDesc
		[HttpGet("SortedByCompanyNameDesc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByCompanyNameDescending()
		{
			try
			{
				var customers = await _context.Customers.OrderByDescending(c => c.CompanyName).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByContactNameAsc
		[HttpGet("SortedByContactNameAsc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByContactNameAscending()
		{
			try
			{
				var customers = await _context.Customers.OrderBy(c => c.ContactName).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByContactNameDesc
		[HttpGet("SortedByContactNameDesc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByContactNameDescending()
		{
			try
			{
				var customers = await _context.Customers.OrderByDescending(c => c.ContactName).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByContactTitleAsc
		[HttpGet("SortedByContactTitleAsc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByContactTitleAscending()
		{
			try
			{
				var customers = await _context.Customers.OrderBy(c => c.ContactTitle).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByContactTitleDesc
		[HttpGet("SortedByContactTitleDesc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByContactTitleDescending()
		{
			try
			{
				var customers = await _context.Customers.OrderByDescending(c => c.ContactTitle).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByAddressAsc
		[HttpGet("SortedByAddressAsc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByAddressAscending()
		{
			try
			{
				var customers = await _context.Customers.OrderBy(c => c.Address).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByAddressDesc
		[HttpGet("SortedByAddressDesc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByAddressDescending()
		{
			try
			{
				var customers = await _context.Customers.OrderByDescending(c => c.Address).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByCityAsc
		[HttpGet("SortedByCityAsc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByCityAscending()
		{
			try
			{
				var customers = await _context.Customers.OrderBy(c => c.City).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByCityDesc
		[HttpGet("SortedByCityDesc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByCityDescending()
		{
			try
			{
				var customers = await _context.Customers.OrderByDescending(c => c.City).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByRegionAsc
		[HttpGet("SortedByRegionAsc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByRegionAscending()
		{
			try
			{
				var customers = await _context.Customers.OrderBy(c => c.Region).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByRegionDesc
		[HttpGet("SortedByRegionDesc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByRegionDescending()
		{
			try
			{
				var customers = await _context.Customers.OrderByDescending(c => c.Region).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByPostalCodeAsc
		[HttpGet("SortedByPostalCodeAsc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByPostalCodeAscending()
		{
			try
			{
				var customers = await _context.Customers.OrderBy(c => c.PostalCode).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByPostalCodeDesc
		[HttpGet("SortedByPostalCodeDesc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByPostalCodeDescending()
		{
			try
			{
				var customers = await _context.Customers.OrderByDescending(c => c.PostalCode).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByCountryAsc
		[HttpGet("SortedByCountryAsc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByCountryAscending()
		{
			try
			{
				var customers = await _context.Customers.OrderBy(c => c.Country).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByCountryDesc
		[HttpGet("SortedByCountryDesc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByCountryDescending()
		{
			try
			{
				var customers = await _context.Customers.OrderByDescending(c => c.Country).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByPhoneAsc
		[HttpGet("SortedByPhoneAsc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByPhoneAscending()
		{
			try
			{
				var customers = await _context.Customers.OrderBy(c => c.Phone).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByCountryDesc
		[HttpGet("SortedByPhoneDesc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByPhoneDescending()
		{
			try
			{
				var customers = await _context.Customers.OrderByDescending(c => c.Phone).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByFaxAsc
		[HttpGet("SortedByFaxAsc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByFaxAscending()
		{
			try
			{
				var customers = await _context.Customers.OrderBy(c => c.Fax).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		// GET: api/Customers/SortedByCountryDesc
		[HttpGet("SortedByFaxDesc")]
		public async Task<ActionResult<IEnumerable<Customer>>> GetSortedByFaxDescending()
		{
			try
			{
				var customers = await _context.Customers.OrderByDescending(c => c.Fax).ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
	}
}
