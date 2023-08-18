
namespace GameOver.Models
{
    public class Device : BaseEntity
    {
        [MaxLength(255)]
        public string Icon { get; set; } = string.Empty;
    }
}
