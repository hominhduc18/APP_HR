using ItoApp.Domain.Common;

namespace ItoApp.Domain.Entities
{
    public class Specialty : BaseEntity
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public string? IconUrl { get; private set; }
        public bool IsActive { get; private set; }

        public virtual ICollection<Doctor> Doctors { get; private set; } = new List<Doctor>();

        private Specialty() { }

        public Specialty(string name, string? description = null, string? iconUrl = null)
        {
            Name = name;
            Description = description;
            IconUrl = iconUrl;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateInfo(string name, string? description, string? iconUrl)
        {
            Name = name;
            Description = description;
            IconUrl = iconUrl;
            UpdateTimestamp();
        }

        public void Deactivate()
        {
            IsActive = false;
            UpdateTimestamp();
        }
    }
}
