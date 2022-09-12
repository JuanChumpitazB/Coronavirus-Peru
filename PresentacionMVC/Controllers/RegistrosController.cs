using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using Newtonsoft;
using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.Globalization;
using PresentacionMVC.DALC;
using System.Net;
using System.Collections;

namespace PresentacionMVC.Controllers
{
    public class RegistrosController : Controller
    {
        // GET: Registros
        RegistrosBE registrosBE = new RegistrosBE();
        VisitantesBE visitanteBE = new VisitantesBE();
        RegistrosBL registrosBL = new RegistrosBL();
        VisitantesBL visitantesBL = new VisitantesBL();
        bool G1_btn1 = true;
        bool G2_btn1 = true;

        //[Route("Registros/Inicio")]
        public ActionResult Index()
        {
            //Ultima Informacion
            var ultimaInformacion = registrosBL.UltimaInformacion();
            ViewBag.UltimaInformacion = ultimaInformacion;

            var anios = registrosBL.Anios();
            ViewBag.Anios = anios;

            int ultimoAnioRegistrado = registrosBL.UltimoAnioRegistrado();
            var meses = registrosBL.Meses(ultimoAnioRegistrado);
            ViewBag.Meses = meses;

            GrabarVisitante();

            return View();

        }
        public JsonResult JsonMesesXanio(int anio)
        {
            var meses = registrosBL.Meses(anio);
            
            return Json(meses, JsonRequestBehavior.AllowGet);
        }
        protected void GrabarVisitante()
        {
            // Grabar visitante
            string hostName = Dns.GetHostName();
            IPHostEntry ipList = new IPHostEntry();
            ipList = Dns.GetHostEntry(hostName);

            string ip = Convert.ToString(ipList.AddressList[ipList.AddressList.Length - 1]);

            //String ipDetrasProxy = Request.UserHostAddress;
            string ipDetrasProxy = "";
            if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                ipDetrasProxy = Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (Request.UserHostAddress.Length != 0)
            {
                ipDetrasProxy = Request.UserHostAddress;
            }
            

            visitanteBE = new VisitantesBE();
            visitanteBE.IP = (ip!=""?ip:"");
            visitanteBE.AHOSTNAME = (hostName != ""?hostName:"");
            visitanteBE.IP_DETRAS_PROXY = (ipDetrasProxy != "" ? ipDetrasProxy:"");

            DateTime diaHoy = new DateTime();
            diaHoy = DateTime.Now;
            string fecha = string.Format("{0}-{1}-{2}", diaHoy.Year, diaHoy.Month, diaHoy.Day);
            string hora = string.Format("{0}:{1}:{2}", diaHoy.Hour, diaHoy.Minute, diaHoy.Second);
            visitanteBE.FECHA = fecha;
            visitanteBE.HORA = hora;
            visitantesBL.AgregarVisitante(visitanteBE);
        }
        #region G_1  
        /*
        ==============================================================================================
                                                 G_1
        ============================================================================================== 
        */
        public JsonResult JsonInfectados(int numAnio,int numMes)
        {
            DataTable dt = registrosBL.DT_InfectadosFallecidosRecuperado(numAnio,numMes);
            List<object> iData = new List<object>();
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            return Json(iData, JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult JsonInfectadosXdia(int numAnio, int numMes)
        {
            DataTable dt = registrosBL.DT_InfectadosXdia(numAnio,numMes);
            List<object> iData = new List<object>();
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            return Json(iData, JsonRequestBehavior.AllowGet);
        }
        /*
       ==============================================================================================
                                                G_2
       ============================================================================================== 
       */
        public JsonResult JsonChartPrincipal()
        {
            DataTable dt = registrosBL.DT_Chart_Principal();
            List<object> iData = new List<object>();
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        /*
       ==============================================================================================
                                                G_3
       ============================================================================================== 
       */


        public JsonResult JsonInfectadosSemanal(int numAnio)
        {
            DataTable dt = registrosBL.DT_InfectadosFallecidosRecuperado_Semanal(numAnio);
            List<object> iData = new List<object>();
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            return Json(iData, JsonRequestBehavior.AllowGet);
        }
        
        #endregion

        #region Porcentajes
        public ActionResult JsonPorcentajeInfectados()
        {
            decimal porcentajeInfectados = registrosBL.PorcentajeInfectados();
            
            return Json(porcentajeInfectados.ToString(),JsonRequestBehavior.AllowGet);
        }
        public ActionResult JsonPorcentajeMortalidad()
        {
            decimal porcentajeMortalidad = registrosBL.PorcentajeMortalidad();

            return Json(porcentajeMortalidad.ToString(), JsonRequestBehavior.AllowGet);
        }
        #endregion




        #region Metodos de aspx
        public ActionResult CharG1()
        {
            var data = registrosBL.ListadoGeneral().ToList();
            var chart = new Chart();
            //chart.Width = 1600;
            var area = new ChartArea();
            chart.ChartAreas.Add(area);
            var series = new Series();
            foreach (var item in data)
            {
                series.Points.AddXY(item.INFECTADOS, item.FALLECIDOS, item.RECUPERADOS);
            }
            series.Label = "#VAL";
            series.Font = new Font("Arial", 8.0f, FontStyle.Bold);
            series.ChartType = SeriesChartType.Column;
            series["PieLabelStyle"] = "Outside";
            chart.Series.Add(series);
            var returnStream = new MemoryStream();
            chart.ImageType = ChartImageType.Png;
            chart.SaveImage(returnStream);
            returnStream.Position = 0;
            //returnStream.SetLength(1600);
            return new FileStreamResult(returnStream, "image/png");
        }
        void Chart1_Propiedades_Infectados(Chart Chart_G1)
        {
            RemoverSeries(Chart_G1);

            Chart_G1.Width = 4600;

            Chart_G1.Series.Add("Infectados");
            Chart_G1.Series.Add("Fallecidos");
            Chart_G1.Series.Add("Recuperados");

            Chart_G1.Series["Infectados"].XValueMember = "0";
            Chart_G1.Series["Fallecidos"].XValueMember = "0";
            Chart_G1.Series["Recuperados"].XValueMember = "0";

            Chart_G1.Series["Infectados"].YValueMembers = "1";
            Chart_G1.Series["Fallecidos"].YValueMembers = "2";
            Chart_G1.Series["Recuperados"].YValueMembers = "3";

            Chart_G1.Series["Infectados"].Color = Color.Orange;
            Chart_G1.Series["Fallecidos"].Color = Color.Red;
            Chart_G1.Series["Recuperados"].Color = Color.Green;

            Chart_G1.Series["Infectados"].YValuesPerPoint = 4;
            Chart_G1.Series["Fallecidos"].YValuesPerPoint = 4;
            Chart_G1.Series["Recuperados"].YValuesPerPoint = 4;

            Chart_G1.ChartAreas.Add("ChartArea1");
            Chart_G1.ChartAreas["ChartArea1"].Position = new ElementPosition(0, 6, 100, 96);

            //--
            Chart_G1.Series[0].IsValueShownAsLabel = true;
            Chart_G1.Series[0].LabelBackColor = System.Drawing.Color.DarkOrange;
            Chart_G1.Series[1].IsValueShownAsLabel = true;
            Chart_G1.Series[1].LabelBackColor = System.Drawing.Color.Red;
            Chart_G1.Series[1].LabelForeColor = System.Drawing.Color.White;
            Chart_G1.Series[2].IsValueShownAsLabel = true;
            Chart_G1.Series[2].LabelBackColor = System.Drawing.Color.Green;
            Chart_G1.Series[2].LabelForeColor = System.Drawing.Color.White;
            Chart_G1.Series[0].BorderWidth = 2;
            Chart_G1.Series[1].BorderWidth = 2;
            Chart_G1.Series[2].BorderWidth = 2;
            Chart_G1.ChartAreas[0].AxisX.Interval = 1;
            Chart_G1.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb(240, 240, 240); // Fondo del Grafico (rojo,verde,azul)

            var legent = Chart_G1.Legends.Add("Infectados");

            //  horizontal ->  ----  vertical ---- 
            Chart_G1.Legends["Infectados"].Position = new ElementPosition(0, 1, 16, 6);
            Chart_G1.Legends["Infectados"].Font = new Font("Arial", 8, FontStyle.Bold);

            Chart_G1.Series[0].ToolTip = "#VAL";
            Chart_G1.Series[1].ToolTip = "#VAL";
            Chart_G1.Series[2].ToolTip = "#VAL";
        }
        void RemoverSeries(Chart charID)
        {
            if (charID.Series.Count() > 0)
            {
                for (int x = 0; x <= charID.Series.Count(); x++)
                {
                    charID.Series.Remove(charID.Series[x]);
                }
            }
            if (charID.ChartAreas.Count() > 0)
            {
                for (int x = 0; x <= charID.ChartAreas.Count(); x++)
                {
                    charID.ChartAreas.Remove(charID.ChartAreas[x]);
                }
            }
            if (charID.Legends.Count() > 0)
            {
                for (int x = 0; x <= charID.Legends.Count(); x++)
                {
                    charID.Legends.Remove(charID.Legends[x]);
                }
            }
        }
        #endregion
    }
}