using CleanArquitecture.Domain.Common;
using System.Linq.Expressions;

namespace CleanArquitecture.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T: BaseDomainModel
    {
        //Metodo para traer una lista generica
        Task<IReadOnlyList<T>> GetAllAsync();

        // Metodo para traer un conjunto de datos por varias condiciones logicas
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        //Metodo para traer una lista e incluir el ordenamiento de los resultados
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        string? includeString=null,
                                        bool disableTracking=true);

        // Metodo para la paginacion
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        List<Expression<Func<T, object>>>? includes = null,
                                        bool disableTracking = true);

        //Metodo para traer un valor por id
        Task<T> GetByIdAsync(int id);
        //Metodo para agregar un nuevo valor

        Task<T> AddAsync(T entity);
        //Metodo para actualizar un valor

        Task<T> UpdateAsync(T entity);
        //Metodo para eliminar un valor

        Task<T> DeleteAsync(int id);
    }
}
