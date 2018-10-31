using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            
            XmlWriter xmlWriter = XmlWriter.Create(archivo);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            try
            {
                ser.Serialize(xmlWriter, datos);
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                xmlWriter.Close();
            }

        }

        public bool Leer(string archivo, out T datos)
        {
            XmlReader xmlReader = XmlReader.Create(archivo);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            try
            {
                datos = (T)ser.Deserialize(xmlReader);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                xmlReader.Close();
            }

        }
    }
}
