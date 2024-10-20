using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project_Fitness.Server.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ContactU> ContactUs { get; set; }

    public virtual DbSet<FitnessClass> FitnessClasses { get; set; }

    public virtual DbSet<Gym> Gyms { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<SubRecipe> SubRecipes { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<Testimonial> Testimonials { get; set; }

    public virtual DbSet<Tip> Tips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-NNTQNVK;Database=FitnessProject;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cart__3214EC275DC391A5");

            entity.ToTable("Cart");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Cart__UserID__5165187F");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CartItem__3214EC2700C9E00B");

            entity.ToTable("CartItem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            //entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
            //    .HasForeignKey(d => d.CartId)
            //    .HasConstraintName("FK__CartItem__CartID__5535A963");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__CartItem__Produc__5629CD9C");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC27A8719DFB");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<ContactU>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContactU__3214EC276858AA6E");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Subject).HasMaxLength(500);
            entity.Property(e => e.UsersId).HasColumnName("UsersID");

            entity.HasOne(d => d.Users).WithMany(p => p.ContactUs)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("FK__ContactUs__Users__6477ECF3");
        });

        modelBuilder.Entity<FitnessClass>(entity =>
        {
            entity.HasKey(e => e.FitnessClassesId).HasName("PK__fitnessC__1C833396EAECB030");

            entity.ToTable("fitnessClasses");

            entity.Property(e => e.FitnessClassesId).HasColumnName("fitnessClasses_id");
            entity.Property(e => e.Days).HasMaxLength(100);
            entity.Property(e => e.FitnessClassesDescription).HasColumnName("fitnessClasses_description");
            entity.Property(e => e.FitnessClassesImage).HasColumnName("fitnessClasses_image");
            entity.Property(e => e.FitnessClassesLocation)
                .HasMaxLength(100)
                .HasColumnName("fitnessClasses_location");
            entity.Property(e => e.FitnessClassesName)
                .HasMaxLength(255)
                .HasColumnName("fitnessClasses_name");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Gym>(entity =>
        {
            entity.HasKey(e => e.GymId).HasName("PK__Gym__3165AAC69B4A0348");

            entity.ToTable("Gym");

            entity.Property(e => e.GymId).HasColumnName("Gym_id");
            entity.Property(e => e.EndTime).HasMaxLength(100);
            entity.Property(e => e.GymDescription).HasColumnName("Gym_description");
            entity.Property(e => e.GymImage).HasColumnName("Gym_image");
            entity.Property(e => e.GymLocation)
                .HasMaxLength(100)
                .HasColumnName("Gym_location");
            entity.Property(e => e.GymName)
                .HasMaxLength(255)
                .HasColumnName("Gym_name");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StartTime).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC27C30173CF");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__UserID__03F0984C");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC2724E4109C");

            entity.ToTable("OrderItem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__OrderItem__Order__08B54D69");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderItem__Produ__09A971A2");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payments__3214EC279D8E0C1B");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasColumnName("TransactionID");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Payments__OrderI__0C85DE4D");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC2705B6D021");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Discount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__4D94879B");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PK__recipes__3571ED9BF428506E");

            entity.ToTable("recipes");

            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.RecipeImage).HasColumnName("recipe_image");
            entity.Property(e => e.RecipeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("recipe_name");
        });

        modelBuilder.Entity<SubRecipe>(entity =>
        {
            entity.HasKey(e => e.SubRecipeId).HasName("PK__sub_reci__339FCE442ABFF425");

            entity.ToTable("sub_recipes");

            entity.Property(e => e.SubRecipeId).HasColumnName("sub_recipe_id");
            entity.Property(e => e.Benefits)
                .HasMaxLength(255)
                .HasColumnName("benefits");
            entity.Property(e => e.PreparationSteps).HasColumnName("preparation_steps");
            entity.Property(e => e.PreparationTime)
                .HasMaxLength(50)
                .HasColumnName("preparation_time");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.SubRecipeImage).HasColumnName("sub_recipe_image");
            entity.Property(e => e.SubRecipeName)
                .HasMaxLength(100)
                .HasColumnName("sub_recipe_name");

            entity.HasOne(d => d.Recipe).WithMany(p => p.SubRecipes)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("recipes_fk");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.SubscriptionId).HasName("PK__Subscrip__51874679EF7F342F");

            entity.ToTable("Subscription");

            entity.Property(e => e.SubscriptionId).HasColumnName("Subscription_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FitnessClassesId).HasColumnName("fitnessClasses_id");
            entity.Property(e => e.GymId).HasColumnName("Gym_id");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SubscriptionEndDate).HasColumnName("Subscription_EndDate");
            entity.Property(e => e.SubscriptionStartDate).HasColumnName("Subscription_StartDate");
            entity.Property(e => e.UserId).HasColumnName("User_id");

            entity.HasOne(d => d.FitnessClasses).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.FitnessClassesId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Subscript__fitne__48CFD27E");

            entity.HasOne(d => d.Gym).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.GymId)
                .HasConstraintName("FK__Subscript__Gym_i__47DBAE45");

            entity.HasOne(d => d.User).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subscript__User___46E78A0C");
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.HasKey(e => e.TestimonialId).HasName("PK__Testimon__D2FDAA23A86AEAE8");

            entity.ToTable("Testimonial");

            entity.Property(e => e.TestimonialId).HasColumnName("Testimonial_id");
            entity.Property(e => e.CreatedTestimonialAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsAccept)
                .HasDefaultValue(false)
                .HasColumnName("is_accept");
            entity.Property(e => e.TestimonialMessege).HasColumnName("Testimonial_messege");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Testimonials)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Testimoni__UserI__68487DD7");
        });

        modelBuilder.Entity<Tip>(entity =>
        {
            entity.HasKey(e => e.TipsId).HasName("PK__tips__95F7D39544E89A73");

            entity.ToTable("tips");

            entity.Property(e => e.TipsId).HasColumnName("tips_id");
            entity.Property(e => e.TipsDescription).HasColumnName("tips_description");
            entity.Property(e => e.TipsImage).HasColumnName("tips_image");
            entity.Property(e => e.TipsName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tips_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__206A9DF875160B94");

            entity.HasIndex(e => e.UserEmail, "UQ__Users__EB5FD346C2CFF1A5").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("User_id");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.HashPassword).HasMaxLength(255);
            entity.Property(e => e.IsAdmin)
                .HasDefaultValue(false)
                .HasColumnName("is_admin");
            entity.Property(e => e.IsBlocked)
                .HasDefaultValue(false)
                .HasColumnName("is_blocked");
            entity.Property(e => e.SaltPassword)
                .HasMaxLength(255)
                .HasColumnName("saltPassword");
            entity.Property(e => e.UserAddress)
                .HasMaxLength(100)
                .HasColumnName("User_Address");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .HasColumnName("User_email");
            entity.Property(e => e.UserImage)
                .IsUnicode(false)
                .HasColumnName("User_image");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasColumnName("User_name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(255)
                .HasColumnName("User_Password");
            entity.Property(e => e.UserPhone)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("User_phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
