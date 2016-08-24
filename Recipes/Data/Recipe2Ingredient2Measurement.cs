namespace Recipes.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Recipe2Ingredient2Measurement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rimId { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rimINGid { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rimMEAid { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rimRECid { get; set; }

        public decimal rimQuantity { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        public virtual Measurement Measurement { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
