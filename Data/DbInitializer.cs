using OcuHubBackend.Models;

namespace OcuHubBackend.Data
{
    public static class DbInitializer
    {
        public static void SeedData(OcuHubDbContext context)
        {
            if (!context.UserRoles.Any())
            {
                var roles = new List<UserRole>
                {
                    new() { Id = Guid.NewGuid(), Name = "Admin" },
                    new() { Id = Guid.NewGuid(), Name = "Doctor" },
                    new() { Id = Guid.NewGuid(), Name = "Optometrist" },
                    new() { Id = Guid.NewGuid(), Name = "Nurse" }
                };
                context.UserRoles.AddRange(roles);
            }

            if (!context.ToolCategories.Any())
            {
                var categories = new List<ToolCategory>
                {
                    new() { Id = Guid.NewGuid(), Name = "Pediatric" },
                    new() { Id = Guid.NewGuid(), Name = "Glaucoma" },
                    new() { Id = Guid.NewGuid(), Name = "Optometry" },
                    new() { Id = Guid.NewGuid(), Name = "Strabismus" },
                    new() { Id = Guid.NewGuid(), Name = "Neuro" },
                    new() { Id = Guid.NewGuid(), Name = "Anterior Segment & Refractive" }
                };
                context.ToolCategories.AddRange(categories);
            }

            context.SaveChanges();
        }
    }
}