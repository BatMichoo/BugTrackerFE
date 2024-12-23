namespace Core.Utilities
{
    public static class Urls
    {
        public static class Backend
        {
            public const string BaseAdress = "https://localhost:7272";
            public const string Login = "/users/login";
        }

        public static class Bug
        {
            public const string Base = "/bugs";
            public const string AssignedTo = Base + "/assigned-to";
            public const string CreatedBy = Base + "/created-by";
        }
    }
}
