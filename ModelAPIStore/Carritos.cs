using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelAPIStore
{
    public sealed class Carritos
    {
        private List<Productos> elementos = new List<Productos>();
        public List<Productos> Elementos
        {
            get
            {
                return elementos;
            }
        }
        public void Agregar(Productos pro)
        {
            if (pro.Cantidad <= 0)
            {
                pro.Cantidad = 1;
            }
            Productos ele = elementos.Where(x => x.id_producto == pro.id_producto).FirstOrDefault();
            if (ele == null)
            {
                pro.SubTotal = pro.precio * pro.Cantidad;
                elementos.Add(pro);
            }
            else
            {
                sbyte Cantidad = (sbyte)(ele.Cantidad + pro.Cantidad);
                Editar(ele.id_producto, Cantidad);
            }
            Totalizar();
            Contar();
        }
        public void Editar(int id, sbyte cantidad)
        {
            Productos ele = elementos.Where(x => x.id_producto == id).FirstOrDefault();
            if (ele != null)
            {
                ele.Cantidad = cantidad;
                ele.SubTotal = ele.precio * cantidad;
            }
            else
            {
                Console.WriteLine("Productos no existe");
            }
            Totalizar();
            Contar();
        }
        public void Eliminar(int id)
        {
            Productos p = elementos.Where(x => x.id_producto == id).FirstOrDefault();
            if (p != null)
            {
                elementos.Remove(p);
            }
            else
            {

            }
        }
        public int Totalizar()
        {
            return elementos.Sum(x => x.SubTotal);
        }
        public int Contar()
        {
            int count = 0;
            foreach (Productos p in elementos)
            {
                count += p.Cantidad;
            }
            return count;
        }
        public void Limpiar()
        {
            elementos.Clear();
            Totalizar();
            Contar();
        }
    }
}
