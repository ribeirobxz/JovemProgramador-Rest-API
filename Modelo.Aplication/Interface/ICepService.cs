using Modelo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Aplication.Interface
{
    public interface ICepService
    {
        Task<Endereco?> BuscarfEnderecoPorCep(string cep);
    }
}
