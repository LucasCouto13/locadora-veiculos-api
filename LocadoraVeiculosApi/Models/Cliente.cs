using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraVeiculosApi.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public string? Sexo { get; set; }
        public string? Email { get; set; }
        public required string Telefone { get; set; }

        [InverseProperty("Cliente")]
        public ICollection<Locacao>? Locacoes { get; set; }
    }
}
