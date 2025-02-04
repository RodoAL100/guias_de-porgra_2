﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourceDemo
{
    public partial class ejemploConexion : Form
    {
        public ejemploConexion()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            // Verifica que el campo CustomerID no esté vacío y no exceda la longitud máxima
            if (string.IsNullOrWhiteSpace(textBox1.Text) || textBox1.Text.Length > 5) // 5 es el tamaño máximo de CustomerID
            {
                MessageBox.Show("CustomerID no puede estar vacío y debe tener un tamaño máximo de 5 caracteres.");
                return;
            }

            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

        private void ejemploConexion_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 5; // Establece el tamaño máximo del CustomerID a 5 caracteres
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        private void customerIDLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // llamamos al customerBindingSource y el metodo que queremos ejecutar
            customersBindingSource.Clear();
        }

        private void cajaTextoID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                var index = customersBindingSource.Find("customerID", cajaTextoID);
                if (index > -1)
                {
                    customersBindingSource.Position = index;
                    return;
                }
                else
                {
                    MessageBox.Show("Elemento no encontrado");
                }
            };
        }
    }
}
