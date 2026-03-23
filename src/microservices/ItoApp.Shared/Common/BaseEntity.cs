namespace ItoApp.Shared.Common;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public abstract class BaseEntity
{
   private readonly List<BaseEvent>  _domainEvents  = new List<BaseEvent>();
   
   [Key]
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   public int Id { get; protected set; }
   public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
   public DateTime? UpdatedAt { get; set; }
         
   public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();
         
   protected void AddDomainEvent(BaseEvent domainEvent)
   {
      _domainEvents.Add(domainEvent);
   }
         
   public void ClearDomainEvents()
   {
      _domainEvents.Clear();
   }
         
   protected void UpdateTimestamp()
   {
      UpdatedAt = DateTime.UtcNow;
   }
}
