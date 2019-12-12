using ApiLista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiLista.Controllers
{
    [EnableCors("*", "*", "*", "*")]
    public class AlunoController : ApiController
    {
        Alunos aluno = new Alunos();
        // GET: api/Aluno
        public IEnumerable<Alunos> Get()
        {
           
            return aluno.ListarAlunos();
        }

        // GET: api/Aluno/5
        public Alunos Get(int id)
        {
            var aluno = new Alunos();
            return aluno.ListarAlunos().Where(a => a.Id ==id).FirstOrDefault();
        }

        // POST: api/Aluno
        public List<Alunos> Post(Alunos alunos)
        {

            aluno.Inserir(alunos);

            return aluno.ListarAlunos();
        }

        // PUT: api/Aluno/5
        public void Put(int id, [FromBody]Alunos alunos)
        {

            aluno.Atualizar(id, alunos);

        }

        // DELETE: api/Aluno/5
        public void Delete(int id)
        {
            aluno.Deletar(id);
        }
    }
}
