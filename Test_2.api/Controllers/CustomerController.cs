using App.BLL.Interface;
using App.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using TFU.APIBased;

namespace Test_2.api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : BaseAPIController
	{
		private readonly ILogger<CustomerController> _logger;
		private readonly ICustomerBizLogic _customerBizLogic;

		public CustomerController(ILogger<CustomerController> logger, ICustomerBizLogic customerBizLogic)
		{
			this._logger = logger;
			this._customerBizLogic = customerBizLogic;
		}

		[HttpPost("create-update-customer")]
		public async Task<ActionResult> CreateUpdateCustomer([FromBody] CustomersModel model)
		{
			try
			{
				if (!ModelState.IsValid) return SaveError();
				var result = await _customerBizLogic.CreateUpdateCustomer(model);
				return SaveSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("CreateUpdateCustomer: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError();
			}
		}

		[HttpGet("get-all-customer")]
		public async Task<ActionResult> GetAllCustomer()
		{
			try
			{
				var data = await _customerBizLogic.GetAllCustomer();
				return GetSuccess(data);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllCustomer: {0} {1}", ex.Message, ex.StackTrace);
				return GetError();
			}
		}
	}
}
