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
    
    public partial class TIMS_ProjectInterfaceAgreementWorkflow
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIMS_ProjectInterfaceAgreementWorkflow()
        {
            this.TIMS_ProjectAttachment = new HashSet<TIMS_ProjectAttachment>();
            this.TIMS_ProjectComment = new HashSet<TIMS_ProjectComment>();
        }
    
        public System.Guid ID { get; set; }
        public string WorkflowTypeID { get; set; }
        public Nullable<System.Guid> InterfaceAgreementID { get; set; }
        public Nullable<System.DateTime> DateInitiated { get; set; }
        public string LeadStateID { get; set; }
        public string InterfaceStateID { get; set; }
        public Nullable<System.Guid> UserID { get; set; }
        public Nullable<bool> IsDraft { get; set; }
        public Nullable<System.Guid> DisciplineID { get; set; }
        public Nullable<System.Guid> SystemID { get; set; }
        public Nullable<System.Guid> AreaID { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
    
        public virtual TIMS_ProjectArea TIMS_ProjectArea { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMS_ProjectAttachment> TIMS_ProjectAttachment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMS_ProjectComment> TIMS_ProjectComment { get; set; }
        public virtual TIMS_ProjectDiscipline TIMS_ProjectDiscipline { get; set; }
        public virtual TIMS_ProjectInterfaceAgreement TIMS_ProjectInterfaceAgreement { get; set; }
        public virtual TIMS_User TIMS_User { get; set; }
        public virtual TIMS_WorkflowType TIMS_WorkflowType { get; set; }
    }
}
