using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWebApi.Models
{
    public class Produto
    {

        public long Id { get; set; }
        public double Preco { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        public Produto() { }

        public Produto(long id, double preco, string nome, int quantidade)
        {
            Id = id;
            Preco = preco;
            Nome = nome;
            Quantidade = quantidade;
        }

        public void trocaNome(string nome)
        {
            this.Nome = nome;
        }
    }
}