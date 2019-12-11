using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public List<Alunos> ListarAlunos()
        {

            var caminho = HostingEnvironment.MapPath(@"~/App_Data\Aluno.json");

            var json = File.ReadAllText(caminho);

            var listaAlunos = JsonConvert.DeserializeObject<List<Alunos>>(json);

            return listaAlunos;
        }

        public bool ReescreverArquivo(List<Alunos> listaAlunos)
        {
            var caminho = HostingEnvironment.MapPath(@"~/App_Data\Aluno.json");
            var json = JsonConvert.SerializeObject(listaAlunos, Formatting.Indented);

            File.WriteAllText(caminho, json);

            return true;

        }

        public Alunos Inserir(Alunos alunos)
        {
            var listaAlunos = alunos.ListarAlunos();
            var maxId = listaAlunos.Max(aluno => aluno.Id);
            alunos.Id = maxId + 1;
            listaAlunos.Add(alunos);

            ReescreverArquivo(listaAlunos);
            return alunos;
        }

        public Alunos Atualizar(int id, Alunos alunos)
        {
            var listaAlunos = alunos.ListarAlunos();
            var itemIndex = listaAlunos.FindIndex(aluno => aluno.Id == id);

            if (itemIndex >= 0)
            {
                alunos.Id = id;
                listaAlunos[itemIndex] = alunos;
            }
            else
            {
                return null;
            }
            ReescreverArquivo(listaAlunos);

            return alunos;
        }

        public bool Deletar(int id)
        {
            var listaAlunos = this.ListarAlunos();
            var itemIndex = listaAlunos.FindIndex(aluno => aluno.Id == id);
                if (itemIndex >= 0)
            {
                listaAlunos.RemoveAt(itemIndex);

            }
            else
            {
                return false;
            }
            ReescreverArquivo(listaAlunos);
            return true;
        }

    }
}