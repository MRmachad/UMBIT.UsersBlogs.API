using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UMBIT.UsersBlogs.Dominio.Entidades;

namespace UMBIT.UsersBlogs.Dominio.Facade.slingacademy.Entidades
{
    public class UserListSlingAcademy
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("total_users")]
        public int TotalUsers { get; set; }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("users")]
        public List<UserSlingAcademy> Users { get; set; }
    }

}
