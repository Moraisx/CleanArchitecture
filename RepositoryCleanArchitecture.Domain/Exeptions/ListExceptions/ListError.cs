namespace RepositoryCleanArchitecture.Domain.Exeptions.ListExceptions
{
    public class ListError<T> where T : class
    {
        public int StatusHttp { get; init; }
        public bool Sucesso { get; init; }
        public List<T> Error { get; init; }
        public string Tipo { get; init; }

        public ListError(int statusHttp, List<T> error, string tipo)
        {
            StatusHttp = statusHttp;
            Sucesso = false;
            Error = error;
            Tipo = tipo;
        }
    }
}
