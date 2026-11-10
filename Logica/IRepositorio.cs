using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Odontológico
{
    public interface IRepositorio<T> where T : IEntidad //T solo puede ser algo que tenga Id
    {
        List<T> ObtenerTodos();
        T? ObtenerPorId(int id);
        void Agregar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);
    }
}
