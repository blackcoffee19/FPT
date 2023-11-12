﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext <AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category>? Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Cat chuoi Aspnet truoc ten table
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tblName = entityType.GetTableName();
                if (tblName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tblName.Substring(6));
                }
            }
        }
    }
}