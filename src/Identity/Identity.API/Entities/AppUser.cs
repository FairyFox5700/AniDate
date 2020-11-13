using System;
using Microsoft.AspNetCore.Identity;

namespace Identity.API.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public DateTime BirthDate { get; set; }
        public string AboutMe { get; set; }
        public bool IsMail { get; set; }
        public int ImageId { get; set; }
        //pets but no list to access!!!!!
    }
}