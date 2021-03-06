﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        List<Producto> productos;
        int espacioDisponible;
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

  
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        public Changuito(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }

        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
 

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c.espacioDisponible);
            sb.AppendLine();
            //agregar al stringbuilder los productos, separados por ETipo tipo
            foreach (Producto prod in c.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if(prod is Snacks)
                            sb.AppendLine(prod.Mostrar());
                        break;

                    case ETipo.Dulce:
                        if(prod is Dulce)
                            sb.AppendLine(prod.Mostrar());
                        break;

                    case ETipo.Leche:
                        if(prod is Leche)
                            sb.AppendLine(prod.Mostrar());
                        break;

                    case ETipo.Todos:
                        sb.AppendLine(prod.Mostrar());
                        break;

                    default:
                        sb.AppendLine("");
                        break;
                }
            }

            return sb.ToString();
        }


        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            foreach (Producto prod in c.productos)
            {
                if (prod == p)
                    return c;
            }

            if (c.productos.Count < c.espacioDisponible)
                c.productos.Add(p);
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            int productoAEliminar = -1;
            foreach (Producto prod in c.productos)
            {
                if (prod == p)
                {
                    productoAEliminar = c.productos.IndexOf(prod);
                    break;
                }
            }

            if (productoAEliminar != -1)
                c.productos.RemoveAt(productoAEliminar);

            return c;
        }
    }
}
