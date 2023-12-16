using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMBIT.Core.Repositorio.BaseEntity
{
    public abstract class CoreBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdKey { get; set; } 
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get;set; }
    }
}
