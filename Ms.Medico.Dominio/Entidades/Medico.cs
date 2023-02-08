using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Medico.Dominio.Entidades
{

    [CollectionProperty("Medico")]
    [BsonIgnoreExtraElements]
    public  class Medico : EntityToLower<ObjectId>
    {


        public int idmedico { get; set; }
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string ApePa { get; set; }
        public string ApeMa { get; set; }
        public string idespecialidad { get; set; }


    }
}
