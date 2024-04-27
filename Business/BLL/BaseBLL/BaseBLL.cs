using AutoMapper;
using BlazorServer.DataAccess.Models.BaseEntity;
using Business.Automapper;
using Business.Interfaces.BaseBLL;
using Common.logs;
using DataAccess.Context;
using DTO.Response;
using DTO.Response.Constans;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Business.BLL.BaseBLL
{
    public class BaseBLL<TModeloRequest, TModeloResponse, TEntity> : IBaseBLL<TModeloRequest, TModeloResponse, TEntity>
     where TModeloRequest : new()
     where TModeloResponse : new()
     where TEntity : class
    {

        private readonly WebserviceContext _db;
        public BaseBLL(IAppLogger<TModeloRequest> loggerOS, WebserviceContext db)
        {
            _db = db;
        }

        protected DbSet<TEntity> EntitySet
        {
            get
            {
                return _db.Set<TEntity>();
            }
        }

        public virtual async Task<GenericResponse<IEnumerable<TModeloResponse>>> GetAll()
        {
            try
            {

                List<TEntity> entityRecordList = await _db.Set<TEntity>().ToListAsync();

                List<TModeloResponse> recordList = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, object>.ConvertToResponseModelList(entityRecordList);

                if (recordList.Count() > 0)
                {
                    return GenericResponse<IEnumerable<TModeloResponse>>.ResponseOK(recordList);
                }
                else
                {
                    return GenericResponse<IEnumerable<TModeloResponse>>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<IEnumerable<TModeloResponse>>.ResponseError(ex.Message);
            }
        }



        public virtual async Task<GenericResponse<TModeloResponse>> Modify(TModeloResponse modifiedModel)
        {
            try
            {
                TEntity modifiedEntity = ConvertMapping<TModeloResponse, TModeloResponse, TEntity, object>.ConvertToEntity(modifiedModel);

                _db.Entry(modifiedEntity).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                TModeloResponse model = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, object>.ConvertToResponseModel(modifiedEntity);

                if (model != null)
                {
                    return GenericResponse<TModeloResponse>.ResponseOK(model);
                }
                else
                {
                    return GenericResponse<TModeloResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<TModeloResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<TModeloResponse>> GetAsync(
            Expression<Func<TEntity, bool>> expression,
            Expression<Func<TEntity, object>> order = null,
            bool descending = false
            )
        {
            try
            {
                var query = EntitySet.AsNoTracking().Where(expression);
                if (order != null)
                {
                    if (descending)
                    {
                        query = query.OrderByDescending(order);
                    }
                    else
                    {
                        query = query.OrderBy(order);
                    }
                }

                var queryFirst = query.FirstOrDefault();

                TModeloResponse coneverted = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, object>.ConvertToResponseModel(queryFirst);

                if (coneverted != null)
                {
                    return GenericResponse<TModeloResponse>.ResponseOK(coneverted);
                }
                else
                {
                    return GenericResponse<TModeloResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<TModeloResponse>.ResponseError(ex.Message);
            }
        }


        public virtual async Task<GenericResponse<IEnumerable<TModeloResponse>>> GetAsyncList<TResult>(
               Expression<Func<TEntity, bool>> expression,
               Expression<Func<TEntity, TResult>>? select = null,
               Expression<Func<TEntity, object>>? groupBy = null,
               Expression<Func<TEntity, object>>? order = null,
               bool descending = false
            )
        {
            try
            {
                var query = EntitySet.AsNoTracking().Where(expression);

                if (groupBy != null)
                {
                    var groupedData = await query.ToListAsync();
                    var groupedQuery = groupedData.AsQueryable().GroupBy(groupBy.Compile()).SelectMany(g => g);

                    query = groupedQuery.AsQueryable();
                }

                if (order != null)
                {
                    query = descending ? query.OrderByDescending(order) : query.OrderBy(order);
                }

                if (select.ToString() != "x => x")
                {
                    var selectedResults2 = query.Select(select).ToList();
                    var propertyValuePairs = new List<KeyValuePair<string, object>>();

                    foreach (var result in selectedResults2)
                    {
                        var propertyName = (select.Body as MemberExpression)?.Member.Name;
                        var propertyValue = result;
                        propertyValuePairs.Add(new KeyValuePair<string, object>(propertyName, propertyValue));
                    }

                    IEnumerable<TModeloResponse> modeloResponse1 = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, TResult>.ConvertirTModelResponse(propertyValuePairs);
                    return GenericResponse<IEnumerable<TModeloResponse>>.ResponseOK(modeloResponse1);
                }

                IEnumerable<TModeloResponse> modeloResponse = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, object>.ConvertToResponseModelList(query.ToList());

                if (modeloResponse.Count() > 0)
                {
                    return GenericResponse<IEnumerable<TModeloResponse>>.ResponseOK(modeloResponse);
                }
                else
                {
                    return GenericResponse<IEnumerable<TModeloResponse>>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<IEnumerable<TModeloResponse>>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<TModeloResponse>> Insert(TModeloRequest model)
        {
            try
            {
                TEntity entity = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, object>.ConvertToEntity(model);
                _db.Set<TEntity>().Add(entity);
                await _db.SaveChangesAsync();
                TModeloResponse modelResponse = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, object>.ConvertToResponseModel(entity);

                if (model != null)
                {
                    return GenericResponse<TModeloResponse>.ResponseOK(modelResponse);
                }
                else
                {
                    return GenericResponse<TModeloResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<TModeloResponse>.ResponseError(ex.Message);
            }
        }

    }
}
