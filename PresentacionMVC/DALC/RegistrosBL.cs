using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PresentacionMVC
{
    public class RegistrosBL
    {
        RegistrosDALC registrosDALC = new RegistrosDALC();

        //public List<Registros_InfecFallAlta_BE> InfectadosFallecidosRecuperados()
        //{
        //    return registrosDALC.InfectadosFallecidosRecuperados();
        //}

        public List<object> UltimaInformacion()
        {
            return registrosDALC.UltimaInformacion();
        }
        public List<object> Meses(int numAnio)
        {
            return registrosDALC.Meses(numAnio);
        }
        public List<object> Anios()
        {
            return registrosDALC.Anios();
        }
        public int UltimoAnioRegistrado()
        {
            return registrosDALC.UltimoAnioRegistrado();
        }
        public DataTable DT_InfectadosFallecidosRecuperado(int numAnio, int numMes)
        {
            return registrosDALC.DT_InfectadosFallecidosRecuperado(numAnio,numMes);
        }
        public DataTable DT_InfectadosXdia(int numAnio, int numMes)
        {
            return registrosDALC.DT_InfectadosXdia(numAnio,numMes);
        }
        public DataTable DT_Chart_Principal()
        {
            return registrosDALC.DT_Chart_Principal();
        }


        public DataTable DT_PruebasCasosActivos()
        {
            return registrosDALC.DT_PruebasCasosActivos();
        }
        public DataTable DT_ActivosHospiUCI()
        {
            return registrosDALC.DT_ActivosHospiUCI();
        }
        public List<RegistrosBE> ListadoGeneral()
        {
            return registrosDALC.ListadoGeneral();
        }
        public decimal PorcentajeMortalidad()
        {
            return registrosDALC.PorcentajeMortalidad();
        } 
        public decimal PorcentajeInfectados()
        {
            return registrosDALC.PorcentajeInfectados();
        }
        #region semanal
        public DataTable DT_InfectadosFallecidosRecuperado_Semanal(int numAnio)
        {
            return registrosDALC.DT_InfectadosFallecidosRecuperado_Semanal(numAnio);
        }
        #endregion
    }
}
