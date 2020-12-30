using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string IdNumber { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string HomeAddress { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Zip { get; set; }
        public string CellNo { get; set; }
    }
}
