namespace RO.DevTest.Application.Features.Client.Response
{
    public class ClientResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ClientResponse(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
