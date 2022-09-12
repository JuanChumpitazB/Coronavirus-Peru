using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Web.SessionState;
using Presentacion.DAO;

namespace Presentacion
{
    public partial class CoronavirusPeru : System.Web.UI.Page
    {

        RegistrosBE registrosBE = new RegistrosBE();
        //Registros_InfecFallAlta_BE registros_InfecFallAlta_BE = new Registros_InfecFallAlta_BE();
        RegistrosBL registrosBL = new RegistrosBL();
        bool G1_btn1 = true;
        bool G2_btn1 = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                CargasIniciales();
            }


        }

        /*============================= CARGAS INICIALES ===================================*/
        private void CargasIniciales()
        {
            MostrarTabla_IngecFallAlta();
            //rbtInfectados.Checked = true;
            G_MostrarInfectados();
            lblMortalidad.Text = registrosBL.PorcentajeMortalidad().ToString() + "%";
            lblIndectados.Text = registrosBL.PorcentajeInfectados().ToString() + "%";
            //rbtPruebas.Checked = true;
            G_MostrarPruebas();
            Session["G1_btn1"] = "true";
            Session["G2_btn1"] = "true";
        }
        /*============================= TABLAS ===================================*/
        public void MostrarTabla_IngecFallAlta()
        {
            ////Tabla
            //List<Registros_InfecFallAlta_BE> lista = registrosBL.InfectadosFallecidosRecuperados();
            ////GridView1.DataSource = lista;
            ////GridView1.DataBind();

        }
        /*============================= PROPIEDADES DE GRAFICO ===================================*/
        public void Grafico1_Propiedades()
        {
            //List<Registros_InfecFallAlta_BE> lista = registrosBL.InfectadosFallecidosRecuperados();


            //if (rbtInfectados.Checked)
            //{
            //    var listaNueva = from i in lista
            //                     select new { i.FECHA, i.INFECTADOS };

            //    Chart1.DataSource = listaNueva;
            //    Chart1.DataBind();
            //}
            //else if (rbtRecuperados.Checked)
            //{
            //    var listaNueva = from i in lista
            //                     select new { i.FECHA, i.RECUPERADOS };

            //    Chart1.DataSource = listaNueva;
            //    Chart1.DataBind();
            //}
            //else if (rbtTodo.Checked)
            //{
            //    DataTable dt = ConvertListToDataTable(lista);
            //    Chart1.DataSource = dt;
            //    Chart1.DataBind();
            //}
            //else
            //{
            //    DataTable dt = ConvertListToDataTable(lista);
            //    Chart1.DataSource = dt;
            //    Chart1.DataBind();
            //}


            //// Grafico
            //DataTable dt = ConvertListToDataTable(lista);
            //Chart1.DataSource = dt;
            //Chart1.DataBind();

            //Chart1.BackColor = System.Drawing.Color.White;
            //Chart1.BackSecondaryColor = System.Drawing.Color.White;
            Chart_G1.Series[0].IsValueShownAsLabel = true;
            Chart_G1.Series[1].IsValueShownAsLabel = true;
            Chart_G1.Series[2].IsValueShownAsLabel = true;
            Chart_G1.Series[0].BorderWidth = 2;
            Chart_G1.Series[1].BorderWidth = 2;
            Chart_G1.Series[2].BorderWidth = 2;
            Chart_G1.ChartAreas[0].AxisX.Interval = 1;
            //Chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            Chart_G1.ChartAreas[0].BackColor = System.Drawing.Color.White;
            //Chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            //Chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.White;

            //Chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
            //Chart1.ChartAreas[0].AxisY.Interval = 2500;

            var legent = Chart_G1.Legends.Add("Infectados");
            //legent.Position.Width = 100;

            Chart_G1.Series[0].ToolTip = "#VAL";
            Chart_G1.Series[1].ToolTip = "#VAL";
            Chart_G1.Series[2].ToolTip = "#VAL";

            //Chart1.ChartAreas[0].AxisY.lab
        }



        void Chart1_Propiedades_Infectados()
        {
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
        void Chart1_Propiedades_InfectadosXdia()
        {
            Chart_G1.Series.Add("Infectados");

            Chart_G1.Series["Infectados"].XValueMember = "0";

            Chart_G1.Series["Infectados"].YValueMembers = "1";

            Chart_G1.Series["Infectados"].Color = Color.Blue;

            Chart_G1.Series["Infectados"].YValuesPerPoint = 4;

            Chart_G1.ChartAreas.Add("ChartArea1");
            Chart_G1.ChartAreas["ChartArea1"].Position = new ElementPosition(0, 6, 100, 96);

            //--
            Chart_G1.Series[0].IsValueShownAsLabel = true;
            Chart_G1.Series[0].LabelBackColor = System.Drawing.Color.SkyBlue;
            Chart_G1.Series[0].BorderWidth = 1;
            Chart_G1.ChartAreas[0].AxisX.Interval = 1;
            Chart_G1.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb(240, 240, 240); // Fondo del Grafico (rojo,verde,azul)

            var legent = Chart_G1.Legends.Add("Infectados");
            //  horizontal ->  ----  vertical ---- 
            Chart_G1.Legends["Infectados"].Position = new ElementPosition(0, 1, 16, 6);
            Chart_G1.Legends["Infectados"].Font = new Font("Arial", 8, FontStyle.Bold);

            Chart_G1.Series[0].ToolTip = "#VAL";
        }
        void Chart1_Propiedades_Pruebas()
        {
            Chart_G2.Series.Add("Pruebas");
            Chart_G2.Series.Add("Casos_Activos");

            Chart_G2.Series["Pruebas"].XValueMember = "0";
            Chart_G2.Series["Casos_Activos"].XValueMember = "0";

            Chart_G2.Series["Pruebas"].YValueMembers = "1";
            Chart_G2.Series["Casos_Activos"].YValueMembers = "2";

            Chart_G2.Series["Pruebas"].Color = Color.Blue;
            Chart_G2.Series["Casos_Activos"].Color = Color.FromArgb(250, 170, 1);

            Chart_G2.Series["Pruebas"].YValuesPerPoint = 4;
            Chart_G2.Series["Casos_Activos"].YValuesPerPoint = 4;

            Chart_G2.ChartAreas.Add("ChartArea2");
            Chart_G2.ChartAreas["ChartArea2"].Position = new ElementPosition(0, 6, 100, 96);

            //--
            Chart_G2.Series[0].IsValueShownAsLabel = true;
            Chart_G2.Series[0].LabelBackColor = System.Drawing.Color.SkyBlue;
            Chart_G2.Series[1].IsValueShownAsLabel = true;
            Chart_G2.Series[1].LabelBackColor = Color.FromArgb(250, 170, 1);
            Chart_G2.Series[0].BorderWidth = 2;
            Chart_G2.Series[1].BorderWidth = 2;
            Chart_G2.ChartAreas[0].AxisX.Interval = 1;
            Chart_G2.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb(240, 240, 240); // Fondo del Grafico (rojo,verde,azul)

            var legent = Chart_G2.Legends.Add("Pruebas");

            //  horizontal ->  ----  vertical ---- 
            Chart_G2.Legends["Pruebas"].Position = new ElementPosition(0, 1, 16, 6);
            Chart_G2.Legends["Pruebas"].Font = new Font("Arial", 8, FontStyle.Bold);

            Chart_G2.Series[0].ToolTip = "#VAL";
            Chart_G2.Series[1].ToolTip = "#VAL";
        }
        void Chart1_Propiedades_Activos()
        {

            Chart_G2.Series.Add("Casos Activos");
            Chart_G2.Series.Add("Hospitalizados");
            Chart_G2.Series.Add("UCI");

            Chart_G2.Series["Casos Activos"].XValueMember = "0";
            Chart_G2.Series["Hospitalizados"].XValueMember = "0";
            Chart_G2.Series["UCI"].XValueMember = "0";

            Chart_G2.Series["Casos Activos"].YValueMembers = "1";
            Chart_G2.Series["Hospitalizados"].YValueMembers = "2";
            Chart_G2.Series["UCI"].YValueMembers = "3";

            Chart_G2.Series["Casos Activos"].Color = Color.FromArgb(250, 220, 1);
            Chart_G2.Series["Hospitalizados"].Color = Color.Orange;
            Chart_G2.Series["UCI"].Color = Color.Red;

            Chart_G2.Series["Casos Activos"].YValuesPerPoint = 4;
            Chart_G2.Series["Hospitalizados"].YValuesPerPoint = 4;
            Chart_G2.Series["UCI"].YValuesPerPoint = 4;

            Chart_G2.ChartAreas.Add("ChartArea2");
            Chart_G2.ChartAreas["ChartArea2"].Position = new ElementPosition(0, 6, 100, 96);

            //--
            Chart_G2.Series[0].IsValueShownAsLabel = true;
            Chart_G2.Series[0].LabelBackColor = Color.FromArgb(250, 220, 1);
            Chart_G2.Series[1].IsValueShownAsLabel = true;
            Chart_G2.Series[1].LabelBackColor = System.Drawing.Color.OrangeRed;
            Chart_G2.Series[1].LabelForeColor = System.Drawing.Color.White;
            Chart_G2.Series[2].IsValueShownAsLabel = true;
            Chart_G2.Series[2].LabelBackColor = System.Drawing.Color.Red;
            Chart_G2.Series[2].LabelForeColor = System.Drawing.Color.White;
            Chart_G2.Series[0].BorderWidth = 2;
            Chart_G2.Series[1].BorderWidth = 2;
            Chart_G2.Series[2].BorderWidth = 2;
            Chart_G2.ChartAreas[0].AxisX.Interval = 1;
            Chart_G2.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb(240, 240, 240); // Fondo del Grafico (rojo,verde,azul)

            var legent = Chart_G2.Legends.Add("Activos");

            //  horizontal ->  ----  vertical ---- 
            Chart_G2.Legends["Activos"].Position = new ElementPosition(0, 1, 16, 6);
            Chart_G2.Legends["Activos"].Font = new Font("Arial", 8, FontStyle.Bold);

            Chart_G2.Series[0].ToolTip = "#VAL";
            Chart_G2.Series[1].ToolTip = "#VAL";
            Chart_G2.Series[2].ToolTip = "#VAL";
        }

        /*============================= CONVERTIR LIST TO DATATABLE ==========================================*/
        //private DataTable ConvertListToDataTable(List<Registros_InfecFallAlta_BE> lista)
        //{
        //    string json = Newtonsoft.Json.JsonConvert.SerializeObject(lista);
        //    DataTable dt = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(json);
        //    return dt;
        //}



        /*============================= RBT CHANGED ==========================================*/
        //protected void rbtInfectadosChanged(object sender, EventArgs e)
        //{
        //    //G_MostrarInfectados();
        //}

        //protected void rbtInfectadosxDiaChanged(object sender, EventArgs e)
        //{
        //    //G_MostrarInfectadosXdia();
        //}
        /*============================= REMOVE SERIES-CHARTAREAS-LEGENDS ==========================================*/
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
        /*============================= METODOS GRAFICO 1 =====================================*/
        private void G_MostrarInfectados()
        {

            RemoverSeries(Chart_G1);

            Chart1_Propiedades_Infectados();

            Chart_G1.DataSource = registrosBL.DT_InfectadosFallecidosRecuperado();
            Chart_G1.DataBind();


        }
        private void G_MostrarInfectadosXdia()
        {

            RemoverSeries(Chart_G1);

            Chart1_Propiedades_InfectadosXdia();

            Chart_G1.DataSource = registrosBL.DT_InfectadosXdia();
            Chart_G1.DataBind();


        }
        /*============================= METODOS GRAFICO 2 =====================================*/
        private void G_MostrarPruebas()
        {

            RemoverSeries(Chart_G2);

            Chart1_Propiedades_Pruebas();

            Chart_G2.DataSource = registrosBL.DT_PruebasCasosActivos();
            Chart_G2.DataBind();


        }
        private void G_MostrarActivos()
        {

            RemoverSeries(Chart_G2);

            Chart1_Propiedades_Activos();

            Chart_G2.DataSource = registrosBL.DT_ActivosHospiUCI();
            Chart_G2.DataBind();


        }
        /*=============================BOTON 1==========================================*/
        protected void btnMostrar1_Click(object sender, EventArgs e)
        {
            //if (rbtInfectados.Checked)
            //{
            //    G_MostrarInfectados();
            //}
            //else if (rbtInfectadosxDia.Checked)
            //{
            //    G_MostrarInfectadosXdia();
            //}
            //lblMortalidad.Text = registrosBL.PorcentajeMortalidad().ToString() + "%";
            //lblIndectados.Text = registrosBL.PorcentajeInfectados().ToString() + "%";

            //// Para el Grafico 2
            //if (rbtPruebas.Checked)
            //{
            //    G_MostrarPruebas();
            //}
            //else if (rbtActivos.Checked)
            //{
            //    G_MostrarActivos();
            //}
        }


        public void MostrarGrafico_PruebasActivosHospitalUCI()
        {
            //List<Registros_InfecFallAlta_BE> lista = registrosBL.InfectadosFallecidosRecuperados();
            ////var nuevaLista = from l in lista
            ////                 select new {l.FECHA,l.}
        }

        protected void btnMostrar2_Click(object sender, EventArgs e)
        {
            //// Para el Grafito 1
            //if (rbtInfectados.Checked)
            //{
            //    G_MostrarInfectados();
            //}
            //else if (rbtInfectadosxDia.Checked)
            //{
            //    G_MostrarInfectadosXdia();
            //}
            //lblMortalidad.Text = registrosBL.PorcentajeMortalidad().ToString() + "%";
            //lblIndectados.Text = registrosBL.PorcentajeInfectados().ToString() + "%";

            //// Para el Grafico 2
            //if (rbtPruebas.Checked)
            //{
            //    G_MostrarPruebas();
            //}
            //else if(rbtActivos.Checked)
            //{
            //    G_MostrarActivos();
            //}

        }




        protected void btnGeneral_Click(object sender, EventArgs e)
        {
            G_MostrarInfectados();
            G1_btn1 = true;
            Session["G1_btn1"] = "true";
            if (Session["G2_btn1"].ToString() == "true") G_MostrarPruebas();
            else G_MostrarActivos();
        }

        protected void btnInfectadosXdia_Click(object sender, EventArgs e)
        {
            G_MostrarInfectadosXdia();
            G1_btn1 = false;
            Session["G1_btn1"] = "false";
            if (Session["G2_btn1"].ToString() == "true") G_MostrarPruebas();
            else G_MostrarActivos();
        }

        protected void btnPruebas_Click(object sender, EventArgs e)
        {
            G_MostrarPruebas();
            G2_btn1 = true;
            Session["G2_btn1"] = "true";
            if (Session["G1_btn1"].ToString() == "true") G_MostrarInfectados();
            else G_MostrarInfectadosXdia();
        }

        protected void btnActivos_Click(object sender, EventArgs e)
        {
            G_MostrarActivos();
            G2_btn1 = false;
            Session["G2_btn1"] = "false";
            if (Session["G1_btn1"].ToString() == "true") G_MostrarInfectados();
            else G_MostrarInfectadosXdia();
        }
    }
}