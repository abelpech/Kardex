using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UX1.Validaciones
{
    class KeyPressValidation
    {

        //Inicia Validacion de numeros
        public bool IsNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool IsNumber = false;
            // Evita escribir el caracter si este es diferente a las teclas de control
            // o a algun numero
            if (!char.IsControl(e.KeyChar) && isNumberValid(e.KeyChar))
            {
                IsNumber = true;

                // Este metodo te regresa un booleano en donde tendras despues que evaluarlo
                // de la siguiente forma: e.Handled = Letra_KeyPress(sender, e);

            }
            return IsNumber;
        }

        private bool isNumberValid(Char c)
        {
            // Regresa verdadero si el caracter es diferente de los numeros entre 0 a 9
            if (!(c >= '0' && c <= '9'))
            {
                return true;
            }
            return false;
        }
        //Termina validacion de numeros

        //Inicia Validacion de solo Letras
        public bool IsLetter_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool IsLetter = false;
            // Evita escribir el caracter si este es diferente a las teclas de control
            // o a alguna letra o espacio en blanco
            if (!char.IsControl(e.KeyChar) && isLetterValid(e.KeyChar) && !(e.KeyChar == ' '))
            {
                IsLetter = true;

                // Este metodo te regresa un booleano en donde tendras despues que evaluarlo
                // de la siguiente forma: e.Handled = Letra_KeyPress(sender, e);
            }

            return IsLetter;
        }
        private bool isLetterValid(Char c)
        {
            // Regresa verdadero si el caracter es diferente a las letras "a" minuscula
            // Hasta la letra "Z" Mayuscula
            if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
            {
                return true;
            }
            return false;
        }
        //Termina validacion de solo Letras

        //Inicia Validacion de solo Letras y Numeros
        public bool IsLetterOrNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool IsLetterOrNumber = false;
            // Evita escribir el caracter si este es diferente a las teclas de control
            // o a alguna letra o espacio en blanco
            if (!char.IsControl(e.KeyChar) && isLetterOrNumberValid(e.KeyChar) && !(e.KeyChar == ' '))
            {
                IsLetterOrNumber = true;

                // Este metodo te regresa un booleano en donde tendras despues que evaluarlo
                // de la siguiente forma: e.Handled = Letra_KeyPress(sender, e);
            }

            return IsLetterOrNumber;
        }
        private bool isLetterOrNumberValid(Char c)
        {
            // Regresa verdadero si el caracter es diferente a las letras "a" minuscula
            // Hasta la letra "Z" Mayuscula, incluyendo numeros del 0 al 9
            if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9')))
            {
                return true;
            }
            return false;
        }
        //Termina validacion de solo Letras y Numeros
    }
}
