namespace Recipes.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Recipe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recipe()
        {
            Recipe2Ingredient2Measurement = new HashSet<Recipe2Ingredient2Measurement>();
        }

        [Key]
        public int recId { get; set; }

        [Required]
        public string recName { get; set; }

        [Required]
        public string recDescription { get; set; }

        public byte[] recImage { get; set; }

        [Required]
        public string recDirections { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recipe2Ingredient2Measurement> Recipe2Ingredient2Measurement { get; set; }
    }
}
