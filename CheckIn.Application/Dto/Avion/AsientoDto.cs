using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.Dto.Avion
{
    public class AsientoDto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public int Fila { get; set; }
        public string Letra { get; set; }
        public int EsPrioridad { get; set; }

        public AsientoDto()
        { }
    }
}
