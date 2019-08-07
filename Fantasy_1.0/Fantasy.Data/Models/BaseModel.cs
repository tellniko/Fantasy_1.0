using System.ComponentModel.DataAnnotations;

namespace Fantasy.Data.Models
{
    public class BaseModel<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
