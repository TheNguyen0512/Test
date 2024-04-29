using App.BLL.Interface;
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

		[HttpGet("get-all-customer")]
		public async Task<ActionResult> GetAllDeviceType()
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
