namespace GrTechTest.Business.Utils
{
    public class ResponseMessage
    {
        public bool Success { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}