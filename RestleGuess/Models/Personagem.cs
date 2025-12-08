using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestleGuess.Models;

[Table("Personagem")]
public partial class Personagem
{
    [Key]
    public int IdPersonagem { get; set; }

    [StringLength(100)]
    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;
}
