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
    
    public partial class TIMS_ProjectAttachment
    {
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> ProjectInterfacePointWorkflowID { get; set; }
        public Nullable<System.Guid> ProjectInterfaceAgreementWorkflowID { get; set; }
        public Nullable<System.Guid> ProjectActionItemWorkflowID { get; set; }
        public Nullable<System.Guid> PackageID { get; set; }
        public string Filename { get; set; }
        public Nullable<System.DateTime> DateUploaded { get; set; }
        public Nullable<System.Guid> UserID { get; set; }
    
        public virtual TIMS_ProjectActionItemWorkflow TIMS_ProjectActionItemWorkflow { get; set; }
        public virtual TIMS_ProjectInterfaceAgreementWorkflow TIMS_ProjectInterfaceAgreementWorkflow { get; set; }
        public virtual TIMS_ProjectInterfacePointWorkflow TIMS_ProjectInterfacePointWorkflow { get; set; }
        public virtual TIMS_ProjectPackage TIMS_ProjectPackage { get; set; }
        public virtual TIMS_User TIMS_User { get; set; }
    }
}