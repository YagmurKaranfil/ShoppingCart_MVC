using Microsoft.AspNetCore.Identity;

namespace ShoppingCart.Models
{
    public class AppUser: IdentityUser
    {
        //Meslek
        public string Occupation { get; set; }
    }
}
