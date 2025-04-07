namespace AnimeRecommender.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Cpf { get; private set; }
    public string Rg { get; private set; }
    public decimal Saldo { get; private set; }

    public User(string nome, DateTime dataNascimento, string cpf, string rg)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        DataNascimento = dataNascimento;
        Cpf = cpf;
        Rg = rg;
        Saldo = 0;
    }

    // construtor vazio só pro EF
    private User() { }

    public void Update(string nome, DateTime dataNascimento, string cpf, string rg)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Cpf = cpf;
        Rg = rg;
    }
}
