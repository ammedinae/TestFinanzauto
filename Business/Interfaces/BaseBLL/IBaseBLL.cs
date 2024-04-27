using DTO.Response;
using System.Linq.Expressions;

namespace Business.Interfaces.BaseBLL
{
    public interface IBaseBLL<TModeloRequest, TModeloResponse, TEntity>
    where TModeloRequest : new()
    where TModeloResponse : new()
    where TEntity : class
    {
        Task<GenericResponse<IEnumerable<TModeloResponse>>> GetAll();
        Task<GenericResponse<TModeloResponse>> Modify(TModeloResponse modeloModificado);
        Task<GenericResponse<TModeloResponse>> Insert(TModeloRequest modelo);
        Task<GenericResponse<TModeloResponse>> GetAsync(
           Expression<Func<TEntity, bool>> expression,
           Expression<Func<TEntity, object>> order = null,
           bool descending = false);
        Task<GenericResponse<IEnumerable<TModeloResponse>>> GetAsyncList<TResult>(
               Expression<Func<TEntity, bool>> expression,
               Expression<Func<TEntity, TResult>>? select = null,
               Expression<Func<TEntity, object>>? groupBy = null,
               Expression<Func<TEntity, object>>? order = null,
               bool descending = false
            );
    }
}
