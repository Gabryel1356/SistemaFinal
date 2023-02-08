namespace Clinica_Gateway.Api.Routes
{
    public static class Class
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

       



        public static class RouteServicios
        {
            public const string GetAll = Base + "/Servicios/all";
            public const string GetById = Base + "/Servicios/{id}";


            public const string Create = Base + "/Servicios/create";
            public const string Update = Base + "/Servicios/update";
            public const string Delete = Base + "/Servicios/delete";


            public const string RegistrarServicio = Base + "/Servicios/create";

        }



    }
}
