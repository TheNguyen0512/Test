using System;

namespace TFU.Common.Models
{
	public class PagingModel
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public string Keyword { get; set; }
		public string OrderBy { get; set; }
		public string OrderDirection { get; set; }
		[OutputParam]
		public int TotalRecord { get; set; }
		public int TotalPages => (int)Math.Ceiling(TotalRecord * 1f / PageSize);
		public string CreatedBy { get; set; }

		public static PagingModel Default = new PagingModel()
		{
			PageNumber = 1,
			PageSize = 10
		};
	}
}
