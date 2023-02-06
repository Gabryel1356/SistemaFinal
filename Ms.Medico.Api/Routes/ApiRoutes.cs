namespace Ms.Medico.Api.Routes
{
    public static class ApiRoutes
    {

        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteMedico
        {
            public const string GetAll = Base + "/Medico/all";
            public const string GetById = Base + "/Medico/{id}";


            public const string Create = Base + "/Medico/create";
            public const string Update = Base + "/Medico/update";
            public const string Delete = Base + "/Medico/delete";

        }


    }
}
