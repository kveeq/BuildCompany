//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BuildCompany.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zakaz
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> IdService { get; set; }
        public Nullable<int> IdUser { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> AcceptDate { get; set; }
        public Nullable<bool> Accept { get; set; }
        public Nullable<System.DateTime> ExitDate { get; set; }
        public Nullable<bool> Statuss { get; set; }
        public Nullable<int> IdEmployee { get; set; }
    
        public virtual Services Services { get; set; }
        public virtual User User { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
