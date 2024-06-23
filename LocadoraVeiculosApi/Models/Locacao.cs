using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraVeiculosApi.Models
{
    public class Locacao
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public required string Status { get; set; }
        public string? Avaliacao { get; set; }

        [ForeignKey("Veiculo")]
        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

    }
}
