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
    
    public partial class Material
    {
        public Material()
        {
            this.SpecificationMaterials = new HashSet<SpecificationMaterials>();
        }
    
        public string Article { get; set; }
        public string Title { get; set; }
        public Nullable<int> UnitMeasurement { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<int> Supplier { get; set; }
        public string Image { get; set; }
        public Nullable<int> TypeOfMaterialId { get; set; }
        public Nullable<decimal> PurchasePrice { get; set; }
        public string GOST { get; set; }
        public Nullable<int> Height { get; set; }
        public string Characteristic { get; set; }
        public Nullable<int> QualityMaterialId { get; set; }
    
        public virtual QualityMaterial QualityMaterial { get; set; }
        public virtual Supplier Supplier1 { get; set; }
        public virtual TypeOfMaterial TypeOfMaterial { get; set; }
        public virtual UnitOfMeasurementMaterial UnitOfMeasurementMaterial { get; set; }
        public virtual ICollection<SpecificationMaterials> SpecificationMaterials { get; set; }
    }
}
