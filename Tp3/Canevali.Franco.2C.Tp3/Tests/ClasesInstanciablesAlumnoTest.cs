using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using Excepciones;

namespace Tests
{
    [TestClass]
    public class ClasesInstanciablesAlumnoTest
    {
        Alumno alumno;
        string validDni = "22222222";
        string invalidDni = "22bn76-L";

        [TestMethod]
        public void TestSetValidDni()
        {
            alumno = new Alumno(1, "nombre", "apellido",
                validDni, ClasesAbstractas.Persona.ENacionalidad.Argentino,
                Universidad.EClases.SPD);

            Assert.AreEqual(int.Parse(validDni), alumno.DNI);
        }

        [TestMethod]
        public void TestSetInvalidDni()
        {
            alumno = new Alumno(1, "nombre", "apellido",
                    validDni, ClasesAbstractas.Persona.ENacionalidad.Argentino,
                    Universidad.EClases.SPD);

            try
            {
                alumno.StringToDni = invalidDni;
            }
            catch (DniInvalidoException)
            {

            }
            
            Assert.AreEqual(int.Parse(validDni), alumno.DNI);
        }
    }
}
