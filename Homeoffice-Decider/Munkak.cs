//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Homeoffice_Decider
{
    using System;
    using System.Collections.Generic;
    
    public partial class Munkak
    {
        public int munka_sk { get; set; }
        public int ugynok_fk { get; set; }
        public Nullable<int> h1_dolgozott_orak { get; set; }
        public Nullable<int> h1_szerzodesek { get; set; }
        public Nullable<int> h2_dolgozott_orak { get; set; }
        public Nullable<int> h2_szerzodesek { get; set; }
        public Nullable<int> h3_dolgozott_orak { get; set; }
        public Nullable<int> h3_szerzodesek { get; set; }
    
        public virtual Ugynokok Ugynokok { get; set; }
    }
}
