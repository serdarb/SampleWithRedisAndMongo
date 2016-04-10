namespace Project.WebClient.ViewModels
{
    public class PersonViewModel : BaseModel
    {
        public string UId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }        
    }
}