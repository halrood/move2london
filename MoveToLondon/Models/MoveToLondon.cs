namespace MoveToLondon.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MoveToLondon : DbContext
    {
        public MoveToLondon()
            : base("name=MoveToLondon1")
        {
        }

        public virtual DbSet<RoomPhoto> RoomPhotos { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomsPhotosBridge> RoomsPhotosBridges { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomPhoto>()
                .HasMany(e => e.RoomsPhotosBridges)
                .WithRequired(e => e.RoomPhoto)
                .HasForeignKey(e => e.PhotoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.RoomsPhotosBridges)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserProfile>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserProfile>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserProfile>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
