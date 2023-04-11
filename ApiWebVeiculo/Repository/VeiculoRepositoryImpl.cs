﻿using ApiWebVeiculo.Data;
using ApiWebVeiculo.Models;
using ApiWebVeiculo.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWebVeiculo.Repository
{
    public class VeiculoRepositoryImpl : IVeiculoRepository
    {
        private readonly VeiculoDBContext _dbContext;
        public VeiculoRepositoryImpl(VeiculoDBContext veiculoDBContext)
        {
            _dbContext = veiculoDBContext;
        }

        public async Task<List<Veiculo>> BuscarTodosVeiculos()
        {
            return await _dbContext.Veiculos.ToListAsync();
        }

        public async Task<Veiculo> BuscarVeiculoId(int id)
        {
            return await _dbContext.Veiculos.FirstOrDefaultAsync(veiculo => veiculo.Id == id);
        }

        public async Task<Veiculo> SalvarVeiculo(Veiculo veiculo)
        {
            await _dbContext.Veiculos.AddAsync(veiculo);
            await _dbContext.SaveChangesAsync();

            return veiculo;
        }
        public async Task<Veiculo> AlterarVeiculo(Veiculo veiculo, int id)
        {
            var veiculoBuscado = await BuscarVeiculoId(id);

            veiculoBuscado.Id = id;
            veiculoBuscado.Nome = veiculo.Nome;
            veiculoBuscado.Marca = veiculo.Marca;
            veiculoBuscado.Ano = veiculo.Ano;
            veiculo.Preco = veiculo.Preco;
            veiculo.Cor = veiculo.Cor;

            await _dbContext.Veiculos.AddAsync(veiculoBuscado);
            await _dbContext.SaveChangesAsync();

            return veiculo;
        }

        public async Task<bool> ExcluirVeiculo(int id)
        {
            var veiculoBuscado = await BuscarVeiculoId(id);
            _dbContext.Veiculos.Remove(veiculoBuscado);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}