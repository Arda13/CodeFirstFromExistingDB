namespace FluentAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FluentModel : DbContext
    {
        public FluentModel()
            : base("name=FluentModel")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Courses)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.Category_Id);

            modelBuilder.Entity<Cours>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("CourseTags").MapLeftKey("Course_Id"));

            modelBuilder.Entity<Cours>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Cours>()
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);


            modelBuilder.Entity<Cours>()
                 .HasRequired(c => c.Author)
                 .WithMany(a => a.Courses)
                 .HasForeignKey(c => c.AuthorId)
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cours>()
                .HasRequired(c => c.Cover)
                .WithRequiredPrincipal(c => c.Cours);


        }
    }
}
