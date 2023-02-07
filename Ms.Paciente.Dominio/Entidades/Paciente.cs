using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Paciente.Dominio.Entidades
{
    [CollectionProperty("Paciente")]
    [BsonIgnoreExtraElements]
    public class Paciente : EntityToLower<ObjectId>
    {

        public int idPac { get; set; }
        public string dni { get; set; }

        public string Nombre { get; set; }

        public string apepa { get; set; }

        public string apema { get; set; }
        public string edad { get; set; }
        public string seguro { get; set; }
        public string genero { get; set; }
        public string Fecha_ingreso { get; set; }

       





    }
}
