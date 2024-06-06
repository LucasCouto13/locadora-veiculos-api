namespace LocadoraVeiculosApi.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public string? Sexo { get; set; }
        public string? Email { get; set; }
        public required string Telefone { get; set; }
    }
}
