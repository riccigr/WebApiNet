using LojaWebApi.DAO;
using LojaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CarrinhoController : ApiController
    {
        public HttpResponseMessage Get(long id)
        {
            try
            {
                CarrinhoDAO dao = new CarrinhoDAO();
                Carrinho carrinho = dao.Busca(id);
                return  Request.CreateResponse(HttpStatusCode.OK, carrinho);
            }
            catch (KeyNotFoundException ex)
            {
                string messagem = string.Format("O carrinho {0} nao foi encontrado.", id);
                HttpError error = new HttpError(messagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
            catch (Exception ex)
            {
                string messagem = string.Format("Tivemos um problema. Contate o time de suporte");
                HttpError error = new HttpError(messagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }

        public HttpResponseMessage Post([FromBody]Carrinho carrinho)
        {
            CarrinhoDAO dao = new CarrinhoDAO();
            dao.Adiciona(carrinho);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

            string location = Url.Link("DefaultApi", new { controller = "carrinho", id = carrinho.Id });
            response.Headers.Location = new Uri(location);
            
            return response;
        }
    }
}
