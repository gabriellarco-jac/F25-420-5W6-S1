using Microsoft.AspNetCore.Identity;

namespace Dutch_Treat.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public int Age { get; set; }
    }
}
