//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace voxpopuliAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoControl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoControl()
        {
            this.Pregunta = new HashSet<Pregunta>();
        }
    
        public int TipoControlId { get; set; }
        public string Nombre { get; set; }
        public System.DateTime Fecha { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pregunta> Pregunta { get; set; }
    }
}
