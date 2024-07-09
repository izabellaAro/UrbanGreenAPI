using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanGreen.Application.Models.Inspecao
{
    public class ReadInspecaoDto
    {
        public int Id { get; set; }
        public DateTime Data = DateTime.Now;
        public bool SelecaoSemente { get; set; }
        public bool ControlePragas { get; set; }
        public bool Irrigacao { get; set; }
        public bool CuidadoSolo { get; set; }
        public bool Colheita { get; set; }
    }
}
