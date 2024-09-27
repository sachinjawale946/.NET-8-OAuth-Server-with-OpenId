namespace Net8_OAuthWithOpenId.Models
{
    public class CheckClientResult
    {
        public Client Client { get; set; }
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public string ErrorDescription { get; set; }
    }
}
