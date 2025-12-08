using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestleGuess.Models;

[Table("Escolha")]
public partial class Escolha
{
    [Key]
    public int IdEscolha { get; set; }

    public string? Descricao { get; set; }
}
