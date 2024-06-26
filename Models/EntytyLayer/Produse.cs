//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Magazin.Models.EntytyLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Produse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        private readonly MagazinEntities context;
        public Produse()
        {
            this.BonProdus = new HashSet<BonProdu>();
            this.Stocuris = new HashSet<Stocuri>();
            context = new MagazinEntities();
        }

        public int IDprodus { get; set; }
        public string nume_prod { get; set; }
        public string cod_bare { get; set; }
        public int producator { get; set; }
        public int categorie { get; set; }
        public bool active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BonProdu> BonProdus { get; set; }
        public virtual Categorii Categorii { get; set; }
        public virtual Producatori Producatori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stocuri> Stocuris { get; set; }

        public string ProducatorName
        {
            get
            {
                var producator = context.spGetProducatoriById(this.producator).FirstOrDefault();
                return producator?.nume_producator ?? "Unknown Producer";
            }
        }

        public string CategorieName
        {
            get
            {
                var categorie = context.spGetCategorieById(this.categorie).FirstOrDefault();
                return categorie?.categorie ?? "Unknown Category";
            }
        }
    }
}
