using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumplingManager.Data.Configurations
{
    public static class ConfigurationExtentions
    {
        public static void AddBaseProperties(this EntityTypeBuilder builder)
        {
            builder.HasKey("Id");
            builder.Property("Note").IsRequired(false);
            //builder.Property("UserModifiedId").IsRequired(false);
            //builder.Property("TimeModified").IsRequired(false);
        }
    }
}
