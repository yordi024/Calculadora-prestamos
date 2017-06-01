using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_de_prestamos
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
        }

        double Monto;
        double Interes;
        int Meses;
        double result;
         
        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void Box2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Box3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Box1_KeyPress(object sender, KeyPressEventArgs e) //Validar solo entra de numeros en los TexBox
        {
            Input(e);
        }

        public  KeyPressEventArgs Input(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Introducir solo numeros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return e; 
        }

        private void Box2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Input(e);
        }

        private void Box3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Input(e);
        }

        private void Calculadora_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCalcular_Click(object sender, EventArgs e) //Calcular Prestamos
        {
            double cuota;
            double intereses;
            double capital = Convert.ToDouble(Box1.Text);
            double tasa = Convert.ToDouble(Box2.Text);
            double plazo = Convert.ToDouble(Box3.Text);
            double amort;
            double amortAcumulado = 0;

            tasa /= 1200;
            cuota = capital * (tasa / (double)(1 - Math.Pow(1 + (double)tasa, - plazo)));
            cuota = Math.Round(cuota, 2);
            for (int i = 0; i <= plazo; i++)
            {
                if (i == 0)
                {
                    
                }
                else
                {
                    intereses = Math.Round((capital * tasa), 2);
                    amort = Math.Round((cuota - intereses), 2);
                    amortAcumulado += Math.Round(amort, 2);
                    capital -= Math.Round(amort, 2);
                    if(capital < 0)
                    {
                        
                        capital = (capital * -1);
                        
                    }
                    Tabla.Rows.Add(i, cuota, intereses, amort, amortAcumulado, capital);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) //Limpiar TexBox
        {
            Box1.Text = " ";
            Box2.Text = " ";
            Box3.Text = " ";
            Tabla.Rows.Clear();
        }
    }
}
