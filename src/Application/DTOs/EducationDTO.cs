namespace Application.DTOs
{
    public class EducationDTO
    {
        public Guid Id { get; set; }
        public required string Degree { get; set; }

        public required string FieldOfStudy { get; set; }

        public required string School { get; set; }

        public required string StartYear { get; set; }

        public required string EndYear { get; set; }

        public string? Description { get; set; }
    }
}
