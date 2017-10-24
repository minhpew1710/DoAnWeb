    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DTAShopDBContext : DbContext
    {
        public DTAShopDBContext() : base("name=DTAShop") { }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
    }