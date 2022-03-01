namespace BearGoodbyeKolkhozProject.API.Configuration.ExceptionResponse
{
    public class ValidationError
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Field { get; set; }
    }
}
