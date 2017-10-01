using LojaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWebApi.DAO
{
    public class CarrinhoDAO
    {
        private static Dictionary<long, Carrinho> bd = new Dictionary<long, Carrinho>();
        private static long contador = 1;

        static CarrinhoDAO()
        {
            Produto camiseta = new Produto(1234, 50, "Camiseta", 2);
            Produto jogo = new Produto(1565, 200, "Jogo", 1);

            Carrinho carrinho = new Carrinho();
            carrinho.Adiciona(camiseta);
            carrinho.Adiciona(jogo);
            carrinho.Endereco = "Avenida Paulista, 1000, SP";
            carrinho.Id = 1;

            bd.Add(1, carrinho);
        }

        public void Adiciona(Carrinho carrinho)
        {
            contador++;
            carrinho.Id = contador;
            bd.Add(contador, carrinho);
        }

        public Carrinho Busca(long id)
        {
            return bd[id];
        }

        public void Remove(long id)
        {
            bd.Remove(id);
        }

    }
}