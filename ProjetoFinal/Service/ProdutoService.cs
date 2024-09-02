using ProjetoFinal.Dao.Domain;
using ProjetoFinal.Dao.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Service
{
    public class ProdutoService
    {

        private readonly ProdutoRepository produtoRepository = new ProdutoRepository();

        public List<Produto> Pesquisa(int? codigo, string nome)
        {
            return produtoRepository.Pesquisa(codigo, nome);
        }

        public Produto BuscaPorCodigo(int codigo)
        {
            return produtoRepository.BuscaPorCodigo(codigo);
        }

        public void Salvar(Produto produto)
        {
            produtoRepository.Salvar(produto);
        }

        public void Editar(Produto produto)
        {
            produtoRepository.Editar(produto);
        }
    }
}