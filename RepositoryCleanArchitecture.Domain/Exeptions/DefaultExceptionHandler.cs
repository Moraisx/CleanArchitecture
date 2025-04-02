using RepositoryCleanArchitecture.Domain.Exeptions.Models;

namespace RepositoryCleanArchitecture.Domain.Exceptions
{
    public class DefaultExceptionHandler : Exception
    {
        public List<DefaultError> ListError { get; }
        public DefaultError Error { get; }

        public DefaultExceptionHandler(List<DefaultError> erros) : base("Exceções")
        {
            ListError = erros ?? new List<DefaultError>();
        }

        public DefaultExceptionHandler(DefaultError error) : base("Exceções")
         {
            Error = error;
        }

        public static DefaultExceptionHandler UnitError(DefaultError error)
        {
            return new DefaultExceptionHandler(error);
        }

        public static DefaultExceptionHandler ListErros(List<DefaultError> erros)
        {
            return new DefaultExceptionHandler(erros);
        }
    }
}
