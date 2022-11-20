namespace TP_GSC_BackEnd.Services
{
    public enum ServiceResultTypes
    {
        Ok,
        NotFound,
        InvalidInput,
        BussinesLogicError
    }

    public record class ServiceResult<T>
    {
        public ServiceResultTypes type { get; private set; }
        public T? body { get; private set; }
        public string? error_message { get; private set;}


        public static ServiceResult<T> Ok() => new ServiceResult<T>(ServiceResultTypes.Ok);

        public static ServiceResult<T> Ok(T body) {
            var result = new ServiceResult<T>(ServiceResultTypes.Ok);
            result.body = body;
            return result;
        }

        public static ServiceResult<T> NotFound(string message) {
            var result = new ServiceResult<T>(ServiceResultTypes.NotFound);
            result.error_message = message;
            return result;
        }
       
        public static ServiceResult<T> InvalidInput(string message)
        {
            var result = new ServiceResult<T>(ServiceResultTypes.InvalidInput);
            result.error_message = message;
            return result;
        }

        public static ServiceResult<T> BussinesLogicError(string message)
        {
            var result = new ServiceResult<T>(ServiceResultTypes.BussinesLogicError);
            result.error_message = message;
            return result;
        }


        private ServiceResult(ServiceResultTypes type)
        {
            this.type = type;            
        }
    }
}
