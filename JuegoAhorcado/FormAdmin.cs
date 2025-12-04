using JuegoAhorcado.Modelos;
using JuegoAhorcado.Repositorios;
using JuegoAhorcado.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoAhorcado
{
    public partial class FormAdmin : Form
    {
        private RepositorioCategorias repoCategorias = new RepositorioCategorias();
        private RepositorioPalabras repoPalabras = new RepositorioPalabras();

        private Categoria categoriaSeleccionada;
        private EntradaPalabra palabraSeleccionada;

        private ServicioSesionJugador sesion;

        public FormAdmin(ServicioSesionJugador sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarCategoriasEnCombo();
            CargarPalabras();
        }

        // ============================= //
        //      GESTIÓN DE CATEGORÍAS   //
        // ============================= //

        private void CargarCategorias()
        {
            var lista = repoCategorias.ObtenerTodas();

            dgvCategorias.DataSource = lista.Select(c => new
            {
                ID = c.Id,
                Categoria = c.Nombre
            }).ToList();

            dgvCategorias.ClearSelection();
            categoriaSeleccionada = null;
            txtCategorias.Clear();
        }

        private void btnAnadirCat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategorias.Text))
            {
                MessageBox.Show("Escribe un nombre para la categoría.");
                return;
            }

            Categoria nueva = new Categoria { Nombre = txtCategorias.Text.Trim() };
            repoCategorias.Insertar(nueva);

            CargarCategorias();
            CargarCategoriasEnCombo();

            MessageBox.Show("Categoría añadida correctamente.");
        }

        private void dgvCategorias_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Validar que exista la celda y no sea null
            var celda = dgvCategorias.Rows[e.RowIndex].Cells["ID"].Value;

            if (celda == null)
            {
                MessageBox.Show("La fila seleccionada no contiene un ID válido.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id;

            // Intentar convertir el ID
            if (!int.TryParse(celda.ToString(), out id))
            {
                MessageBox.Show("El ID seleccionado no es numérico.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener categoría desde BD
            categoriaSeleccionada = repoCategorias.ObtenerPorId(id);

            if (categoriaSeleccionada == null)
            {
                MessageBox.Show("No se encontró la categoría en la base de datos.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ahora sí existe → Se puede mostrar sin error
            txtCategorias.Text = categoriaSeleccionada.Nombre;
        }


        private void btnModificarCat_Click(object sender, EventArgs e)
        {
            if (categoriaSeleccionada == null)
            {
                MessageBox.Show("Selecciona una categoría primero.");
                return;
            }

            categoriaSeleccionada.Nombre = txtCategorias.Text.Trim();
            repoCategorias.Modificar(categoriaSeleccionada);

            CargarCategorias();
            CargarCategoriasEnCombo();

            MessageBox.Show("Categoría modificada correctamente.");
        }

        private void btnEliminarCat_Click(object sender, EventArgs e)
        {
            if (categoriaSeleccionada == null)
            {
                MessageBox.Show("Selecciona una categoría primero.");
                return;
            }

            if (MessageBox.Show("¿Seguro que quieres eliminar esta categoría?",
                                "Confirmación", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                repoCategorias.Eliminar(categoriaSeleccionada.Id);
                CargarCategorias();
                CargarCategoriasEnCombo();
            }
        }

        // ============================= //
        //      GESTIÓN DE PALABRAS     //
        // ============================= //

        private void CargarCategoriasEnCombo()
        {
            cbElegirCategoria.Items.Clear();

            var lista = repoCategorias.ObtenerTodas();

            cbElegirCategoria.DataSource = lista;
            cbElegirCategoria.DisplayMember = "Nombre";
            cbElegirCategoria.ValueMember = "Id";
        }

        private void CargarPalabras()
        {
            var lista = repoPalabras.ObtenerTodas();

            dgvPalabras.DataSource = lista.Select(p => new
            {
                ID = p.Id,
                Palabra = p.Palabra,
                Categoria = p.CategoriaNombre
            }).ToList();

            dgvPalabras.ClearSelection();
            palabraSeleccionada = null;
            txtPalabra.Clear();
        }

        private void cbElegirCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbElegirCategoria.SelectedValue is int catId)
            {
                var lista = repoPalabras.ObtenerPorCategoria(catId);

                dgvPalabras.DataSource = lista.Select(p => new
                {
                    ID = p.Id,
                    Palabra = p.Palabra,
                    Categoria = p.CategoriaNombre
                }).ToList();
            }
        }

        private void txtPalabra_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtPalabra.Text.Trim().ToUpper();
            var lista = repoPalabras.ObtenerTodas();

            var filtrada = lista.Where(p => p.Palabra.ToUpper().Contains(filtro))
                                .Select(p => new
                                {
                                    ID = p.Id,
                                    Palabra = p.Palabra,
                                    Categoria = p.CategoriaNombre
                                }).ToList();

            dgvPalabras.DataSource = filtrada;
        }

        private void dgvPalabras_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvPalabras.Rows[e.RowIndex].Cells["ID"].Value);
            palabraSeleccionada = repoPalabras.ObtenerPorId(id);

            txtPalabra.Text = palabraSeleccionada.Palabra;
            cbElegirCategoria.SelectedValue = palabraSeleccionada.CategoriaId;
        }

        private void btnAnadirPalabra_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPalabra.Text))
            {
                MessageBox.Show("Escribe una palabra primero.");
                return;
            }

            if (cbElegirCategoria.SelectedValue == null)
            {
                MessageBox.Show("Selecciona una categoría.");
                return;
            }

            EntradaPalabra nueva = new EntradaPalabra
            {
                Palabra = txtPalabra.Text.Trim(),
                CategoriaId = (int)cbElegirCategoria.SelectedValue
            };

            repoPalabras.Insertar(nueva);

            CargarPalabras();
            MessageBox.Show("Palabra añadida correctamente.");
        }

        private void btnModificarPalabra_Click(object sender, EventArgs e)
        {
            if (palabraSeleccionada == null)
            {
                MessageBox.Show("Selecciona una palabra primero.");
                return;
            }

            palabraSeleccionada.Palabra = txtPalabra.Text.Trim();
            palabraSeleccionada.CategoriaId = (int)cbElegirCategoria.SelectedValue;

            repoPalabras.Modificar(palabraSeleccionada);

            CargarPalabras();
            MessageBox.Show("Palabra modificada correctamente.");
        }

        private void btnEliminarPalabra_Click(object sender, EventArgs e)
        {
            if (palabraSeleccionada == null)
            {
                MessageBox.Show("Selecciona una palabra primero.");
                return;
            }

            if (MessageBox.Show("¿Seguro que deseas eliminar esta palabra?",
                                "Confirmación", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                repoPalabras.Eliminar(palabraSeleccionada.Id);
                CargarPalabras();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
