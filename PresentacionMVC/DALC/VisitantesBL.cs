using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace PresentacionMVC.DALC
{
    public class VisitantesBL
    {
        VisitantesDALC visitantesDALC = new VisitantesDALC();
        public bool AgregarVisitante(VisitantesBE visitanteBE)
        {
            return visitantesDALC.AgregarVisitante(visitanteBE);
        }
    }
}