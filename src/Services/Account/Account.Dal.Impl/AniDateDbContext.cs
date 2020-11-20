using System.Data;
using Account.API.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Npgsql.NameTranslation;

namespace Account.Dal.Impl
{
    public class AniDateDbContext: DbContext
    {
        public AniDateDbContext(DbContextOptions<AniDateDbContext> options)
            : base(options)
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<DbType>(
                nameof(DbType),
                new NpgsqlNullNameTranslator()
            );
        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Image> Images { get; set; }
        
         protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasPostgresEnum(nameof(DbType), typeof(DbType).GetEnumNames());

            // PET
            builder.Entity<Pet>().HasKey(c => new { c.PetId });

            builder.Entity<Pet>()
                .HasIndex(c => c.UserId)
                .IsUnique();

            builder.Entity<Image>().HasKey(c => new { c.ImageId });
            
            builder.Entity<Image>()
                .HasOne(c => c.Pet)
                .WithMany()
                .HasForeignKey(c => new { c.PetId})
                .OnDelete(DeleteBehavior.Restrict);
 
        }
    }
}