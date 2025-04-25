namespace RO.DevTest.Application.Features.Product.Response
{
    public class ProductResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ProductResponse(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
