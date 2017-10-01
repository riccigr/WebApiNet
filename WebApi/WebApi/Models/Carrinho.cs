using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace LojaWebApi.Models
{
    public class Carrinho
    {
        public List<Produto> Produtos { get; set; }
        public string Endereco { get; set; }
        public long Id { get; set; }

        public Carrinho()
        {
            this.Produtos = new List<Produto>();
        }

        public void Adiciona(Produto produto)
        {
            this.Produtos.Add(produto);
        }
        
        public void Remove(long Id)
        {
            Produto produto = Produtos.FirstOrDefault(p => p.Id == Id);
            this.Produtos.Remove(produto);  
        }

        public void Troca(Produto produto)
        {
            Remove(produto.Id);
            Adiciona(produto);
        }

        public void TrocaEndereco(string endereco)
        {
            this.Endereco = endereco;
        }
        public string ToXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Carrinho));
            StringWriter strWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(strWriter))
            {
                xmlSerializer.Serialize(writer, this);
                return strWriter.ToString();
            }
        }

    }
}