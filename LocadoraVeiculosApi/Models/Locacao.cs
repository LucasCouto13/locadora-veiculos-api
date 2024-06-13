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

        [ForeignKey("VeiculoId")]
        public int VeiculoId { get; set; }
        public required Veiculo Veiculo { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public required Cliente Cliente { get; set; }

    }
}
