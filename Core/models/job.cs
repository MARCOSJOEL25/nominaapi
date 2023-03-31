using System.ComponentModel.DataAnnotations;

namespace core.models
{
    public class job
    {
        [Key]
        public int Id { get; set; }

        public string nameJob { get; set; }
    }
}