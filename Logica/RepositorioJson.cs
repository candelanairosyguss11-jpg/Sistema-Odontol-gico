using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Sistema_Odontológico
{
    public class RepositorioJson<T> : IRepositorio<T> where T : IEntidad
    {
        private readonly string _ruta;
        private List<T> _items;

        private static readonly JsonSerializerOptions _opciones = new JsonSerializerOptions
        {
            WriteIndented = true //el JSON se guarda con sangrías
        };

        //constructor
        public RepositorioJson(string nombreArchivo)
        {
            string carpeta = Path.Combine(AppContext.BaseDirectory, "Datos");
            Directory.CreateDirectory(carpeta);
            _ruta = Path.Combine(carpeta, nombreArchivo);
            _items = Cargar(); //si el archivo no existe, devuelve una lista vacía
        }

        public List<T> ObtenerTodos()
        {
            return new List<T>(_items); //devuelve una copia
        }

        public T ObtenerPorId(int id)
        {
            return _items.FirstOrDefault(e => e.Id == id); //recorre la lista y devuelve el primer elemento que cumpla "e => e.Id == id" que es que dado un elemento e, devolvé si el Id de e es igual a id
        }

        public void Agregar(T entidad)
        {
            if (_items.Count == 0)
            {
                entidad.Id = 1;
            }
            else
            {
                entidad.Id = _items.Max(e => e.Id) + 1; //obtiene los Id y devuelve el mayor para sumarle 1
            }
            _items.Add(entidad);
            Guardar();
        }

        public void Actualizar(T entidad)
        {
            int indice = _items.FindIndex(e => e.Id == entidad.Id); //recorre la lista y devuelve LA POSICION del primer elemento que cumpla
            if (indice < 0)
            {
                throw new InvalidOperationException("No existe una entidad con ese Id.");
            }

            _items[indice] = entidad;
            Guardar();
        }

        public void Eliminar(int id)
        {
            int eliminados = _items.RemoveAll(e => e.Id == id);
            if (eliminados > 0)
            {
                Guardar();
            }
        }

        private List<T> Cargar()
        {
            if (!File.Exists(_ruta))
            {
                return new List<T>();
            }

            try
            {
                string json = File.ReadAllText(_ruta);
                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<T>();
                }
                var lista = JsonSerializer.Deserialize<List<T>>(json);
                if (lista == null)
                {
                    lista = new List<T>();
                }
                return lista;
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException(
                    $"El archivo {Path.GetFileName(_ruta)} está dañado o tiene datos inválidos.", ex);
            }
        }

        private void Guardar()
        {
            string json = JsonSerializer.Serialize(_items, _opciones);
            string temporal = _ruta + ".tmp";

            File.WriteAllText(temporal, json);
            File.Move(temporal, _ruta, overwrite: true);
        }
    }
}
