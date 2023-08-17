using DumplingManager.Data.Entities;

namespace DumplingManager.Application.Utils
{
    public static class BaseEntitiesExtention
    {
        public static void CreatedData(this BaseEntity entity, Guid userId)
        {
            entity.Id = Guid.NewGuid();
            entity.TimeCreated = DateTime.Now;
        }

        public static void ModifiedData(this BaseEntity entity, Guid userId)
        {
            entity.TimeModified = DateTime.Now;
        }
    }
}
