namespace Orders.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object obj): base($"Entity \"{name}\" ({obj}) not found")
        {
        }
    }
}
