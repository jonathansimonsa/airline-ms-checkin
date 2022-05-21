using CheckIn.Domain.Model.Adm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Factories.Adm
{
    public class AdministrativoFactory : IAdministrativoFactory
    {
        public Administrativo Create(string ci, string nombres, string apellidos, string cargo)
        {
            return new Administrativo(ci, nombres, apellidos, cargo);
        }
    }
}
