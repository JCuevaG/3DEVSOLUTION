using _3DEV.MODELS;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEV.DATA.Configuration
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            this.ToTable("webpages_Roles");
            this.Property(p => p.RoleName).HasMaxLength(256).IsRequired();
        }
    }
}
