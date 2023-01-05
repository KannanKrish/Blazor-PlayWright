namespace BlazorApp.Data;

public abstract class BaseEntity : IBaseEntity<Guid>, IDbEventLog, IDbBackup, IDynamicColumn
{
    public Guid Id { get; set; }
}