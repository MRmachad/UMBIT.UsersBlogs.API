﻿using System;
using UMBIT.Core.Repositorio.BaseEntity;

namespace UMBIT.UsersBlogs.Dominio.Entidades
{
    public class Blog : CoreBaseEntity
    {
        public int UserId { get; set; }

        public string Title { get; set; }

        public string ContentText { get; set; }

        public string PhotoUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public string ContentHtml { get; set; }

        public string Category { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
