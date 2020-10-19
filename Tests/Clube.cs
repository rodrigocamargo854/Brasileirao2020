namespace Domain{
   public abstract class Clube
    {
        protected string Nome { get; set; }

        protected Clube(string nome)
        {
            Nome = nome;
        }
    }

}