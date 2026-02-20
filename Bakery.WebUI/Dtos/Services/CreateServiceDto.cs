namespace Bakery.WebUI.Dtos.Services
{
    public class CreateServiceDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ServiceName { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ServiceIconUrl { get; set; }
    }
}
