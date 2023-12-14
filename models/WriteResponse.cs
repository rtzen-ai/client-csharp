using System;
namespace RtzenAPIs.models
{
	public class WriteResponse<T>
	{
		public T Object { get; set; }
		public ErrorResult Error { get; set; }

		public class ErrorResult
		{
			public int StatusCode { get; set; }
			public List<ErrorField> ErrorFields { get; set; }
			public bool Ephemeral { get; set; }

		}

		public class ErrorField
		{
			public string Field { get; set; }
			public string Code { get; set; }
			public string Message { get; set; }
			public bool Recoverable { get; set; }
		}
	}



}

