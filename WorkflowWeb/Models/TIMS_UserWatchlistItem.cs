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
    
    public partial class TIMS_UserWatchlistItem
    {
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> UserID { get; set; }
        public Nullable<System.Guid> ProjectInterfacePointID { get; set; }
        public Nullable<System.Guid> ProjectInterfaceAgreementID { get; set; }
        public Nullable<System.Guid> ProjectActionItemID { get; set; }
    
        public virtual TIMS_ProjectActionItem TIMS_ProjectActionItem { get; set; }
        public virtual TIMS_ProjectInterfaceAgreement TIMS_ProjectInterfaceAgreement { get; set; }
        public virtual TIMS_ProjectInterfacePoint TIMS_ProjectInterfacePoint { get; set; }
        public virtual TIMS_User TIMS_User { get; set; }
    }
}
