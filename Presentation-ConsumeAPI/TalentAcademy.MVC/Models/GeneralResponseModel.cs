using System.Net;

namespace TalentAcademy.MVC.Models
{
    public class GeneralResponseModel
    {
        public HttpStatusCode Status { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public object? Result { get; set; }
    }
}
