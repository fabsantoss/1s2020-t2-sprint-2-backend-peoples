using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionariosDomain> Listar();

        void Cadastrar(FuncionariosDomain funcionario);

        void AtualizarIdCorpo(FuncionariosDomain funcionario);

        void AtualizarIdUrl(int id, FuncionariosDomain funcionario);

        void Deletar(int id);

        FuncionariosDomain BuscarPorId(int id);
    }
}
