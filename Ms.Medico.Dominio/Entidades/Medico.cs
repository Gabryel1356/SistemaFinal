using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Ms.Medico.Dominio.Entidades
{

    [CollectionProperty("MEDICOS")]
    [BsonIgnoreExtraElements]
    public  class Medico : EntityToLower<ObjectId>
    {


        public int id_medico { get; set; }
        public string DNI { get; set; }
        public int Nombres { get; set; }
        public int ApePa { get; set; }
        public int ApeMa { get; set; }
        public int id_especialidad { get; set; }





    }
}
