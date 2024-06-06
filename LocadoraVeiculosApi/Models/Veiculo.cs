namespace LocadoraVeiculosApi.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public required string Placa { get; set; }
        public int Ano { get; set; }
        public string? Modelo { get; set; }
        public string? Marca { get; set; }
        public string? Sobre { get; set; }
        public bool Disponivel { get; set; }
    }
}
