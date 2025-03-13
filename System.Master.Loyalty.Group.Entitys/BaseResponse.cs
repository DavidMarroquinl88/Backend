namespace System.Master.Loyalty.Group.Entities
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string MessageSuccess { get; set; } = string.Empty;
        public string MessageError { get; set; } = string.Empty;
    }
}
