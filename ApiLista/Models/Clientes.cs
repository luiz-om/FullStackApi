using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace ApiLista.Models
{
    public class Clientes
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int ra { get; set; }
        public List<Clientes> ListarClientes()
        {
            var caminho = HostingEnvironment.MapPath(@"~/App_Data\cliente.json");

            var json = File.ReadAllText(caminho);

            var listaAlunos = JsonConvert.DeserializeObject<List<Clientes>>(json);

            return listaAlunos;
        }
        public bool ReescreverArquivo(List<Clientes> listaclientes)
        {
            var caminho = HostingEnvironment.MapPath(@"~/App_Data\cliente.json");
            var json = JsonConvert.SerializeObject(listaclientes, Formatting.Indented);
            File.WriteAllText(caminho, json);
            return true;
        }

        public Clientes Inserir(Clientes clientes)
        {
            var listaClientes = clientes.ListarClientes();
            var maxId = listaClientes.Max(cliente => cliente.id);
            clientes.id = maxId + 1;
            listaClientes.Add(clientes);

            ReescreverArquivo(listaClientes);
            return clientes;
        }

        public Clientes Atualizar(int id, Clientes clientes)
        {
            var listaClientes = this.ListarClientes();
            var itemIndex = listaClientes.FindIndex(cliente => cliente.id == id);

            if (itemIndex >= 0)
            {
                clientes.id = id;
                listaClientes[itemIndex] = clientes;
            }
            else
            {
                return null;
            }

            ReescreverArquivo(listaClientes);

            return clientes;
        }
        public bool Deletar(int id)
        {
            var listaClientes = this.ListarClientes();

            var itemIndex = listaClientes.FindIndex(cliente => cliente.id == id);
            if (itemIndex >=0)
            {
                listaClientes.RemoveAt(itemIndex);

            }
            else
            {
                return false;
            }
            ReescreverArquivo(listaClientes);
            return true;
        }
    }
}