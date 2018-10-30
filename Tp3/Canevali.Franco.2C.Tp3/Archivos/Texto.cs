using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter sw = new StreamWriter(archivo);
            try
            {
                sw.Write(datos);
                return true;
            }catch(Exception e)
            {
                ///TODO: don't use exception
                throw e;
            }
            finally
            {
                if(sw != null)
                {
                    sw.Close();
                }
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            StreamReader sr = new StreamReader(archivo);
            try
            {
                datos = sr.ReadToEnd();
                return true;
            }
            catch (Exception e)
            {
                ///TODO: don't use exception
                throw e;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }
    }
}
