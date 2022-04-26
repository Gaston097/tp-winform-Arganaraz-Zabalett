﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGrupal
{
    public partial class frmProductosTodos : Form
    {
        public frmProductosTodos()
        {
            InitializeComponent();
            mostrarProductosTodos_Load();
        }
        public void mostrarProductosTodos_Load()
        {
            listasProductos p = new listasProductos();

            dgvProductos.AllowUserToAddRows = false;

            dgvProductos.Columns.Clear();

            dgvProductos.DataSource = p.listar();

            this.dgvProductos.Columns["id"].Visible = false;
            this.dgvProductos.Columns["imagen"].Visible = false; 
        }
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            negocioProducto np = new negocioProducto();
            frmProductosTodos p = new frmProductosTodos();

            int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value.ToString());

            if (MessageBox.Show("Quieres eliminar a este usuario?", "Message", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                if (np.eliminarProducto(id))
                {
                    MessageBox.Show("Articulo eliminado con exito");
                    this.mostrarProductosTodos_Load();
                }
                else
                    MessageBox.Show("El articulo no se pudo eliminar");
            }
        }
    }
}