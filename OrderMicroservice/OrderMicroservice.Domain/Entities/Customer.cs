namespace OrderMicroservice.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        // Basic info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string ProfilePic { get; set; }
        public string UserId { get; set; } // e.g., link to Identity

        // Navigation
        public ICollection<Address> Addresses { get; set; }
    }
}