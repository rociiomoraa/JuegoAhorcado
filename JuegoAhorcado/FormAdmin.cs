using JuegoAhorcado.Modelos;
using JuegoAhorcado.Repositorios;
using JuegoAhorcado.Servicios;
using MySql.Data.MySqlClient;
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
        private readonly RepositorioCategorias repoCategorias = new RepositorioCategorias();
        private readonly RepositorioPalabras repoPalabras = new RepositorioPalabras();

        private Categoria categoriaSeleccionada;
        private EntradaPalabra palabraSeleccionada;
        private readonly RepositorioUsuarios repoUsuarios = new RepositorioUsuarios();
        private DataTable tablaJugadores;


        private readonly ServicioSesionJugador sesion;

        private bool bloqueado = false;

        public FormAdmin(ServicioSesionJugador sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                dgvCategorias.AutoGenerateColumns = true;
                dgvPalabras.AutoGenerateColumns = true;

                CargarCategorias();
                CargarCategoriasEnCombo();
                CargarPalabras();
                CargarJugadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el panel de administración:\n" + ex.Message);
            }
        }

        // ============================================================
        //                          CATEGORÍAS
        // ============================================================

        private void CargarCategorias()
        {
            try
            {
                using (var conn = new ConexionBD().ObtenerConexion())
                {
                    conn.Open();
                    string sql = @"SELECT id AS id,
                                          nombre AS nombre
                                   FROM categoria
                                   ORDER BY id";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);

                    dgvCategorias.DataSource = tabla;
                }

                categoriaSeleccionada = null;
                txtCategorias.Clear();
                dgvCategorias.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías:\n" + ex.Message);
            }
        }

        private void btnAnadirCat_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCategorias.Text))
                {
                    MessageBox.Show("Escribe un nombre para la categoría.");
                    return;
                }

                repoCategorias.Insertar(new Categoria { Nombre = txtCategorias.Text.Trim() });

                CargarCategorias();
                CargarCategoriasEnCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir categoría:\n" + ex.Message);
            }
        }

        private void dgvCategorias_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                var value = dgvCategorias.Rows[e.RowIndex].Cells[0].Value;
                if (value == null) return;

                int id = Convert.ToInt32(value);
                categoriaSeleccionada = repoCategorias.ObtenerPorId(id);

                if (categoriaSeleccionada != null)
                    txtCategorias.Text = categoriaSeleccionada.Nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar categoría:\n" + ex.Message);
            }
        }

        private void btnModificarCat_Click(object sender, EventArgs e)
        {
            try
            {
                if (categoriaSeleccionada == null)
                {
                    MessageBox.Show("Selecciona una categoría.");
                    return;
                }

                categoriaSeleccionada.Nombre = txtCategorias.Text.Trim();
                repoCategorias.Modificar(categoriaSeleccionada);

                CargarCategorias();
                CargarCategoriasEnCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar categoría:\n" + ex.Message);
            }
        }

        private void btnEliminarCat_Click(object sender, EventArgs e)
        {
            try
            {
                if (categoriaSeleccionada == null)
                {
                    MessageBox.Show("Selecciona una categoría.");
                    return;
                }

                repoCategorias.Eliminar(categoriaSeleccionada.Id);

                CargarCategorias();
                CargarCategoriasEnCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar categoría:\n" + ex.Message);
            }
        }

        // ============================================================
        //                           PALABRAS
        // ============================================================

        private void CargarCategoriasEnCombo()
        {
            try
            {
                var lista = repoCategorias.ObtenerTodas();

                cbElegirCategoria.DataSource = lista;
                cbElegirCategoria.DisplayMember = "Nombre";
                cbElegirCategoria.ValueMember = "Id";
                cbElegirCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías en el combo:\n" + ex.Message);
            }
        }

        private void CargarPalabras()
        {
            try
            {
                using (var conn = new ConexionBD().ObtenerConexion())
                {
                    conn.Open();
                    string sql =
                        @"SELECT p.id AS id, p.palabra, c.nombre AS categoria
                          FROM palabras p
                          INNER JOIN categoria c ON c.id = p.categoria_id
                          ORDER BY p.id";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);

                    dgvPalabras.DataSource = tabla;

                    if (dgvPalabras.Columns.Contains("id"))
                        dgvPalabras.Columns["id"].Name = "id";
                }

                palabraSeleccionada = null;
                txtPalabra.Clear();
                dgvPalabras.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar palabras:\n" + ex.Message);
            }
        }

        private void RefrescarFiltrado()
        {
            if (string.IsNullOrWhiteSpace(txtPalabra.Text))
                CargarPalabras();
            else
                txtPalabra_TextChanged(null, null);
        }

        private void cbElegirCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(cbElegirCategoria.SelectedValue is int idCategoria)) return;

                using (var conn = new ConexionBD().ObtenerConexion())
                {
                    conn.Open();

                    string sql =
                    @"SELECT p.id AS id,
                             p.palabra AS palabra,
                             c.nombre AS categoria
                      FROM palabras p
                      INNER JOIN categoria c ON c.id = p.categoria_id
                      WHERE p.categoria_id = @idCat
                      ORDER BY p.id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@idCat", idCategoria);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);

                    dgvPalabras.DataSource = tabla;

                    if (dgvPalabras.Columns.Contains("id"))
                        dgvPalabras.Columns["id"].Name = "id";
                }

                palabraSeleccionada = null;
                dgvPalabras.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar palabras:\n" + ex.Message);
            }
        }

        private void txtPalabra_TextChanged(object sender, EventArgs e)
        {
            if (bloqueado) return;

            try
            {
                using (var conn = new ConexionBD().ObtenerConexion())
                {
                    conn.Open();

                    string sql =
                    @"SELECT p.id AS id,
                             p.palabra AS palabra,
                             c.nombre AS categoria
                      FROM palabras p
                      INNER JOIN categoria c ON c.id = p.categoria_id
                      WHERE p.palabra LIKE @filtro
                      ORDER BY p.id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@filtro", "%" + txtPalabra.Text.Trim() + "%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);

                    dgvPalabras.DataSource = tabla;

                    if (dgvPalabras.Columns.Contains("id"))
                        dgvPalabras.Columns["id"].Name = "id";
                }

                palabraSeleccionada = null;
                dgvPalabras.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar palabras:\n" + ex.Message);
            }
        }

        private void dgvPalabras_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                if (!dgvPalabras.Columns.Contains("id"))
                    return;

                object valorId = dgvPalabras.Rows[e.RowIndex].Cells["id"].Value;

                if (valorId == null || valorId == DBNull.Value)
                    return;

                int id = Convert.ToInt32(valorId);

                palabraSeleccionada = repoPalabras.ObtenerPorId(id);

                if (palabraSeleccionada == null)
                {
                    MessageBox.Show("No se encontró la palabra en la base de datos.");
                    return;
                }

                bloqueado = true;

                txtPalabra.Text = palabraSeleccionada.Palabra;
                cbElegirCategoria.SelectedValue = palabraSeleccionada.CategoriaId;

                bloqueado = false;
            }
            catch (Exception ex)
            {
                bloqueado = false;
                MessageBox.Show("Error al seleccionar palabra:\n" + ex.Message);
            }
        }

        private void btnAnadirPalabra_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbElegirCategoria.SelectedIndex < 0)
                {
                    MessageBox.Show("Selecciona una categoría.");
                    return;
                }

                repoPalabras.Insertar(new EntradaPalabra
                {
                    Palabra = txtPalabra.Text.Trim(),
                    CategoriaId = (int)cbElegirCategoria.SelectedValue
                });

                RefrescarFiltrado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir palabra:\n" + ex.Message);
            }
        }

        private void btnModificarPalabra_Click(object sender, EventArgs e)
        {
            try
            {
                if (palabraSeleccionada == null)
                {
                    MessageBox.Show("Selecciona una palabra.");
                    return;
                }

                palabraSeleccionada.Palabra = txtPalabra.Text.Trim();
                palabraSeleccionada.CategoriaId = (int)cbElegirCategoria.SelectedValue;

                repoPalabras.Modificar(palabraSeleccionada);

                RefrescarFiltrado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar palabra:\n" + ex.Message);
            }
        }

        private void btnEliminarPalabra_Click(object sender, EventArgs e)
        {
            try
            {
                if (palabraSeleccionada == null)
                {
                    MessageBox.Show("Selecciona una palabra.");
                    return;
                }

                repoPalabras.Eliminar(palabraSeleccionada.Id);

                RefrescarFiltrado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar palabra:\n" + ex.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                FormMenuPrincipal menu = new FormMenuPrincipal(sesion);
                menu.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al volver:\n" + ex.Message);
            }
        }


        // ============================================================
        //                           JUGADORES
        // ============================================================

        private void CargarJugadores()
        {
            try
            {
                var lista = repoUsuarios.ObtenerTodos();

                // Convertimos la lista en DataTable para poder filtrar dinámicamente
                tablaJugadores = new DataTable();
                tablaJugadores.Columns.Add("ID", typeof(int));
                tablaJugadores.Columns.Add("Usuario", typeof(string));
                tablaJugadores.Columns.Add("Admin", typeof(bool));
                tablaJugadores.Columns.Add("Puntuación", typeof(int));
                tablaJugadores.Columns.Add("Racha Máxima", typeof(int));

                foreach (var u in lista)
                {
                    tablaJugadores.Rows.Add(
                        u.Id,
                        u.NombreUsuario,
                        u.EsAdministrador,
                        u.PuntuacionTotal,
                        u.RachaMaxima
                    );
                }

                dgvJugadores.DataSource = tablaJugadores;

                dgvJugadores.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los jugadores:\n" + ex.Message);
            }
        }

        private void txtJugador_TextChanged(object sender, EventArgs e)
        {
            if (tablaJugadores == null) return;

            string filtro = txtJugador.Text.Trim();

            if (string.IsNullOrWhiteSpace(filtro))
            {
                tablaJugadores.DefaultView.RowFilter = "";
            }
            else
            {
                tablaJugadores.DefaultView.RowFilter = $"Usuario LIKE '%{filtro}%'";
            }
        }


        private void lblJugador_Click(object sender, EventArgs e)
        {

        }

        private void dgvJugadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        }
    }
