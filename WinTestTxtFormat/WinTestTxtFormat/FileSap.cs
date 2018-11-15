using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTestTxtFormat
{
    public class FileSap
    {
        public string AgenteRetencion { get; set; }
        public string RifAgenteRetencion { get; set; }
        public string PeriodoImpositivoAno { get; set; }
        public string PeriodoImpositivoMes { get; set; }
        public string RifSujetoDetenido { get; set; }
        public string TipoOperacion { get; set; }
        public string FechaFactura { get; set; }
        public string NumeroFactura { get; set; }
        public string NumeroControlFactura { get; set; }
        public string TipoDocumento { get; set; }
        public string CodigoContribuyente { get; set; }
        public string NumeroFacturaAfectada { get; set; }
        public string NumeroControlFacturaAfectada { get; set; }
        public Int64 NumeroComprobante { get; set; }
        public string BaseImponible { get; set; }
        public string Alicuota { get; set; }
        public string Codigo { get; set; }
        public string ImpuestoRetenido { get; set; }
        public string RUC { get; set; }
   
        public string getFileLine()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}\t{15}\t{16}\t{17}\t{18}", AgenteRetencion, RifAgenteRetencion,PeriodoImpositivoAno,PeriodoImpositivoMes,RifSujetoDetenido,TipoOperacion,FechaFactura,NumeroFactura,NumeroControlFactura,TipoDocumento,CodigoContribuyente,NumeroFacturaAfectada,NumeroControlFacturaAfectada,NumeroComprobante,BaseImponible,Alicuota,Codigo,ImpuestoRetenido,RUC);
        }
    }
}
