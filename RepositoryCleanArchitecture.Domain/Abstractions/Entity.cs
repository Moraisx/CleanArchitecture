using System.ComponentModel.DataAnnotations;


namespace RepositoryCleanArchitecture.Domain.Abstractions
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
