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
        public int DNI { get; set; }
        public int Nombres { get; set; }
        public int ApePa { get; set; }
        public int ApeMa { get; set; }
        public int idespecialidad { get; set; }





    }
}
