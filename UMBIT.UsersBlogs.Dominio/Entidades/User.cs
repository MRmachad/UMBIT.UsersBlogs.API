using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UMBIT.UsersBlogs.Dominio.Entidades
{
    public class User
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Job { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }
        public double Latitude { get; set; }
        public string ProfilePicture { get; set; }
        public string Email { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }

        public string Street { get; set; }
        public string State { get; set; }

        public string Country { get; set; }
        public double Longitude { get; set; }
    }


}
