using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Domain.BaseEntities;

public class BaseEntity<TKey>
{
    [Key]
    public TKey Id { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime ModifyTime { get; set; }
    public bool IsDeleted { get; set; }
}