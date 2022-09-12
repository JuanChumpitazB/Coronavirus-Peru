using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentacionMVC.DALC
{
    public class VisitantesBE
    {
        public int ID { get; set; }
        public string IP { get; set; }
        public string AHOSTNAME { get; set; }
        public string IP_DETRAS_PROXY { get; set; }
        public string FECHA { get; set; }
        public string HORA { get; set; }
    }
}