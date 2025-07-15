namespace DotNetWebAPI.Model
{
    public class OurHero
    {
        public int Id { get; set; } 
        public required string FirstName { get; set; }
        public required string LastName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

    }
}
