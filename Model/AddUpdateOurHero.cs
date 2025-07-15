namespace DotNetWebAPI.Model
{
    public class AddUpdateOurHero
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; } = string.Empty;   
        public bool isActive {  get; set; } = true;    
    }
}
