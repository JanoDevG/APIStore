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
            if (pro.stock <= 0)
            {
                pro.stock = 1;
            }
            Productos ele = elementos.Where(x => x.id_producto == pro.id_producto).FirstOrDefault();
            if (ele == null)
            {
                pro.SubTotal = pro.precio * pro.stock;
                elementos.Add(pro);
            }
            else
            {
                sbyte stockNueva = (sbyte)(ele.stock + pro.stock);
                Editar(ele.id_producto, stockNueva);
            }
            Totalizar();
            Contar();
        }
        public void Editar(int id, sbyte stock)
        {
            Productos ele = elementos.Where(x => x.id_producto == id_producto).FirstOrDefault();
            if (ele != null)
            {
                ele.stock = stock;
                ele.SubTotal = ele.precio * stock;
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
                count += p.stock;
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
