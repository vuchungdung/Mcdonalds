using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Areas.Admin.Models
{
    public class AuthenViewModel
    {
        public AuthenViewModel(int id, string fullname, string username, string image, string token)
        {
            Id = id;
            FullName = fullname;
            UserName = username;
            Image = image;
            Token = token;
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
        public string Token { get; set; }

        //public string RefreshToken { get; set; }
    }
}
