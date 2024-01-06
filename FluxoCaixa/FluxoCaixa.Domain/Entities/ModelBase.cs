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
        public DateTime? CreateAt { get; private set; }

        [JsonIgnore]
        public DateTime? UpdateAt { get; private set; }

        [JsonIgnore]
        public DateTime? RemoveAt { get; private set; }

        public void SetCreateAtDate() { CreateAt = DateTime.Now; }
        public void SetUpdateAtDate() { UpdateAt = DateTime.Now; }
        public void SetRemoveAtDate() { RemoveAt = DateTime.Now; }
    }
}
