using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace appParqueDiversiones
{
    public partial class Form1 : Form

    {
        ArrayList visitantes = new ArrayList();
        Visitor oVisitante = null;      

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.txtNombre.Text == "")
            {
                MessageBox.Show("Error!", "Debe escribir un Nombre!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            dgvGrid.Columns[0].Name = "Nombre";
            dgvGrid.Columns[1].Name = "Fecha";
            dgvGrid.Columns[2].Name = "Tipo";


            if (rbtMayor.Checked)
            {                
                String[] dato = { this.txtNombre.Text, this.dateTimePicker1.Text, rbtMayor.Text };
                oVisitante = new Mayor();
                dgvGrid.Rows.Add(dato);
                visitantes.Add(oVisitante);
                MessageBox.Show("Agregado...!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (rbtMenor.Checked)
            {               
                String[] dato = { this.txtNombre.Text, this.dateTimePicker1.Text, rbtMenor.Text };
                oVisitante = new Menor();
                dgvGrid.Rows.Add(dato);
                visitantes.Add(oVisitante);
                MessageBox.Show("Agregado...!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (rbtExtranjero.Checked)
            {                
                String[] dato = { this.txtNombre.Text, this.dateTimePicker1.Text, rbtExtranjero.Text };
                oVisitante = new Extranjero();
                dgvGrid.Rows.Add(dato);
                visitantes.Add(oVisitante);
                MessageBox.Show("Agregado...!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            txtNombre.Text = "";
        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            int cantMayores = 0;
            int cantMenores = 0;
            int cantExtranjeros = 0;
            double subtotal = 0;
            double impuestosVentas = 0;
            double total = 0;
            double impuestosExt = 0;

            foreach (Visitor oVisitante in visitantes)
            {
                subtotal += oVisitante.GetPayment();
                impuestosVentas += oVisitante.Impuesto();
                total += oVisitante.TotalToPay();

                if (oVisitante is Extranjero)
                {
                    cantExtranjeros++;
                    impuestosExt += (oVisitante as Extranjero).ImpuestoExtranjero();
                }
                else if (oVisitante is Mayor)
                {
                    cantMayores++;
                }
                else
                {
                    cantMenores++;
                }

            }

            rtbTexto.Text = "";
            txtTotal.Text = "";
            this.rtbTexto.AppendText("CIERRE DEL DÍA:");
            this.rtbTexto.AppendText("\nCantidad de visitantes:" + visitantes.Count);
            this.rtbTexto.AppendText("\nCantidad de menores:" + cantMenores);
            this.rtbTexto.AppendText("\nCantidad de mayores:" + cantMayores);
            this.rtbTexto.AppendText("\nCantidad de extranjeros:" + cantExtranjeros);
            this.rtbTexto.AppendText("\nSubtotal:" + subtotal);
            this.rtbTexto.AppendText("\nImpuestos:" + impuestosVentas);
            this.rtbTexto.AppendText("\nImpuestos extranjeros:" + impuestosExt);
            this.txtTotal.AppendText("" + total);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

   
    }
}
