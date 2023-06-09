﻿using ApiWebVeiculo.Models;
using ApiWebVeiculo.Models.Dtos;
using ApiWebVeiculo.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebVeiculo.Controller
{
    [Route("api/veiculos")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoController(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Veiculo>>> BuscarTodosVeiculos()
        {
            List<Veiculo> veiculos = await _veiculoRepository.BuscarTodosVeiculos();
            return Ok(veiculos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Veiculo>>> BuscarVeiculoId(int id)
        {
            Veiculo veiculo = await _veiculoRepository.BuscarVeiculoId(id);
            return Ok(veiculo);
        }

        [HttpPost]
        public async Task<ActionResult<Veiculo>> SalvarVeiculo(VeiculoRequestDTO veiculoRequestDTO)
        {
            var veiculo = DtoToObjeto(veiculoRequestDTO);
            Veiculo veiculoSalvo = await _veiculoRepository.SalvarVeiculo(veiculo);
            return StatusCode(StatusCodes.Status201Created, veiculoSalvo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Veiculo>> AlterarVeiculo(VeiculoRequestDTO veiculoRequestDTO, int id)
        {
            var veiculo = DtoToObjeto(veiculoRequestDTO);
            Veiculo veiculoAlterado = await _veiculoRepository.AlterarVeiculo(veiculo, id);
            return StatusCode(StatusCodes.Status204NoContent, veiculoAlterado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ExcluirVeiculo(int id)
        {
            await _veiculoRepository.ExcluirVeiculo(id);
            return NoContent();
        }
        private static Veiculo DtoToObjeto(VeiculoRequestDTO veiculoRequestDTO)
        {
            return new Veiculo
            {
                Nome = veiculoRequestDTO.Nome,
                Marca = veiculoRequestDTO.Marca,
                Ano = veiculoRequestDTO.Ano,
                Preco = veiculoRequestDTO.Preco,
                Cor = veiculoRequestDTO.Cor
            };
        }
    }
}
