﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoMinsait.Models
{
    public class Motorista : Pessoa
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="O Campo Cnh do motorista é obrigatorio!")]
        public string? Cnh { get; set; }
        public string? Salario { get; set; }
        [JsonIgnore]
        public Guid? OnibusId { get; set; }
        [JsonIgnore]
        public virtual Onibus? Onibus { get; set; }

    }
}
