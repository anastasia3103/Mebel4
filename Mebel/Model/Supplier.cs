//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mebel.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplier
    {
        public Supplier()
        {
            this.Accessories = new HashSet<Accessories>();
            this.Material = new HashSet<Material>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public Nullable<int> TermDelivery { get; set; }
    
        public virtual ICollection<Accessories> Accessories { get; set; }
        public virtual ICollection<Material> Material { get; set; }
    }
}
