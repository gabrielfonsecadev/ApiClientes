using ApiClientes.Data;
using ApiClientes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ApiClientes.Dtos;
using AutoMapper;

namespace ApiClientes.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ClientesDbContext _context;
    private readonly IMapper _mapper;

    public ClientesController(ClientesDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var clientes = await _context.Clientes
        .AsNoTracking()
        .ToListAsync();
        return Ok(_mapper.Map<List<ClienteDto>>(clientes));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClienteCreateDto clienteDto)
    {
        var emailExists = await _context.Clientes.AnyAsync(c => c.Email == clienteDto.Email);
        if (emailExists)
        {
            return Conflict(new { Mensagem = "Email já cadastrado." });
        }

        var cliente = _mapper.Map<Cliente>(clienteDto);

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return Created(string.Empty, _mapper.Map<ClienteDto>(cliente));
    }
}
