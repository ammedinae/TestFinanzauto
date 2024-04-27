using DTO.Response.Constans;

namespace DTO.Response
{
    public class GenericResponse<TEntity>
    {
        public static string GetMessageException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return GetMessageException(ex.InnerException);
            }
            else
            {
                return ex.Message;
            }
        }

        public int Codigo { get; set; }

        public string? Mensaje { get; set; }

        public TEntity? Datos { get; set; }

        public static GenericResponse<TEntity> ResponseOK(TEntity datos, string mensaje = ConstansApp.Messages.OK)
        {
            return new GenericResponse<TEntity>
            {
                Codigo = ConstansApp.ApiCodes.OK,
                Mensaje = mensaje,
                Datos = datos
            };
        }

        public static GenericResponse<TEntity> ResponseOKDelete(string mensaje)
        {
            return new GenericResponse<TEntity>
            {
                Codigo = ConstansApp.ApiCodes.OK,
                Mensaje = mensaje,
                Datos = default
            };
        }

        public static GenericResponse<TEntity> ResponseValidation(string mensaje)
        {
            return new GenericResponse<TEntity>
            {
                Codigo = ConstansApp.ApiCodes.ControlledError,
                Mensaje = mensaje,
                Datos = default
            };
        }

        public static GenericResponse<TEntity> ResponseError(string mensaje = ConstansApp.Messages.UnexpectedError)
        {
            return new GenericResponse<TEntity>
            {
                Codigo = ConstansApp.ApiCodes.UnexpectedError,
                Mensaje = mensaje,
                Datos = default
            };
        }

        public static GenericResponse<TEntity> ResponseError(Exception ex)
        {
            return new GenericResponse<TEntity>
            {
                Codigo = ConstansApp.ApiCodes.UnexpectedError,
                Mensaje = GetMessageException(ex),
                Datos = default
            };
        }

        public static GenericResponse<TEntity> NoData(string mensaje = ConstansApp.Messages.NoData)
        {
            return new GenericResponse<TEntity>
            {
                Codigo = ConstansApp.ApiCodes.UnexpectedError,
                Mensaje = mensaje,
                Datos = default
            };
        }
    }
}
