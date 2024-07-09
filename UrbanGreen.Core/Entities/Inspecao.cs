using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace UrbanGreen.Core.Entities
{
    public class Inspecao
    {
        public int Id { get; set; }
        public DateTime Data = DateTime.Now;
        public bool SelecaoSemente { get; set; }
        public bool ControlePragas { get; set; }
        public bool Irrigacao { get; set; }
        public bool CuidadoSolo { get; set; }
        public bool Colheita { get; set; }

        public Inspecao() { }

        public Inspecao(DateTime data, bool selecaoSemente, bool controlePragas, bool irrigacao, bool cuidadoSolo, bool colheita)
        {
            Data = data;
            SelecaoSemente = selecaoSemente;
            ControlePragas = controlePragas;
            Irrigacao = irrigacao;
            CuidadoSolo = cuidadoSolo;
            Colheita = colheita;
        }

        public void Update(DateTime data, bool selecaoSemente, bool controlePragas, bool irrigacao, bool cuidadoSolo, bool colheita)
        {
            Data = data;
            SelecaoSemente = selecaoSemente;
            ControlePragas = controlePragas;
            Irrigacao = irrigacao;
            CuidadoSolo = cuidadoSolo;
            Colheita = colheita;
        }
    }
}
