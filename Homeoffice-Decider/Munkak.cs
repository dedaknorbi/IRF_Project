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
        public Nullable<int> dolgozott_orak { get; set; }
        public Nullable<int> megkotott_szerzodesek { get; set; }
    
        public virtual Ugynokok Ugynokok { get; set; }
    }
}