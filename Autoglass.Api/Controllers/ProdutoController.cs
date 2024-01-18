using System;
using System.Threading.Tasks;
using Autoglass.Service.Dtos;
using Autoglass.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Autoglass.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> ListAsync(
        [FromQuery] string descricao,
        [FromQuery] DateTime? dataFabricacao,
        [FromQuery] DateTime? dataValidade,
        [FromQuery] string situacao,
        [FromQuery] int pagina = 1,
        [FromQuery] int tamanhoDaPagina = 3)
        {
            var result = await _service.ListAsync(descricao, dataFabricacao, dataValidade, situacao, pagina, tamanhoDaPagina);
            return Ok(result);
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> AddAsync([FromBody] ProdutoDto produto)
        {
            await _service.AddAsync(produto);
            return Ok();
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditAsync([FromBody] ProdutoDto produto)
        {
            await _service.EditAsync(produto);
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] ProdutoDto produto)
        {
            await _service.DeleteAsync(produto);
            return Ok();
        }
    }
}