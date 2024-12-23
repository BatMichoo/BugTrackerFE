namespace Core.Services
{
    public class BugService
    {
        private readonly BackendService _backend;

        public BugService(BackendService backend)
        {
            _backend = backend;
        }
    }
}
