using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Funciones
{
    public class Constantes
    {
        public const string GENERAL_NOT_FOUND = "No se encontraron registros.";
        public const string NOT_FOUND = "no se encontraron registros para la búsqueda realizada.";
        public const string BAD_REQUEST = "Búsqueda no válida. Verifique su información.";
        public const string NOT_ACTIVE_USERS = "no se encontró ningún cliente activo.";
    }

    public class Validadores
    {
        public static bool validaId(int id)
        {
            return id > 0;
        }
        public static bool validaObjeto(Object objeto)
        {
            return objeto != null;
        }

        public static bool validaLista<T>(List<T> lista)
        {
            return lista.Count > 0;
        }

        public static bool validaTexto(string txt)
        {
            return txt != "";
        }
    }
}
