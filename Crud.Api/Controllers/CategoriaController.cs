using AutoMapper;
using Crud.Domain.Dtos;
using Crud.Domain.Entities;
using Crud.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IServiceCategorias _serviceCategorias;
        private readonly IMapper _mapper;

        public CategoriaController(IServiceCategorias serviceCategorias, IMapper mapper)
        {
            _serviceCategorias = serviceCategorias;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serviceCategorias.ObterTodos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            return Ok(await _serviceCategorias.Obter(id));
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CategoriaDadosDto categoriaDadosDto)
        {
            Categorias categorias = _mapper.Map<CategoriaDadosDto, Categorias>(categoriaDadosDto);
            return Ok(await _serviceCategorias.Cadastrar(categorias));
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(CategoriaDadosDto categoriaDadosDto)
        {
            Categorias categorias = _mapper.Map<CategoriaDadosDto, Categorias>(categoriaDadosDto);
            return Ok(await _serviceCategorias.Atualizar(categorias));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            return Ok(await _serviceCategorias.Deletar(id));
        }

    }
}
