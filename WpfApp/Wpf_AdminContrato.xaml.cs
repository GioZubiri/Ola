using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BibliotecaClases;
using MahApps.Metro.Controls;

namespace WpfApp
{
    /// <summary>
    /// Lógica de interacción para Wpf_AdminContrato.xaml
    /// </summary>
    public partial class Wpf_AdminContrato : MetroWindow
    {
        ServiceReference1.Service1Client ws = new ServiceReference1.Service1Client();
        
        /*TipoEvento evento;
        double asistentes;
        double valorbase;
        double total;*/

        public Wpf_AdminContrato()
        {

            InitializeComponent();
            
            ServiceReference1.Service1Client ws = new ServiceReference1.Service1Client();
            lbl_uf.Content = ws.Uf().ToString();

            //evento = new TipoEvento();
            txt_contrato.Text = DateTime.Now.ToString("yyyyMMddHHmm");
            txt_creacion.Text = DateTime.Now.ToString("yyyy/MM/dd");
            TipoEvento tpevent = new TipoEvento();
            BibliotecaClases.TipoEvento BTE = new TipoEvento();
            var bts = BTE.listar();
            cb_tipoevento.Items.Add("Seleccione");
            cb_tipoevento.SelectedIndex = 0;
            foreach (var item in bts)
            {
                ComboTipoEvento CTE = new ComboTipoEvento();
                CTE.id = item.IdTipoEvento;
                CTE.texto = item.Descripcion;
                cb_tipoevento.Items.Add(CTE);
            }
            ModalidadServicio modsrv = new ModalidadServicio();
            BibliotecaClases.ModalidadServicio BMS = new ModalidadServicio();
            var twice = BMS.ListaMod();
            cb_ModalidadServicio.Items.Add("Seleccione");
            cb_ModalidadServicio.SelectedIndex = 0;
            /*foreach (var item in twice)
            {
                ComboModalidadServicio CMS = new ComboModalidadServicio();
                CMS.IdModalidad = item.IdModalidad;
                CMS.IdTipoEvento = item.IdTipoEvento;
                CMS.Nombre = item.Nombre;
                CMS.PersonalBase = item.PersonalBase;
                CMS.ValorBase = item.ValorBase;
                cb_ModalidadServicio.Items.Add(CMS);
            }
            ComboTipoEvento TipoEve = new ComboTipoEvento();
            //String ID = TipoEve.id.ToString().Trim();
            */
        }




        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            String Numero = txt_contrato.Text;
            DateTime Creacion = DateTime.Now;
            /*DateTime Termino =
            rut cliente se trae desde la base 
            idModalidad 
            int tipo evento*/ 
            DateTime FechaHoraInicio = (DateTime)dpkFechaInicio.SelectedDate;
            DateTime FechaHoraTermino = (DateTime)dpkFechaTermino.SelectedDate;
            int Asistentes = int.Parse(txt_cantasis.Text);
            int PersonalAdicional = int.Parse(txt_personalextra.Text); 
            
            Contrato Contrat = new Contrato();

            /*Contrat.Nrocontrato = NumeroContrato;
            Contrat.RutCliente = RutCli;
            Contrat.Creacion = Creacion;
            Contrat.Fechainicio = FechaInicion;
            Contrat.FechaTermino = FechaTermino;
            Contrat.Direccion = Direccion;
            Contrat.Observaciones = Observaciones;
            Contrat.Evento = Evento;*/

            Boolean resp = Contrat.Guardar();

            MessageBox.Show("Resultado: " + resp);
        }

