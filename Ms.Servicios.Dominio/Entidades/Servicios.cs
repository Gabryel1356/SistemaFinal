using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Servicios.Dominio.Entidades
{

    [CollectionProperty("Servicios")]
    [BsonIgnoreExtraElements]
    public  class Servicios : EntityToLower<ObjectId>
    {


        public int idServicios { get; set; }
        public string tiposervcio { get; set; }

    


    }
}
