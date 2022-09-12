using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Presentacion.DAO
{
    public class RegistrosBL
    {
        RegistrosDALC registrosDALC = new RegistrosDALC();

        //public List<Registros_InfecFallAlta_BE> InfectadosFallecidosRecuperados()
        //{
        //    return registrosDALC.InfectadosFallecidosRecuperados();
        //}
        public DataSet DT_InfectadosFallecidosRecuperado()
        {
            return registrosDALC.DT_InfectadosFallecidosRecuperado();
        }
        public DataSet DT_InfectadosXdia()
        {
            return registrosDALC.DT_InfectadosXdia();
        }
        public DataSet DT_PruebasCasosActivos()
        {
            return registrosDALC.DT_PruebasCasosActivos();
        }
        public DataSet DT_ActivosHospiUCI()
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
    }
}
