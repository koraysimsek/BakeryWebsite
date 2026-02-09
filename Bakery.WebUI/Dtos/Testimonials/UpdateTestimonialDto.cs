namespace Bakery.WebUI.Dtos.Testimonials
{
    public class UpdateTestimonialDto
    {
        public int testimonialId { get; set; }
        public string nameSurname { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
    }
}
