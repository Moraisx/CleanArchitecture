using Microsoft.AspNetCore.Mvc;
using RepositoryCleanArchitecture.Application.DTOs.ProdutoDTO;
using RepositoryCleanArchitecture.Domain.Entities;
using RepositoryCleanArchitecture.Domain.Interfaces.IProdutoService;

namespace RepositoryCleanArchitecture.Presentation.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;
    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> BuscarTodosProdutos(int skip, int take)
    {
        try
        {
            var produtos = await _produtoService.ObterTodosProdutos(skip, take);

            var produtosDTO = produtos.Select(produto => new ProdutoDTO(
                produto.Id,
                produto.Nome.Nome,             
                produto.Categoria.Value,         
                produto.Ativo,
                produto.Descricao.Descricao    
            )).ToList();

            return Ok(produtosDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPost]
    public async Task<ActionResult<ProdutoDTO>> CriarProduto([FromBody] ProdutoDTO produtoDTO)
    {
        var produto = Produto.CriarProduto(
            produtoDTO.Nome, 
            produtoDTO.Categoria, 
            produtoDTO.Ativo, 
            produtoDTO.Descricao);

        await _produtoService.CriarProduto(produto);
        
        var produtoRetornoDTO = new ProdutoDTO(
            produto.Id,
            produto.Nome.Nome,        
            produto.Categoria.Value, 
            produto.Ativo,
            produto.Descricao.Descricao 
        );
        return CreatedAtAction(nameof(CriarProduto), new { id = produto.Id }, produtoRetornoDTO);
    }
}
