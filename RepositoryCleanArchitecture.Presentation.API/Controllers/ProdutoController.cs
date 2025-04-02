using Microsoft.AspNetCore.Mvc;
using RepositoryCleanArchitecture.Application.DTOs.ProdutoDTO;
using RepositoryCleanArchitecture.Domain.Entities;
using RepositoryCleanArchitecture.Domain.Interfaces.IProduto;
using RepositoryCleanArchitecture.Domain.ValueObject.Produto;

namespace RepositoryCleanArchitecture.Presentation.API.Controllers;


[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IBuscarTodosProdutos _buscarTodosProdutos;
    private readonly ICriarProduto _criarProduto;

    public ProdutoController(IBuscarTodosProdutos buscarTodosProdutos, ICriarProduto criarProduto)
    {
        _buscarTodosProdutos = buscarTodosProdutos;
        _criarProduto = criarProduto;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> BuscarTodosProdutos(int skip, int take)
    {
        try
        {
            var produtos = await _buscarTodosProdutos.ObterTodosProdutos(skip, take);

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

        await _criarProduto.CriarProduto(produto);
        
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
