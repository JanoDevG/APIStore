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
    
    public partial class Despachos_Electronico
    {
        public int id_despacho { get; set; }
        public bool estado { get; set; }
        public int id_factura { get; set; }
        public System.DateTime fecha_despacho { get; set; }
    
        public virtual Factura Factura { get; set; }
    }
}
