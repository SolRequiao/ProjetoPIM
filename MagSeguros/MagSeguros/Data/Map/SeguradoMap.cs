using MagSeguros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MagSeguros.Data.Map
{
    public class SeguradoMap : IEntityTypeConfiguration<SeguradoModel>
    {
        public void Configure(EntityTypeBuilder<SeguradoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Funcionario);
        }
    }
}
