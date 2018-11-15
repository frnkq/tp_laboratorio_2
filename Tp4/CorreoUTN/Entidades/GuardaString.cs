using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Metodo de extension de la clase string encargado de guardar
        /// el objeto string en un archivo de texto de nombre especificado por parametro,
        /// en la carpeta escritorio
        /// </summary>
        /// <param name="texto">Objeto string a guardar en el archivo</param>
        /// <param name="archivo">Nombre del archivo a ser ubicado en la carpeta escritorio</param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                + "\\" + archivo;
            StreamWriter sw = new StreamWriter(path, true);
            try
            {
                sw.WriteLine(texto);
            }
            catch (Exception e)
            {
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
            return false;
        }
    }
}
