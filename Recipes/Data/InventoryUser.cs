namespace Recipes.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InventoryUser")]
    public partial class InventoryUser
    {
        [Key]
        public int useId { get; set; }

        [Required]
        public string useLogin { get; set; }

        [Required]
        public string usePassword { get; set; }

        [Required]
        public string useFirstName { get; set; }

        [Required]
        public string useLastName { get; set; }

        [Required]
        public string useEmail { get; set; }

        [Required]
        public string useCellPhone { get; set; }

        public int useSQ1id { get; set; }

        public int useSQ2id { get; set; }

        public int useSQ3id { get; set; }

        [Required]
        public string useAnswer1 { get; set; }

        [Required]
        public string useAnswer2 { get; set; }

        [Required]
        public string useAnswer3 { get; set; }

        public int useROLid { get; set; }

        public virtual SecurityQuestion SecurityQuestion { get; set; }

        public virtual SecurityQuestion SecurityQuestion1 { get; set; }

        public virtual SecurityQuestion SecurityQuestion2 { get; set; }

        public virtual SecurityRole SecurityRole { get; set; }
    }
}
