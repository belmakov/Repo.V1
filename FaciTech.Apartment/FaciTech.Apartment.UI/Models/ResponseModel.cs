namespace FaciTech.Apartment.UI.Models
{
    public class ResponseModel
    {
        public ResponseModel(ResponseStatus status, string message = "", object data = null)
        {
            Status = (status == ResponseStatus.Error ? "Error" : "Success");
            Message = message;
            Data = data;
        }
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
   
    public enum ResponseStatus
    {
        Success,
        Error
    }
}
