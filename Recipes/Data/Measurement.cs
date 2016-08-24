namespace Recipes.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Measurement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Measurement()
        {
            Recipe2Ingredient2Measurement = new HashSet<Recipe2Ingredient2Measurement>();
        }

        [Key]
        public int meaId { get; set; }

        [Required]
        public string meaName { get; set; }

        [Required]
        [StringLength(50)]
        public string meaAbbreviation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recipe2Ingredient2Measurement> Recipe2Ingredient2Measurement { get; set; }
    }
}
