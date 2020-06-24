namespace Reduct
{
	public class ResponseFactory
	{
		public static Response Create(bool result, object value) =>
			new Response()
			{
				Result = result,
				Value  = value
			};
	}

	public class Response
	{
		public bool Result { get; set; }
		
		public object Value { get; set; }
	}
}