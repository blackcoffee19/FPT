using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SocialMediaPJ.Models;

public partial class SocialMediaContext : DbContext
{
    public SocialMediaContext()
    {
    }

    public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Library> Librarys { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Reaction> Reactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.,1433;Database=SocialMedia;trusted_connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3213E83F0DE1C92A");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.PostCmt)
                .HasColumnType("datetime")
                .HasColumnName("post_cmt");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__post_i__36B12243");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__user_i__35BCFE0A");
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Librarys__3213E83FF9DB380C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Image)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Post).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__Librarys__post_i__2F10007B");

            entity.HasOne(d => d.User).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Librarys__user_i__2E1BDC42");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Posts__3213E83F40C27682");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EditedAt)
                .HasColumnType("datetime")
                .HasColumnName("edited_at");
            entity.Property(e => e.Options)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("options");
            entity.Property(e => e.PostAt)
                .HasColumnType("datetime")
                .HasColumnName("post_at");
            entity.Property(e => e.TextPost)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("text_post");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Posts__user_id__2B3F6F97");
        });

        modelBuilder.Entity<Reaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reaction__3213E83FFC758F82");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.TypeReaction).HasColumnName("type_reaction");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Post).WithMany(p => p.Reactions)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reactions__post___32E0915F");

            entity.HasOne(d => d.User).WithMany(p => p.Reactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reactions__user___31EC6D26");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FD21BC6BE");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E6164C800A15E").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("bio");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Image)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('member')")
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
