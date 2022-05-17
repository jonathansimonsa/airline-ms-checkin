using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Model
{
    public class Administrativo : Entity<Guid>
    {
        public string Ci { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cargo { get; set; }

        public Administrativo()
        {
        }

        public Administrativo(string ci, string nombres, string apellidos, string cargo)
        {
            Id = Guid.NewGuid();
            Ci = ci;
            Nombres = nombres;
            Apellidos = apellidos;
            Cargo = cargo;
        }
    }
}
