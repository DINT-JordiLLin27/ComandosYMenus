using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp3
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<string> lista;
        public ObservableCollection<string> Lista
        {
            get { return lista; }
            set { lista = value; }
        }



        private string textoCopia;
        public string Copia
        {
            get { return textoCopia; }
            set { textoCopia = value; }
        }

        public MainWindow()
        {
            lista = new ObservableCollection<string>();
            Copia = "";
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            PanelPrincipalDockPanel.DataContext = Lista;

           
        }

        private void CommandArchivoNuevo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string nuevoTexto = "Item añadido a las " + DateTime.Now.ToLongTimeString();
            lista.Add(nuevoTexto);
        }

        private void CommandArchivoNuevo_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lista.Count <= 10) { e.CanExecute = true; } else e.CanExecute = false;
        }

        private void CommandArchivoSalir_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

       
        private void CommandEditarCopiar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            textoCopia = (string)ListaPrincipalListBox.SelectedItem;
        }

        private void CommandEditarCopiar_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lista.Count > 0)
            {
                if (ListaPrincipalListBox.SelectedItem != null && Lista.Count <= 10)
                    e.CanExecute = true;
            }
            else e.CanExecute = false;
        }
       
        private void CommandEditarPegar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Lista.Add(textoCopia);
        }

        private void CommandEditarPegar_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (textoCopia != "" && Lista.Count <= 10);
        }

        private void CommandEditarVaciar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (lista.Count > 0) { lista.Clear(); }
        }

        private void CommandEditarVaciar_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lista.Count > 0) { e.CanExecute = true; } else e.CanExecute = false;
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            barraTiempoTextBlock.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
