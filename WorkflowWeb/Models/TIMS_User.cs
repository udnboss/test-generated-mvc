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
    
    public partial class TIMS_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIMS_User()
        {
            this.TIMS_ProjectActionItemWorkflow = new HashSet<TIMS_ProjectActionItemWorkflow>();
            this.TIMS_ProjectAttachment = new HashSet<TIMS_ProjectAttachment>();
            this.TIMS_ProjectComment = new HashSet<TIMS_ProjectComment>();
            this.TIMS_ProjectInterfaceAgreementWorkflow = new HashSet<TIMS_ProjectInterfaceAgreementWorkflow>();
            this.TIMS_ProjectInterfacePointWorkflow = new HashSet<TIMS_ProjectInterfacePointWorkflow>();
            this.TIMS_UserRole = new HashSet<TIMS_UserRole>();
            this.TIMS_UserWatchlistItem = new HashSet<TIMS_UserWatchlistItem>();
        }
    
        public System.Guid ID { get; set; }
        public string Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMS_ProjectActionItemWorkflow> TIMS_ProjectActionItemWorkflow { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMS_ProjectAttachment> TIMS_ProjectAttachment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMS_ProjectComment> TIMS_ProjectComment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMS_ProjectInterfaceAgreementWorkflow> TIMS_ProjectInterfaceAgreementWorkflow { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMS_ProjectInterfacePointWorkflow> TIMS_ProjectInterfacePointWorkflow { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMS_UserRole> TIMS_UserRole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMS_UserWatchlistItem> TIMS_UserWatchlistItem { get; set; }
    }
}
