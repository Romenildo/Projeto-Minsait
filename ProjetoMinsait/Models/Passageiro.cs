﻿namespace ProjetoMinsait.Models
{
    public class Passageiro : Pessoa
    {
        public string? Email { get; set; }
        public bool? seguro { get; set; }
        public int? Assento { get; set; }
    }
}
