using BackEnd.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace FrontEnd.Reporte
{
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "FrontEnd.Reporte.Report1.rdlc";
            reportViewer1.LocalReport.ReportPath = @"D:\£\Facultad\UTN\TUP- UTN\2°C\Programacion ll\TPI\Cine\Programacion2-Cine\FrontEnd\Reporte\Report1.rdlc";
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value < dtpFechaFin.Value)
            {
                List<Parametro> lst = new List<Parametro>();
                lst.Add(new Parametro("@fecha_inicio", dtpFechaInicio.Value));
                lst.Add(new Parametro("@fecha_fin", dtpFechaFin.Value));
                DataTable tabla = HelperDao.ObtenerInstancia().ConsultarProcedureFiltro("SP_TAQUILLERAS", lst);

                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", HelperDao.ObtenerInstancia().ConsultarProcedureFiltro("SP_TAQUILLERAS", lst)));


                reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("la fecha de inicio no puede ser superior a la fecha fin", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFechaInicio.Focus();
            }
           
        }
    }
}
