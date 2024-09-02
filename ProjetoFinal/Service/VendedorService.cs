using ProjetoFinal.Dao.Domain;
using ProjetoFinal.Dao.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Service
{
    public class VendedorService
    {
        private readonly VendedorRepository vendedorRepository = new VendedorRepository();
        
        public List<Vendedor> Pesquisa(int? codigo, string nome)
        {
            return vendedorRepository.Pesquisa(codigo, nome);
        }

        public Vendedor BuscaPorCodigo(int codigo)
        {
            return vendedorRepository.BuscaPorCodigo(codigo);
        }

        public void Salvar(Vendedor vendedor)
        {
            vendedorRepository.Salvar(vendedor);
        }

        public void Editar(Vendedor vendedor)
        {
            vendedorRepository.Editar(vendedor);
        }
    }
}