        public void Buscar()
        {
           
        }



        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_contrato.Text != string.Empty)
                {
                    Contrato contra = new Contrato();
                    string Numero = txt_contrato.Text;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se encontro ningun contrato"+ex);
            }
        }

        private void btn_actualizar_Click(object sender, RoutedEventArgs e)
        {

           
        }

        private void btn_listar_Click(object sender, RoutedEventArgs e)
        {
            Wpf_Listarcontrato vista_lista_contrato = new Wpf_Listarcontrato(this);
            vista_lista_contrato.Show();
        }

        private void txt_contrato_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void btn_limpiar_Click(object sender, RoutedEventArgs e)
        {

            txt_direccion.Clear();
            txt_cantasis.Clear();
            txt_valorbase.Clear();
            txt_personalbase.Clear();
            txt_observaciones.Clear();
            cb_tipoevento.SelectedIndex = 0;
            txt_nombrecliente.Clear();
            txt_buscarporrut.Clear();
            lbl_valortotal.Content = "";
           


        }

        private void cb_tipoevento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string dato = cb_tipoevento.SelectedIndex.ToString();

            }
            catch (Exception ex)
            {

                
            }
           
        }

        private void txt_cantasis_TextChanged(object sender, TextChangedEventArgs e)
        {
        
        }

        private void txt_valorbase_TextChanged(object sender, TextChangedEventArgs e)

        {
            
        }

        private void txt_personalbase_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_personalextra_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /*public double CalculoValorTotal()
        {
            if (txt_personalextra.Text.Trim().ToString() == "")
            {
                txt_personalextra.Text = "0";
            }
            if (txt_cantasis.Text.Trim().ToString() == "")
            {
                txt_cantasis.Text = "1";
            }

            //asistentes = double.Parse(txt_cantasis.Text.ToString());
            //valorbase = double.Parse(txt_valorbase.Text.ToString());
            double valor_personal;
            if (txt_personalextra.Text.Trim().ToString()=="")
            {
                txt_personalextra.Text = "0";
            }
            if(txt_cantasis.Text.Trim().ToString()=="")
            {
                txt_cantasis.Text = "1";
            }
            if (int.Parse(txt_personalextra.Text.ToString())== 2)
            {
                valor_personal = Math.Truncate(ws.Uf()) * 2;

            }
            else
            {
                if (int.Parse(txt_personalextra.Text.ToString()) == 3)
                {
                    valor_personal = Math.Truncate(ws.Uf()) * 3;
                }
                else
                {
                    if (int.Parse(txt_personalextra.Text.ToString()) >= 4)
                    {
                        valor_personal = Math.Truncate((int.Parse(txt_personalextra.Text.ToString())) * 0.5) + Math.Truncate(3.5 * ws.Uf());
                    }
                }
            }
            //if (asistentes > 0 && asistentes <= 20)
            //{
            //    total = Math.Truncate(ws.Uf() * 3) + valorbase ;
            //}
            //else
            //{
            //    if (asistentes >= 21 && asistentes <= 50)
            //    {
            //        total = Math.Truncate(ws.Uf() * 5) + valorbase;
            //    }
            //    else
            //    {
            //        if (asistentes > 50)
            //        {
            //            total = Math.Truncate(asistentes - 50) / 20 * (2 * ws.Uf()) + valorbase;
            //        }
            //        else
            //        {
                        
            //        }

            //    }
            //}

            //return total;
        }*/

        private void Grid_Main_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_BuscarPorRut_Click(object sender, RoutedEventArgs e)
        {

           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_CalCularTotal_Click(object sender, RoutedEventArgs e)
        {
            /*CalculoValorTotal();
            InitializeComponent();
            lbl_valortotal.Content = total.ToString();*/
        }

        private void cb_ModalidadServicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ID = ((ComboTipoEvento)cb_tipoevento.SelectedItem).id;
            if (ID != 0)
            {
                ComboModalidadServicio modd = new ComboModalidadServicio();
                foreach (var item in modd.ModServ(ID))
                {
                    ModalidadServicio modsrv = new ModalidadServicio();
                    BibliotecaClases.ModalidadServicio BMS = new ModalidadServicio();
                    List<ModalidadServicio> twice = BMS.ListaMod();
                    foreach (ModalidadServicio item2 in twice)
                    {
                        ComboModalidadServicio CMS = new ComboModalidadServicio();
                        CMS.IdModalidad = item2.IdModalidad;
                        CMS.IdTipoEvento = item2.IdTipoEvento;
                        CMS.Nombre = item2.Nombre;
                        CMS.PersonalBase = item2.PersonalBase;
                        CMS.ValorBase = item2.ValorBase;
                        cb_ModalidadServicio.Items.Add(CMS);
                    }
                }
            }
            
        }
    }
}

