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
		public string LetraAsiento { get; set; }
		public int NroAsiento { get; set; }
		public Guid TicketId { get; private set; }
		public Guid VueloId { get; private set; }
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

		public CheckIn(string nroCheckIn, int esAltaPrioridad, string letraAsiento, int nroAsiento, Guid ticketId, Guid vueloId, Guid administrativoId) {
			Id = Guid.NewGuid();
			NroCheckIn = new NumeroCheckInValue(nroCheckIn);
			EsAltaPrioridad = esAltaPrioridad;
			LetraAsiento = letraAsiento;
			NroAsiento = nroAsiento;
			HoraCheckIn = DateTime.Now;
			TicketId = ticketId;
			VueloId = vueloId;
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
			var evento = new CheckInCreado(NroCheckIn, HoraCheckIn, EsAltaPrioridad, LetraAsiento, NroAsiento, TicketId, AdministrativoId);
			AddDomainEvent(evento);
		}

	}
}
