using System.ComponentModel.DataAnnotations;

namespace ApiWebVeiculo.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Marca { get; set; }
        public int Ano { get; set; }
        public decimal Preco { get; set; }
        public string? Cor { get; set; }
    }
}
