using System.Net;

namespace TalentAcademy.Application.Features
{
    public class GeneralResponse
    {
        public HttpStatusCode Status { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public object? Result { get; set; }
    }
}
