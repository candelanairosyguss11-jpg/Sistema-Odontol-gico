using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sistema_Odontológico
{
    public class ServicioHistorias
    {
        private readonly IRepositorio<HistoriaClinica> _repo;
        public ServicioHistorias(IRepositorio<HistoriaClinica> repo) { _repo = repo; }

        public HistoriaClinica ObtenerOCrear(int pacienteId)
        {
            var h = _repo.ObtenerTodos().FirstOrDefault(x => x.PacienteId == pacienteId);
            if (h == null)
            {
                h = new HistoriaClinica { PacienteId = pacienteId };
                _repo.Agregar(h);
            }
            return h;
        }

        public void Guardar(HistoriaClinica h, int odontologoId)
        {
            h.RegistrarModificacion(odontologoId);
            _repo.Actualizar(h);
        }

        public void AgregarObservacion(HistoriaClinica h, int odontologoId, string texto, int? turnoId = null)
        {
            h.Observaciones.Add(new Observacion { OdontologoId = odontologoId, TurnoId = turnoId, Texto = texto });
            _repo.Actualizar(h);
        }
    }
}