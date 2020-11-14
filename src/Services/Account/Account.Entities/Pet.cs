using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Account.API.Entities
{
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PetId { get; set; }
        public int UserId { get; set; }
        public string PetName { get; set; }
        public int ImageId { get; set; }
        public bool IsMail { get; set; }
        public string Breed { get; set; }
        public AnimalType AnimalType { get; set; }
        public string AboutMe { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AnimalType
    {
        Cat,
        Dog
    }
}