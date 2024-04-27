using AutoMapper;
using BlazorServer.DataAccess.Models.BaseEntity;
using Microsoft.AspNetCore.Routing.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Automapper
{
    public static class ConvertMapping<TModelRequest, TModelResponse, TEntity, TResult>
    where TModelRequest : new()
    where TModelResponse : new()
    where TEntity : class
    {
        private static readonly IMapper _mapper;
        private static IMapper? mapper;


        static ConvertMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TEntity>();
                cfg.CreateMap<TEntity, TModelResponse>().ReverseMap();
                cfg.CreateMap<TModelRequest, TEntity>().ReverseMap();
                cfg.CreateMap<TModelRequest, TModelResponse>().ReverseMap();
                cfg.CreateMap<TModelResponse, TModelResponse>();
                cfg.CreateMap<TModelResponse, TResult>().ReverseMap();
            });
            _mapper = config.CreateMapper();
        }

        public static TEntity ConvertToEntity(TModelRequest model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            return entity;
        }

        public static TModelResponse ConvertToResponseModel(TEntity entity)
        {
            TModelResponse model = _mapper.Map<TModelResponse>(entity);
            return model;
        }

        public static List<TModelResponse> ConvertToResponseModelList(List<TEntity> entityList)
        {
            List<TModelResponse> responseValueList = _mapper.Map<List<TModelResponse>>(entityList);
            return responseValueList;
        }

        public static TEntity ConvertEntityToEntity(TEntity entity)
        {
            TEntity model = _mapper.Map<TEntity>(entity);
            return model;
        }

        public static List<TModelResponse> ConvertirEnListaModeloResponseEnModeloResponse(List<TModelResponse> modelList)
        {
            List<TModelResponse> responseValueList = _mapper.Map<List<TModelResponse>>(modelList);
            return responseValueList;
        }

        public static TModelRequest ConvertirEnModeloRequest(TModelResponse model)
        {
            TModelRequest modelRequest = _mapper.Map<TModelRequest>(model);
            return modelRequest;
        }

        public static List<TModelResponse> ConvertirTModelResponse(List<KeyValuePair<string, object>> propertyValuePairs)
        {
            List<TModelResponse> responseList = new List<TModelResponse>();

            foreach (var propertyValuePair in propertyValuePairs)
            {
                string propertyName = propertyValuePair.Key;
                object propertyValue = propertyValuePair.Value;

                if (propertyValue is IDictionary<string, object> nestedObject)
                {
                    var modelRequest = Activator.CreateInstance<TModelResponse>();

                    foreach (var nestedProperty in nestedObject)
                    {
                        string nestedPropertyName = nestedProperty.Key;
                        object nestedPropertyValue = nestedProperty.Value;

                        var propertyInfo = typeof(TModelResponse).GetProperty(nestedPropertyName);


                        if (propertyInfo != null)
                        {
                            propertyInfo.SetValue(modelRequest, nestedPropertyValue);

                            TModelResponse modelResponse = _mapper.Map<TModelResponse>(modelRequest);

                            responseList.Add(modelResponse);
                        }
                    }
                }
                else if (propertyName != null)
                {
                    var propertyInfo = typeof(TModelResponse).GetProperty(propertyName);

                    if (propertyInfo != null)
                    {
                        var modelRequest = new TModelResponse();
                        propertyInfo.SetValue(modelRequest, propertyValue);

                        TModelResponse modelResponse = _mapper.Map<TModelResponse>(modelRequest);
                        responseList.Add(modelResponse);
                    }
                }
                else if (propertyValue is object dynamicObject)
                {
                    var modelRequest = Activator.CreateInstance<TModelResponse>();

                    var dynamicProperties = dynamicObject.GetType().GetProperties();

                    foreach (var dynamicProperty in dynamicProperties)
                    {
                        string dynamicPropertyName = dynamicProperty.Name;
                        object dynamicPropertyValue = dynamicProperty.GetValue(dynamicObject);

                        var propertyInfo = typeof(TModelResponse).GetProperty(dynamicPropertyName);

                        if (propertyInfo != null)
                        {
                            propertyInfo.SetValue(modelRequest, dynamicPropertyValue);
                        }
                    }

                    TModelResponse modelResponse = _mapper.Map<TModelResponse>(modelRequest);
                    responseList.Add(modelResponse);
                }
                else
                {
                    Console.WriteLine($"Tipo de propertyValue no esperado: {propertyValue?.GetType()}");
                }
            }

            return responseList;
        }
    }
}
