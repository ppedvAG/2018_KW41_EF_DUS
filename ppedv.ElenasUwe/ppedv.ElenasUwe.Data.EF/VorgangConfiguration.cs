// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace ppedv.ElenasUwe.Data.EF
{

    // Vorgang
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public class VorgangConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Vorgang>
    {
        public VorgangConfiguration()
            : this("dbo")
        {
        }

        public VorgangConfiguration(string schema)
        {
            ToTable("Vorgang", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Aktion).HasColumnName(@"Aktion").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.Zeit).HasColumnName(@"Zeit").HasColumnType("time").IsRequired();
            Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            Property(x => x.Created).HasColumnName(@"Created").HasColumnType("datetime").IsRequired();
            Property(x => x.Modified).HasColumnName(@"Modified").HasColumnType("datetime2").IsRequired();
            Property(x => x.ZubereitungId).HasColumnName(@"Zubereitung_Id").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Zubereitung).WithMany(b => b.Vorgangs).HasForeignKey(c => c.ZubereitungId); // FK_dbo.Vorgang_dbo.Zubereitung_Zubereitung_Id
        }
    }

}
// </auto-generated>