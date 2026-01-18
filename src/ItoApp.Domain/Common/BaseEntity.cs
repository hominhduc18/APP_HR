namespace ItoApp.Domain.Common;

public abstract class BaseEntity
{
   private readonly List<BaseEvent>  _domainEvents  = new List<BaseEvent>();
   
   public Guid Id { get; protected set; } = Guid.NewGuid();
   public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
   public DateTime? UpdatedAt { get; protected set; }
        
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