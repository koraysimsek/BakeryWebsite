namespace Bakery.WebUI.Dtos.Services
{
    public class UpdateServiceDto
    {
        public int serviceId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string serviceName { get; set; }
        public string serviceDescription { get; set; }
        public string serviceIconUrl { get; set; }
        public string imageUrl { get; set; }
    }
}
