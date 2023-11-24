using BackEnd.Servicios;
using BackEnd.Servicios.Implementacion;
using FrontEnd.Reporte;

namespace FrontEnd
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FabricaServicioImpl Fabrica = new FabricaServicioImpl();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmPrincipal(new FabricaServicioImpl()));
        }
    }
}