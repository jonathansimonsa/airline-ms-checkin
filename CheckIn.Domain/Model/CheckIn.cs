using CheckIn.Domain.Event;
using CheckIn.Domain.Model.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Model
{
    public class CheckIn : AggregateRoot<Guid>
    {
        public NumeroCheckInValue NroCheckIn { get; private set; }
        public DateTime HoraCheckIn { get; private set; }
        public int EsAltaPrioridad { get; private set; }

        private ICollection<Equipaje> _DetalleEquipaje;


        public IReadOnlyCollection<Equipaje> DetalleEquipaje
        {
            get
            {
                return new ReadOnlyCollection<Equipaje>(_DetalleEquipaje.ToList());
            }
        }

        public CheckIn()
        { }

        public CheckIn(string nroCheckIn, int esAltaPrioridad)
        {
            Id = Guid.NewGuid();
            NroCheckIn = new NumeroCheckInValue(nroCheckIn);
            EsAltaPrioridad = esAltaPrioridad;
            HoraCheckIn = DateTime.Now;
            _DetalleEquipaje = new List<Equipaje>();
        }

        public void ResetEquipajes()
        {
            _DetalleEquipaje = new List<Equipaje>();
        }

        public void AgregarEquipaje(string pDescripcion, PesoValue pPeso, int pEsFragil)
        {
            var nuevo = new Equipaje(pDescripcion, pPeso, pEsFragil);
            _DetalleEquipaje.Add(nuevo);
            //AddDomainEvent(new ItemPedidoAgregado(productoId, precio, cantidad));
        }

        public void ConsolidarCheckIn()
        {
            var evento = new CheckInCreado(Id, NroCheckIn, HoraCheckIn, EsAltaPrioridad);
            AddDomainEvent(evento);
        }

    }
}
