namespace RepositoryCleanArchitecture.Domain.Exeptions.UnitExceptions
{
    public class UnitError<T>  where T : class
    {
        public int StatusHttp { get; init; }
        public bool Sucesso { get; init; }
        public T Error { get; init; }
        public string Tipo { get; init; } = null!;

        public UnitError(int statusHttp, T error, string tipo)
        {
            StatusHttp = statusHttp;
            Sucesso = false;
            Error = error;
            Tipo = tipo;
        }
    }
}
