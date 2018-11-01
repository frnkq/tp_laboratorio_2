using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Archivos;
using ClasesInstanciables;
namespace Tests
{
    [TestClass]
    public class ArchivosTextoTest
    {
        Archivos.Texto texto;
        Archivos.Xml<Universidad> xmlClaseSerializable;
        Archivos.Xml<Alumno> xmlClaseNoSerializable;
        ClasesInstanciables.Universidad universidad;
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        /// <summary>
        /// Prueba la funcion Guardar de la clase Archivos.Texto con datos validos
        /// </summary>
        [TestMethod]
        public void TestLeerYGuardarTextoDatosValidos()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                "\\TestLeerYGuardarTextoDatosValidos.txt";
            string dataToBeSaved = "this is some data";

            texto = new Texto();
            texto.Guardar(filePath, dataToBeSaved);

            string savedData;
            texto.Leer(filePath, out savedData);

            Assert.AreEqual(savedData, dataToBeSaved);
            File.Delete(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestLeerTextoPathInexistente()
        {
            texto = new Texto();
            string filePath =  desktopPath+"\\TestLeerTextoPathInexistente.txt";

            string loadedData;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            texto.Leer(filePath, out loadedData);
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void TestGuardarTextoSinPermisos()
        {
            texto = new Texto();
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Windows) +
                "\\TestGuardarTextoSinPermisos.txt";

            string dataToBeSaved = "this cannot be saved";

            texto.Guardar(filePath, dataToBeSaved);
        }
    }
}
