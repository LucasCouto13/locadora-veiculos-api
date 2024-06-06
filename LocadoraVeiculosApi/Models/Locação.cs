namespace LocadoraVeiculosApi.Models
{
    public class Locação
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public required string Status { get; set; }
        public string? Avaliacao { get; set; }

        public Veiculo Veiculo { get; set; }
        public int VeiculoId { get; set; }

        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

    }
}
