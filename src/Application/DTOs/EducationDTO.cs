namespace Application.DTOs
{
    public class EducationDTO
    {
        public Guid Id { get; set; }
        public string Degree { get; set; }

        public string FieldOfStudy { get; set; }

        public string School { get; set; }

        public string StartYear { get; set; }

        public string EndYear { get; set; }

        public string Description { get; set; }
    }
}
