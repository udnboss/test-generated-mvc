//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkflowWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TIMS_ProjectArea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIMS_ProjectArea()
        {
            this.TIMS_ProjectInterfaceAgreementWorkflow = new HashSet<TIMS_ProjectInterfaceAgreementWorkflow>();
            this.TIMS_ProjectInterfacePointWorkflow = new HashSet<TIMS_ProjectInterfacePointWorkflow>();
        }
    
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> ProjectID { get; set; }
    
        public virtual TIMS_Project TIMS_Project { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMS_ProjectInterfaceAgreementWorkflow> TIMS_ProjectInterfaceAgreementWorkflow { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMS_ProjectInterfacePointWorkflow> TIMS_ProjectInterfacePointWorkflow { get; set; }
    }
}