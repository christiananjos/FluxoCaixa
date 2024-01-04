using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FluxoCaixa.Domain.Entities
{
    public abstract class ModelBase
    {
        public ModelBase()
        {
            Id = new Guid();   
        }
        [Key]
        public Guid Id { get; set; }
        
        [JsonIgnore]
        public DateTime CreateAt { get; set; }

        [JsonIgnore]
        public DateTime UpdateAt { get; set; }

        [JsonIgnore]
        public DateTime RemoveAt { get; set; }
    }
}
