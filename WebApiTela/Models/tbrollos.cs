//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiTela.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbrollos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbrollos()
        {
            this.tbswatch = new HashSet<tbswatch>();
        }
    
        public int idrollo { get; set; }
        public string rolloName { get; set; }
        public Nullable<double> ydastotal { get; set; }
        public Nullable<double> ydsrestantes { get; set; }
        public Nullable<int> sec { get; set; }
        public string estado { get; set; }
        public Nullable<int> idpoCont { get; set; }
        public Nullable<int> idtpc { get; set; }
        public byte[] timesp { get; set; }
        public Nullable<double> ancho { get; set; }
        public string tono { get; set; }
        public Nullable<bool> @lock { get; set; }
        public string sec2 { get; set; }
        public string proceso { get; set; }
        public string etiqueta { get; set; }
    
        public virtual tbPoCont tbPoCont { get; set; }
        public virtual tbtelaprocol tbtelaprocol { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbswatch> tbswatch { get; set; }
    }
}
