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
    
    public partial class Timetable
    {
        public int Id { get; set; }
        public Nullable<bool> Monday { get; set; }
        public Nullable<bool> Thuesday { get; set; }
        public Nullable<bool> Wednesday { get; set; }
        public Nullable<bool> Thursday { get; set; }
        public Nullable<bool> Friday { get; set; }
        public Nullable<bool> Saturday { get; set; }
        public Nullable<bool> Sunday { get; set; }
        public Nullable<int> IdEmoloyee { get; set; }
        public Nullable<int> IdService { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Services Services { get; set; }
    }
}
