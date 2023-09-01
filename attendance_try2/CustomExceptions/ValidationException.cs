namespace attendance_try2.CustomExceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string msg) : base(msg)
        {

        }
    }
}
