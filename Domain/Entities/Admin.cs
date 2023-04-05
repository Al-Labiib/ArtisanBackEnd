namespace ArtisanBackEnd.Domain.Entities
{
    public class Admin : BaseEntity
    {
        public int UserId {get; set;}
        public User User {get; set;}

    }
}