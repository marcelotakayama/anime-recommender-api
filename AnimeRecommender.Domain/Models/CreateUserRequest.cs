﻿namespace AnimeRecommender.API.Models
{
    public class CreateUserRequest
    {
        //teste
        public string Nome { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; } = null!;
        public string Rg { get; set; } = null!;
    }
}
