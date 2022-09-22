using CheckIn.Domain.Event;
using CheckIn.Domain.Model.CheckIn.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CheckIn.Domain.Model.CheckIn {
	public class CheckIn : AggregateRoot<Guid> {
		public NumeroCheckInValue NroCheckIn { get; private set; }
		public DateTime Hora { get; private set; }
		public int EsAltaPrioridad { get; private set; }
		public string LetraAsiento { get; set; }
		public int NroAsiento { get; set; }
		public Guid ReservaId { get; private set; }
		public Guid VueloId { get; private set; }

		private ICollection<Equipaje> _DetalleEquipaje;


		public IReadOnlyCollection<Equipaje> DetalleEquipaje {
			get {
				return new ReadOnlyCollection<Equipaje>(_DetalleEquipaje.ToList());
			}
		}

		public CheckIn() {
			_DetalleEquipaje = new List<Equipaje>();
		}

		public CheckIn(string nroCheckIn, DateTime hora, int esAltaPrioridad, string letraAsiento, int nroAsiento, Guid reservaId, Guid vueloId) {
			Id = Guid.NewGuid();
			NroCheckIn = new NumeroCheckInValue(nroCheckIn);
			Hora = hora;
			EsAltaPrioridad = esAltaPrioridad;
			LetraAsiento = letraAsiento;
			NroAsiento = nroAsiento;
			ReservaId = reservaId;
			VueloId = vueloId;
			_DetalleEquipaje = new List<Equipaje>();
		}

		public void ResetEquipajes() {
			_DetalleEquipaje = new List<Equipaje>();
		}

		public void AgregarEquipaje(string pDescripcion, PesoValue pPeso, int pEsFragil) {
			var nuevo = new Equipaje(pDescripcion, pPeso, pEsFragil);
			_DetalleEquipaje.Add(nuevo);
			//AddDomainEvent(new ItemPedidoAgregado(productoId, precio, cantidad));
		}

		public void ConsolidarCheckIn() {
			var evento = new CheckInCreado(NroCheckIn, Hora, EsAltaPrioridad, LetraAsiento, NroAsiento, ReservaId, VueloId);
			AddDomainEvent(evento);
		}

	}
}
