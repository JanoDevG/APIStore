//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelAPIStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productos()
        {
            this.Detalle_Ventas = new HashSet<Detalle_Ventas>();
        }
    
        public int id_producto { get; set; }
        public string nombre_producto { get; set; }
        public int id_lenguaje { get; set; }
        public int id_licencia { get; set; }
        public int stock { get; set; }
        public System.DateTime fecha_creacion { get; set; }
        public int precio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Ventas> Detalle_Ventas { get; set; }
        public virtual Lenguaje_Backend Lenguaje_Backend { get; set; }
        public virtual Tipo_Licencias Tipo_Licencias { get; set; }
    }
}
