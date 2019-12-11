using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiLista.Models
{
    public class Materias
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Horas { get; set; }
        

        public List<String> listaMaterias()
        {
            List<String> listaMaterias = new List<string>();
            
                listaMaterias.Add("Portugues");
                listaMaterias.Add("Ingles");
                listaMaterias.Add("Matematica");
                listaMaterias.Add("Geogradia");
            


            return listaMaterias;
        }

    }
}