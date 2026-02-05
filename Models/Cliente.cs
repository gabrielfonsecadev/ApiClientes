using System.ComponentModel.DataAnnotations;

namespace ApiClientes.Models;

public class Cliente
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
