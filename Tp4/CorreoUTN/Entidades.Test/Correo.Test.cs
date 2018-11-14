using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace Entidades.Test
{
    [TestClass]
    public class CorreoTest
    {
        [TestMethod]
        public void ListaDePaquetesNotNullTest()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void AgregarPaquetesConTrackingIDRepetido()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("direccion", "track1");
            Paquete p2 = new Paquete("direccion", "track1");

            correo += p1;
            correo += p2;
        }
    }
}
