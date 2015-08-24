namespace MoveToLondon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoomPhotos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoomsPhotosBridge",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        PhotoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .ForeignKey("dbo.RoomPhotos", t => t.PhotoId)
                .Index(t => t.RoomId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        RoomType = c.String(),
                        AvailabilityStatus = c.String(),
                        RentPerMonth = c.Int(nullable: false),
                        BookingFee = c.Int(nullable: false),
                        Address = c.String(),
                        Description = c.String(),
                        IsFrench = c.Boolean(nullable: false),
                        RoomSequence = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100, unicode: false),
                        UserName = c.String(nullable: false, maxLength: 100, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomsPhotosBridge", "PhotoId", "dbo.RoomPhotos");
            DropForeignKey("dbo.RoomsPhotosBridge", "RoomId", "dbo.Rooms");
            DropIndex("dbo.RoomsPhotosBridge", new[] { "PhotoId" });
            DropIndex("dbo.RoomsPhotosBridge", new[] { "RoomId" });
            DropTable("dbo.UserProfile");
            DropTable("dbo.Rooms");
            DropTable("dbo.RoomsPhotosBridge");
            DropTable("dbo.RoomPhotos");
        }
    }
}
