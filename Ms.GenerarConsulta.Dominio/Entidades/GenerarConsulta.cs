using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.GenerarConsulta.Dominio.Entidades
{

    [CollectionProperty("GenerarConsulta")]
    [BsonIgnoreExtraElements]
    public  class GenerarConsulta : EntityToLower<ObjectId>
    {


        public int IdConsulta { get; set; }
        public string NroConsulta { get; set; }
        public string PacienteDiagnostico { get; set; }
        public string MeidicoAtencion { get; set; }

        public int idPaciente { get; set; }


    


    }
}
