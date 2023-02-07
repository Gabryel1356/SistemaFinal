using MongoDB.Bson;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using System;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Transactions;
using dominio = Ms.Paciente.Dominio.Entidades;


namespace Ms.Paciente.Aplicacion.Paciente
{
    public class PacienteService : IPacienteService
    {

        private readonly ICollectionContext<dominio.Paciente> _Paciente;
        private readonly IBaseRepository<dominio.Paciente> _PacienteR;

        public PacienteService(ICollectionContext<dominio.Paciente> paciente, IBaseRepository<dominio.Paciente> pacienteT)
        {
            _Paciente = paciente;
            _PacienteR = pacienteT;
        }
        public List<dominio.Paciente> ListarPaciente()
        {
            Expression<Func<dominio.Paciente, bool>> filter = b => b.esEliminado == false;
            var items = (_Paciente.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }


        public dominio.Paciente BuscarPorId(int idPac)
        {
            Expression<Func<dominio.Paciente, bool>> filter = b => b.esEliminado == false && b.idPac == idPac;
            var items = (_Paciente.Context().FindAsync(filter, null).Result).FirstOrDefault();
          
            
            
            
            return items;

        }

        public bool Registrar(dominio.Paciente paciente)
        {

                paciente.esEliminado = false;

                paciente.fechaCreacion = DateTime.Now;
                paciente.esActivo = true;
                var R = _PacienteR.InsertOne(paciente);


           

        
            return true;
        }


        public  bool Modificar(dominio.Paciente paciente)
        {


                paciente.esEliminado = false;
                paciente.fechaModificacion = DateTime.Now;
                paciente.esActivo = true;


                var filter = Builders<dominio.Paciente>.Filter.Eq(c => c.idPac, paciente.idPac);

                var update = Builders<dominio.Paciente>.Update

                    .Set(c => c.idPac, paciente.idPac)
                    .Set(c => c.dni, paciente.dni)
                    .Set(c => c.Nombre, paciente.Nombre)
                    .Set(c => c.apepa, paciente.apepa)
                    .Set(c => c.apema, paciente.apema)
                    .Set(c => c.edad, paciente.edad)
                    .Set(c => c.seguro, paciente.seguro)
                    .Set(c => c.genero, paciente.genero)
                    .Set(c => c.Fecha_ingreso, paciente.Fecha_ingreso);

                var result = _PacienteR.UpdateOneAsync(filter, update);

           

            return true;
        }




        public bool Eliminar(int idPac)
        {
              

            Expression<Func<dominio.Paciente, bool>> filter = b => b.esEliminado == false && b.idPac == idPac;
            var items = (_Paciente.Context().FindOneAndDeleteAsync(filter, null));


            return true;
        }


    }
}
