using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

namespace ApiLista.Models
{
    public class Alunos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public int Ra { get; set; }
        public List<Alunos> listaAlunos()
        {

            var caminho = HostingEnvironment.MapPath(@"~/App_Data\Base.json");

            var json = File.ReadAllText(caminho);

            var listaAlunos = JsonConvert.DeserializeObject<List<Alunos>>(json);

            return listaAlunos;
        }
    }
}