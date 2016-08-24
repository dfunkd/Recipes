namespace Recipes.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RecipesModel : DbContext
    {
        public RecipesModel()
            : base("name=RecipesModel")
        {
        }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<InventoryUser> InventoryUsers { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<Recipe2Ingredient2Measurement> Recipe2Ingredient2Measurement { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public virtual DbSet<SecurityRole> SecurityRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>()
                .HasMany(e => e.Recipe2Ingredient2Measurement)
                .WithRequired(e => e.Ingredient)
                .HasForeignKey(e => e.rimINGid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Measurement>()
                .HasMany(e => e.Recipe2Ingredient2Measurement)
                .WithRequired(e => e.Measurement)
                .HasForeignKey(e => e.rimMEAid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Recipe2Ingredient2Measurement>()
                .Property(e => e.rimQuantity)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Recipe>()
                .HasMany(e => e.Recipe2Ingredient2Measurement)
                .WithRequired(e => e.Recipe)
                .HasForeignKey(e => e.rimRECid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityQuestion>()
                .HasMany(e => e.InventoryUsers)
                .WithRequired(e => e.SecurityQuestion)
                .HasForeignKey(e => e.useSQ1id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityQuestion>()
                .HasMany(e => e.InventoryUsers1)
                .WithRequired(e => e.SecurityQuestion1)
                .HasForeignKey(e => e.useSQ2id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityQuestion>()
                .HasMany(e => e.InventoryUsers2)
                .WithRequired(e => e.SecurityQuestion2)
                .HasForeignKey(e => e.useSQ3id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityRole>()
                .HasMany(e => e.InventoryUsers)
                .WithRequired(e => e.SecurityRole)
                .HasForeignKey(e => e.useROLid)
                .WillCascadeOnDelete(false);
        }
    }
}
