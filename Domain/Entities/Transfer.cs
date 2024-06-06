using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transfer
    {
        [Key]
        public int Id { get; set; }
        public string? Fecha { get; set; }
        public string? Cantidad { get; set; }
        public string? Descripcion { get; set; }
        public string? Tipo { get; set; }
    }
}
