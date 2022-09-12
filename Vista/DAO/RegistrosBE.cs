using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.DAO
{
    public class RegistrosBE
    {
        public int ID_REGISTRO { get; set; }
        public string FECHA { get; set; }
        public string INFECTADOS { get; set; }
        public string FALLECIDOS { get; set; }
        public string RECUPERADOS { get; set; }
        public string INFEC_X_DIA { get; set; }
        public string PRUEBAS { get; set; }
        public string CASOS_ACTIVOS { get; set; }
        public string HOSPITALIZADOS { get; set; }
        public string UCI { get; set; }
        public string TOTAL_CAMAS { get; set; }
        public string CAMAS_DISPONIBLES { get; set; }
    }
}
