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
		public DateTime HoraCheckIn { get; private set; }
		public int EsAltaPrioridad { get; private set; }
		public Guid TicketId { get; private set; }
		public Guid AsientoId { get; private set; }
		public Guid AdministrativoId { get; private set; }

		private ICollection<Equipaje> _DetalleEquipaje;


		public IReadOnlyCollection<Equipaje> DetalleEquipaje {
			get {
				return new ReadOnlyCollection<Equipaje>(_DetalleEquipaje.ToList());
			}
		}

		public CheckIn() {
			_DetalleEquipaje = new List<Equipaje>();
		}

		public CheckIn(string nroCheckIn, int esAltaPrioridad, Guid ticketId, Guid asientoId, Guid administrativoId) {
			Id = Guid.NewGuid();
			NroCheckIn = new NumeroCheckInValue(nroCheckIn);
			EsAltaPrioridad = esAltaPrioridad;
			HoraCheckIn = DateTime.Now;
			TicketId = ticketId;
			AsientoId = asientoId;
			AdministrativoId = administrativoId;
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
			var evento = new CheckInCreado(NroCheckIn, HoraCheckIn, EsAltaPrioridad, TicketId, AsientoId, AdministrativoId);
			AddDomainEvent(evento);
		}

	}
}
