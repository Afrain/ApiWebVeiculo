using System.ComponentModel.DataAnnotations;

namespace ApiWebVeiculo.Models.Dtos
{
    public class VeiculoRequestDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Marca é obrigatório!")]
        public string? Marca { get; set; }

        [Required(ErrorMessage = "Ano é obrigatório!")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório!")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Cor é obrigatório!")]
        public string? Cor { get; set; }
    }
}
