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
    
    public partial class Cuentas
    {
        public int id_cuenta { get; set; }
        public int id_usuario { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public Nullable<bool> usuario_supendido { get; set; }
        public Nullable<System.DateTime> fecha_suspencion { get; set; }
        public System.DateTime fecha_creacion { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}
