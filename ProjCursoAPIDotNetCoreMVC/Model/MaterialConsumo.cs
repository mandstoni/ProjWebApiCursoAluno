using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoWebCoreMVC.Models
{
    public class MaterialConsumo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QtdProduto { get; set; }
        public Enfermeiro Enfermeiro { get; set; }


    }
}
