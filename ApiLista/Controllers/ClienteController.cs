using ApiLista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiLista.Controllers
{
   
    public class ClienteController : ApiController
    {
        Clientes cli = new Clientes();
        // GET: api/Cliente
        public IEnumerable<Clientes> Get()
        {
            return cli.ListarClientes(); ;
        }

        // GET: api/Cliente/5
        public Clientes Get(int id)
        {
            
            return cli.ListarClientes().Where(c => c.id == id).FirstOrDefault();
        }

        // POST: api/Cliente
        public List<Clientes> Post(Clientes clientes)
        {
            
            cli.Inserir(clientes);

            return cli.ListarClientes();
        }

        // PUT: api/Cliente/5
        public void Put(int id, [FromBody]Clientes clientes)
        {
            cli.Atualizar(id,clientes);

            
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
            cli.Deletar(id);
        }
    }
}
