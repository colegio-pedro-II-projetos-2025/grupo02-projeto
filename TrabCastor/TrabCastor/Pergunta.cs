using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabCastor
{
    internal class Pergunta
    {
        public int Id_Pergunta { get; set; }
        public string Dificuldade { get; set; }
        public string Questao { get; set; }
        public string Resposta_Certa { get; set; }
        public int Valor {  get; set; }
    }
}
