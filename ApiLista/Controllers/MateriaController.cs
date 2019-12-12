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
  
    public class MateriaController : ApiController
    {
        Materias ma = new Materias();
       // GET: api/Materia
        public IEnumerable<string> Get()
        {
            return ma.listaMaterias();
        }

        // GET: api/Materia/5
        public string Get(int id)
        {
            return "";
        }

        // POST: api/Materia
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Materia/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Materia/5
        public void Delete(int id)
        {
        }
    }
}
