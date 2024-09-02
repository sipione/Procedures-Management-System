namespace SGE.Aplicacion.CasosDeUso
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }

        public static OperationResult Ok(object data = null, string message = "Success")
        {
            return new OperationResult { Success = true, StatusCode = 200, Data = data, Message = message };
        }

        public static OperationResult Created(object data = null, string message = "Created")
        {
            return new OperationResult { Success = true, StatusCode = 201, Data = data, Message = message };
        }

        public static OperationResult Unauthorized(string message = "Unauthorized")
        {
            return new OperationResult { Success = false, StatusCode = 401, Message = message };
        }

        public static OperationResult BadRequest(string message)
        {
            return new OperationResult { Success = false, StatusCode = 400, Message = message };
        }

        public static OperationResult InternalServerError(string message)
        {
            return new OperationResult { Success = false, StatusCode = 500, Message = message };
        }
    }
}
