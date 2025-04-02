namespace RepositoryCleanArchitecture.Domain.Exeptions.Models
{
    public class DefaultError
    {
        public string Erro { get;}
        public string Mensagem { get; }

        public DefaultError(string erro, string mensagem)
        {
            Erro = erro;
            Mensagem = mensagem;
        }

    }
}
