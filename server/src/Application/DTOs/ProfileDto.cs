namespace Application.DTOs
{
    public class ProfileDto
    {
        public Guid Id { get; set; }

        public required string FirstName { get; set; }
               
        public required string LastName { get; set; }
               
        public required string Email { get; set; }
               
        public required string Headline { get; set; }
               
        public required string About { get; set; }

        public byte[]? Photo { get; set; }
    }
}
