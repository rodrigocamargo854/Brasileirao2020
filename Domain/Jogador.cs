namespace Domain
{
    public abstract class Jogador
    {
        public string Nome { get; set; }

        public Jogador(string nome)
        {
            Nome = nome;
        }
        
    }
}