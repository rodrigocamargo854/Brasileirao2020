namespace dev.Brasileirao2020
{
    //herança da classe usuario
    public sealed class Torcedor : Usuario
    {
       public Torcedor(string nome) : base(nome)
       {
           Nome = nome;
       }
    }
}