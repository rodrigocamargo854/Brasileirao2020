namespace Domain{
   public abstract class Usuario
    {
        protected string Nome { get; set; }

        protected Usuario(string nome)
        {
            Nome = nome;
        }
    }

}