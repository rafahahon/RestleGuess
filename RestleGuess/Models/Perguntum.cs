using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestleGuess.Models;

public partial class Perguntum
{
    [Key]
    public int IdPergunta { get; set; }

    public string? Descricao { get; set; }
}
