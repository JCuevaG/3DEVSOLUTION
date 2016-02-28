using _3DEV.MODELS;
using System.Data.Entity.ModelConfiguration;

namespace _3DEV.DATA.Configuration
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {            
            this.Property(p => p.ProductName).IsRequired().HasMaxLength(50);
            this.Property(p => p.Price).IsOptional();
            this.Property(p => p.Description).IsRequired().HasMaxLength(250);
            this.Property(p => p.Quantity).IsRequired();
        }
    }
}
