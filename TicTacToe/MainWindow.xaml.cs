using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        int contadorJugadas = 1;
        string[,] tablero = new string[3, 3];

        public MainWindow()
        {
            InitializeComponent();
        }

        // Me costó hacer la lógica, pero bueno, ya está hecha >:D
        // Este proyecto fue COMPLETAMENTE hecho por mí, y muy poca ayuda externa
        // Hice muchas versiones, pero bueno, al final me quede con esta
        // Siento que se puede mejorar, pero actualmente no poseo los conocimientos
        // Intentaré documentar el código para que se pueda entender todos los puntos de este

        private void winner()

        {
            string ganador = null;

            for (int i = 0; i < 3; i++)
            {
                if (tablero[i, 0] == tablero[i, 1] && tablero[i, 1] == tablero[i, 2] && tablero[i, 0] != null)
                {
                    ganador = tablero[i, 0];
                    break;
                }
            }

            if (ganador == null)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (tablero[0, i] == tablero[1, i] && tablero[1, i] == tablero[2, i] && tablero[0, i] != null)
                    {
                        ganador = tablero[0, i];
                        break;
                    }
                }
            }

            if (ganador == null)
            {
                if (tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 2] && tablero[0, 0] != null)
                {
                    ganador = tablero[0, 0];
                }
                else if (tablero[0, 2] == tablero[1, 1] && tablero[1, 1] == tablero[2, 0] && tablero[0, 2] != null)
                {
                    ganador = tablero[0, 2];
                }
            }

            if (ganador != null)
            {
                resultadoLabel.Content = $"{ganador} gana!";
                LimpiarTablero();
            }
            else if (contadorJugadas > 9)
            {
                resultadoLabel.Content = "Empate!";
                LimpiarTablero();
            }
        }

        private void LimpiarTablero()
        {
            contadorJugadas = 1;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    tablero[i, j] = null;

            boton1.IsEnabled = true; boton2.IsEnabled = true; boton3.IsEnabled = true;
            boton4.IsEnabled = true; boton5.IsEnabled = true; boton6.IsEnabled = true;
            boton7.IsEnabled = true; boton8.IsEnabled = true; boton9.IsEnabled = true;

            boton1.Content = null; boton2.Content = null; boton3.Content = null;
            boton4.Content = null; boton5.Content = null; boton6.Content = null;
            boton7.Content = null; boton8.Content = null; boton9.Content = null;
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            RealizarJugada(0, 0, boton1);
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            RealizarJugada(0, 1, boton2);
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            RealizarJugada(0, 2, boton3);
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            RealizarJugada(1, 0, boton4);
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            RealizarJugada(1, 1, boton5);
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            RealizarJugada(1, 2, boton6);
        }

        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            RealizarJugada(2, 0, boton7);
        }

        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            RealizarJugada(2, 1, boton8);
        }

        private void Button_Click9(object sender, RoutedEventArgs e)
        {
            RealizarJugada(2, 2, boton9);
        }

        private void RealizarJugada(int fila, int columna, Button boton)
        {
            boton.IsEnabled = false;
            tablero[fila, columna] = (contadorJugadas % 2 == 1) ? "X" : "O";
            boton.Content = tablero[fila, columna];
            contadorJugadas++;
            winner();
        }
    }
}
