using CheckIn.Domain.Model.Adm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Factories.Adm
{
    public interface IAdministrativoFactory
    {
        Administrativo Create(string ci, string nombres, string apellidos, string cargo);
    }
}
