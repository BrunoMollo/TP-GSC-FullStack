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
        where T : class, new()
    {


        public ServiceResultTypes type {  get;  private set; }
        public T body { get; private set; }
        public string? error_message { get; private set;}


        public bool isOK() => type == ServiceResultTypes.Ok;
        public bool isNotFound() => type == ServiceResultTypes.NotFound;
        public bool isInvalidInput() => type == ServiceResultTypes.InvalidInput;
        public bool isBussinesLogicError() => type == ServiceResultTypes.BussinesLogicError;


        public static ServiceResult<T> Ok() => new ServiceResult<T>(ServiceResultTypes.Ok);

        public static ServiceResult<T> Ok(T body) => new ServiceResult<T>(ServiceResultTypes.Ok, body);
            
        
        private static ServiceResult<T> ErrorResult(ServiceResultTypes errorType, string message) {
            var result = new ServiceResult<T>(errorType);
            result.error_message = message;
            return result;
        }


        public static ServiceResult<T> NotFound(string message) => ErrorResult(ServiceResultTypes.NotFound, message);
        public static ServiceResult<T> InvalidInput(string message) => ErrorResult(ServiceResultTypes.InvalidInput, message);
        public static ServiceResult<T> BussinesLogicError(string message) => ErrorResult(ServiceResultTypes.BussinesLogicError, message);




        private ServiceResult(ServiceResultTypes type)
        {
            this.type = type;
            this.body = new T();
            this.error_message = "";
        }

        private ServiceResult(ServiceResultTypes type, T body)
        {
            this.type = type;
            this.body = body;
            this.error_message = "";
        }


    }
}
