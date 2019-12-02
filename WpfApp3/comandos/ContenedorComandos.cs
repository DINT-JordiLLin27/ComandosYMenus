using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp3
{
    class ContenedorComandos
    {
        public static readonly RoutedUICommand Salir = new RoutedUICommand(

            "Salir",
            "Salir",
            typeof(ContenedorComandos),
            new InputGestureCollection() { new KeyGesture(Key.S, ModifierKeys.Control) }
            );

        public static readonly RoutedUICommand Vaciar = new RoutedUICommand(

           "Vaciar",
           "Vaciar",
           typeof(ContenedorComandos),
           new InputGestureCollection() { new KeyGesture(Key.D, ModifierKeys.Control) }
           );
    }
}
