namespace DTO.Response.Constans
{
    public record struct ConstansApp
    {
        public record struct ApiCodes
        {
            public const int OK = 200;
            public const int UnexpectedError = 500;
            public const int ControlledError = 400;
        }

        public record struct Messages
        {
            public const string OK = "OK";
            public const string ControlledError = "Ocurrio un error inesperado, por favor revisar los log.";
            public const string UnexpectedError = "Ocurrio un error inesperado.";
            public const string NoData = "No se encontró Data asociada a los valores ingresados";
            public const string Delete = "Se elimino correctamente";
        }
    }
}
