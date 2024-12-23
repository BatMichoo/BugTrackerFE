using System.Net;

namespace Core.Models
{
    public class ApiResponseModel<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public T? Resource { get; set; } 
    }
}
