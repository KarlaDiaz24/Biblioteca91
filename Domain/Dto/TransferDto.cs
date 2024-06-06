using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class TransferDto
    {
        public string? Fecha { get; set; }
        public string? Cantidad { get; set; }
        public string? Descripcion { get; set; }
        public string? Tipo { get; set; }
    }
}
