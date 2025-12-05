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
    public partial class FormHistorial : Form
    {
        private readonly ServicioSesionJugador sesion;

        public FormHistorial(ServicioSesionJugador sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }

        private void FormHistorial_Load(object sender, EventArgs e)
        {
            try
            {
                dgvHistorial.AutoGenerateColumns = true;

                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al iniciar el historial:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // ============================================================
        //   CARGA DATOS DEL HISTORIAL
        // ============================================================
        private void CargarHistorial()
        {
            try
            {
                using (var conn = new ConexionBD().ObtenerConexion())
                {
                    conn.Open();

                    string sql = @"
                        SELECT 
                            p.id AS ID_Partida,
                            w.palabra AS Palabra,
                            c.nombre AS Categoria,
                            p.resultado AS Resultado,
                            p.puntuacion_obtenida AS Puntos,
                            DATE_FORMAT(p.fecha, '%d/%m/%Y %H:%i') AS Fecha
                        FROM partidas p
                        INNER JOIN palabras w ON w.id = p.palabra_id
                        INNER JOIN categoria c ON c.id = w.categoria_id
                        WHERE p.usuario_id = @idUser
                        ORDER BY p.fecha DESC";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@idUser", sesion.UsuarioActual.Id);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);

                    dgvHistorial.DataSource = tabla;
                }

                CalcularEstadisticas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar el historial:\n" + ex.Message,
                    "Error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ============================================================
        //   CALCULA ESTADÍSTICAS VISIBLES EN LOS LABELS
        // ============================================================
        private void CalcularEstadisticas()
        {
            try
            {
                int total = dgvHistorial.Rows.Count;

                int ganadas = dgvHistorial.Rows
                    .Cast<DataGridViewRow>()
                    .Count(r =>
                        r.Cells["Resultado"].Value != null &&
                        r.Cells["Resultado"].Value.ToString().ToLower() == "acertada"
                    );

                int perdidas = total - ganadas;

                double porcentaje = (total > 0)
                    ? ganadas * 100.0 / total
                    : 0;

                lblTotalPartidas.Text = "Total partidas: " + total.ToString();
                lblGanadas.Text = "Ganadas: " + ganadas.ToString();
                lblPerdidas.Text = "Perdidad: " + perdidas.ToString();
                lblAcierto.Text = "Acierto: " + porcentaje.ToString("0.00") + "%";
                lblRachaMaxima.Text = "Racha Máxima: " + sesion.UsuarioActual.RachaMaxima.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al calcular estadísticas:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // ============================================================
        //   BOTÓN VOLVER
        // ============================================================
        private void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                FormMenuPrincipal menu = new FormMenuPrincipal(sesion);
                menu.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error al volver al menú.");
            }
        }
    }
}