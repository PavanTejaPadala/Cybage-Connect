using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CybageConnect_API.Models;

public partial class CybageConnectDbContext : DbContext
{
    public CybageConnectDbContext()
    {
    }

    public CybageConnectDbContext(DbContextOptions<CybageConnectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArticlesOfUser> ArticlesOfUsers { get; set; }

    public virtual DbSet<BlogsOfUser> BlogsOfUsers { get; set; }

    public virtual DbSet<Connection> Connections { get; set; }

    public virtual DbSet<FriendRequest> FriendRequests { get; set; }

    public virtual DbSet<ListOfConnection> ListOfConnections { get; set; }

    public virtual DbSet<ProjectInsightsOfUser> ProjectInsightsOfUsers { get; set; }

    public virtual DbSet<RequestStorage> RequestStorages { get; set; }

    public virtual DbSet<UserRegistration> UserRegistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=GVC1387\\MSSQLSERVER2019;Initial Catalog=CybageConnectDB;Persist Security Info=True;User ID=sa;Password=cybage@123456;Encrypt=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArticlesOfUser>(entity =>
        {
            entity.HasKey(e => e.ArticleId).HasName("PK__Articles__9C6270E86F070DC8");

            entity.Property(e => e.Article).IsUnicode(false);
            entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BlogsOfUser>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__BlogsOfU__54379E30971EA8F6");

            entity.Property(e => e.Blog).IsUnicode(false);
            entity.Property(e => e.PublishedDateOfBlog)
                .HasColumnType("datetime")
                .HasColumnName("PublishedDateOfBLog");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Connection>(entity =>
        {
            entity.HasKey(e => e.ConnectId).HasName("PK__connecti__BC971B9C0C7289B3");

            entity.ToTable("connections");

            entity.HasOne(d => d.User).WithMany(p => p.Connections)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__connectio__UserI__33D4B598");
        });

        modelBuilder.Entity<FriendRequest>(entity =>
        {
            entity.HasKey(e => e.ReqId).HasName("PK__FriendRe__28A9A382B1DD79C0");

            entity.Property(e => e.RqstMessage)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SenderId).HasColumnName("senderID");

            entity.HasOne(d => d.Receiver).WithMany(p => p.FriendRequestReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("FK__FriendReq__Recei__30F848ED");

            entity.HasOne(d => d.Sender).WithMany(p => p.FriendRequestSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK__FriendReq__sende__300424B4");
        });

        modelBuilder.Entity<ListOfConnection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ListOfCo__3213E83FD0E5704B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ReceiverName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SenderId).HasColumnName("senderId");
            entity.Property(e => e.SenderName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("senderName");
        });

        modelBuilder.Entity<ProjectInsightsOfUser>(entity =>
        {
            entity.HasKey(e => e.ProjectInsightId).HasName("PK__ProjectI__AF5AA8B694F781BA");

            entity.Property(e => e.ProjectInsight).IsUnicode(false);
            entity.Property(e => e.PublishedDateOfProjectInsight).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RequestStorage>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Request___E9C5B373447CE7CF");

            entity.ToTable("Request_Storage");

            entity.Property(e => e.RequestId).HasColumnName("Request_Id");
            entity.Property(e => e.ConnectionStatus)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RequestReceiverId).HasColumnName("Request_ReceiverId");
            entity.Property(e => e.RequestSenderId).HasColumnName("Request_senderID");

            entity.HasOne(d => d.RequestReceiver).WithMany(p => p.RequestStorageRequestReceivers)
                .HasForeignKey(d => d.RequestReceiverId)
                .HasConstraintName("FK__Request_S__Reque__3B75D760");

            entity.HasOne(d => d.RequestSender).WithMany(p => p.RequestStorageRequestSenders)
                .HasForeignKey(d => d.RequestSenderId)
                .HasConstraintName("FK__Request_S__Reque__3A81B327");
        });

        modelBuilder.Entity<UserRegistration>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserRegi__1788CC4C4CFC38B7");

            entity.ToTable("UserRegistration", tb => tb.HasTrigger("ConnectionGenerator"));

            entity.HasIndex(e => e.MobileNumber, "UQ__UserRegi__250375B1F1FEF156").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__UserRegi__A9D10534C224F079").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__UserRegi__C9F284560E5F8445").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
