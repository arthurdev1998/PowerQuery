using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerQuery.Entities;

[Table("usuario")]
public class Usuario
{
    [Key, Column("cod_serial_usuario")]
    public int Id { get; set; }

    [Column("nome")]
    public string? Name { get; set; }

    [Column("idade")]
    public int Idade { get; set; }

    [Column("cpf")]
    public string? Cpf { get; set; }
}