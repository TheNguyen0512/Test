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
	}
}
