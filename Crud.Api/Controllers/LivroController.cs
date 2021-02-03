using AutoMapper;
using Crud.Domain.Dtos;
using Crud.Domain.Entities;
using Crud.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly IServiceLivro _serviceLivro;
        private readonly IMapper _mapper;

        public LivroController(IServiceLivro serviceLivro, IMapper mapper)
        {
            _serviceLivro = serviceLivro;
            _mapper = mapper;
        }

        [HttpGet("{idCategoria}")]
        public async Task<IActionResult> BuscarTodos(int IdCategoria)
        {
            return Ok(await _serviceLivro.BuscarTodos(IdCategoria));
        }

        [HttpGet]
        [Route("obter/{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            return Ok(await _serviceLivro.BuscarPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(LivroDadosDto livroDadosDto)
        {
            Livro livro = _mapper.Map<LivroDadosDto, Livro>(livroDadosDto);
            return Ok(await _serviceLivro.Add(livro));
        }

        [HttpPut]
        public async Task<IActionResult> Update(LivroDadosDto livroDadosDto)
        {
            Livro livro = _mapper.Map<LivroDadosDto, Livro>(livroDadosDto);
            return Ok(await _serviceLivro.Update(livro));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            await _serviceLivro.Delete(id);
            return Ok(true);
        }
    }
}
