using ApiLista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiLista.Controllers
{
    public class AlunoController : ApiController
    {
        // GET: api/Aluno
        public IEnumerable<Alunos> Get()
        {
            Alunos aluno = new Alunos();
            return aluno.listaAlunos();
        }

        // GET: api/Aluno/5
        public Alunos Get(int id)
        {
            var aluno = new Alunos();
            return aluno.listaAlunos().Where(a => a.Id ==id).FirstOrDefault();
        }

        // POST: api/Aluno
        public List<Clientes> Post(Clientes clientes)
        {
            List<Clientes> cliente = new List<Clientes>();
            cliente.Add(clientes);

            return cliente;
        }

        // PUT: api/Aluno/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Aluno/5
        public void Delete(int id)
        {
        }
    }
}
