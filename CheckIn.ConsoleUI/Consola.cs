using CheckIn.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.ConsoleUI
{
    static class Consola
    {
        static void Main(string[] args)
        {
            Ticket ticket_1 = new Ticket(new DateTime(2022, 04, 01));

            Administrativo adm_1 = new Administrativo("8213523sc", "Jonathan", "Simons Añez");
            Pasajero pasa_1 = new Pasajero("3880949sc", "Ramon", "Rodriguez Roda");

            Avion avion_1 = new Avion("Hercules AV-305");

            avion_1.AgregarAsiento(1, "A", false);
            avion_1.AgregarAsiento(1, "B", false);
            avion_1.AgregarAsiento(1, "C", true);
            avion_1.AgregarAsiento(2, "A", false);
            avion_1.AgregarAsiento(2, "B", false);
            avion_1.AgregarAsiento(2, "C", true);
            avion_1.AgregarAsiento(3, "A", false);
            avion_1.AgregarAsiento(3, "B", false);
            avion_1.AgregarAsiento(3, "C", true);

            //Domain.Model.CheckIn checkIn_1 = new Domain.Model.CheckIn(ticket_1.Id, adm_1.Id,);
            //checkIn_1.AgregarEquipaje("Bolso", "negro", new Domain.Model.ValueObjects.Peso(5.2), true, 20, 40, 15);
            //checkIn_1.AgregarEquipaje("Maleta Grande", "verde oscuro", new Domain.Model.ValueObjects.Peso(38.3), false, 100, 50, 30);
            //checkIn_1.AgregarEquipaje("Maleta mediana", "Rojo", new Domain.Model.ValueObjects.Peso(20), false, 70, 28, 30);


            //Producto objProducto1 = new Producto("Pepsi 500ml", 8.5m, 10);
            //Producto objProducto2 = new Producto("Hamburguesa simple", 18m, 100);

            //Cliente objCliente = new Cliente("Jose Carlos Gutierrez");

            //Pedido objPedido = new Pedido("12");
            //objPedido.AgregarItem(objProducto1.Id, 2, objProducto1.PrecioVenta, "Fria");
            //objPedido.AgregarItem(objProducto2.Id, 1, objProducto2.PrecioVenta, "");

            //objPedido.ConsolidarPedido();


        }
    }
}
