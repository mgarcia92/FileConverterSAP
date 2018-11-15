using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTestTxtFormat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.RutaArchivoTxt.Text))
                {
                    MessageBox.Show("Debe Seleccionar una ruta donde guardar el archivo para continuar!",
                                   "Alerta",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrEmpty(this.ArchivoTxt.Text))
                {
                    char[] separator = new char[] { '\t' };
                    var file = File.ReadAllLines(this.ArchivoTxt.Text, Encoding.UTF8);
                    List<FileSap> data = new List<FileSap>();
                    foreach (var item in file)
                    {
                        string[] lines = item.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                        if (string.IsNullOrEmpty(lines[0]) && string.IsNullOrEmpty(lines[1]))
                        {
                            continue;
                        }

                        FileSap fileSap = new FileSap();
                        fileSap.AgenteRetencion = lines[0].ToString();
                        fileSap.RifAgenteRetencion = lines[1];
                        fileSap.PeriodoImpositivoAno = lines[2];
                        fileSap.PeriodoImpositivoMes = lines[3];
                        fileSap.RifSujetoDetenido = lines[4];
                        fileSap.TipoOperacion = lines[5];
                        fileSap.FechaFactura = lines[6];
                        fileSap.NumeroFactura = lines[7];
                        fileSap.NumeroControlFactura = lines[8];
                        fileSap.TipoDocumento = lines[9].ToString();
                        fileSap.CodigoContribuyente = lines[10];
                        fileSap.NumeroFacturaAfectada = lines[11];
                        fileSap.NumeroControlFacturaAfectada = lines[12];
                        fileSap.NumeroComprobante = Convert.ToInt64(lines[13]);
                        fileSap.BaseImponible = lines[14];
                        fileSap.Alicuota = lines[15];
                        fileSap.Codigo = lines[16];
                        fileSap.ImpuestoRetenido = lines[17];
                        fileSap.RUC = lines[18];

                        data.Add(fileSap);
                    }
                    string finalPath = $"{RutaArchivoTxt.Text}\\FileConverter_SAP.txt";
                    using (FileStream fs = new FileStream(finalPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        StringBuilder st = new StringBuilder();
                        foreach (var item in data)
                        {
                            st.AppendLine(item.getFileLine());
                        }
                        byte[] arreglo = Encoding.UTF8.GetBytes(st.ToString());
                        fs.Write(arreglo, 0, arreglo.Length);
                        fs.Close();

                    }

                    MessageBox.Show("Archivo Convertido Con Exito");

                }
                else
                {
                    MessageBox.Show("Seleccione un Archivo para continuar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrieron Errores => {ex.Message}",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Stop);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
            this.ArchivoTxt.Text = path;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //openFileDialog1.ShowDialog();
            //string path = openFileDialog1.InitialDirectory;
            //RutaArchivoTxt.Text = path;

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    //string[] files = Directory.GetFiles(fbd.SelectedPath);
                    RutaArchivoTxt.Text = fbd.SelectedPath;
                    ///MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }
    }
}
