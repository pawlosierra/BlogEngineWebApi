using BlogEngineWebApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BlogEngineWebApi.Infrastructure.Data
{
  public partial class BlogEngineContext : DbContext
    {
        public BlogEngineContext()
        {
        }

        public BlogEngineContext(DbContextOptions<BlogEngineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryModel> CategoryModels { get; set; }
        public virtual DbSet<PostModel> PostModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-9LJ95CE; Database=BlogEngine; Trusted_Connection=True; User=sa; Password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CategoryModel>(entity =>
            {
                entity.ToTable("CategoryModel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PostModel>(entity =>
            {
                entity.ToTable("PostModel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.IdCategory).HasColumnName("Id_Category");

                entity.Property(e => e.PublicationDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.PostModels)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostModel_CategoryModel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
