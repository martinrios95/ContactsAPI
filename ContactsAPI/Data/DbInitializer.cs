using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<State>().HasData(
                    new State() { StateID = 1, StateName = "Buenos Aires" },
                    new State() { StateID = 2, StateName = "Ciudad Autonoma de Buenos Aires" },
                    new State() { StateID = 3, StateName = "Catamarca" },
                    new State() { StateID = 4, StateName = "Chaco" },
                    new State() { StateID = 5, StateName = "Chubut" },
                    new State() { StateID = 6, StateName = "Cordoba" },
                    new State() { StateID = 7, StateName = "Corrientes" },
                    new State() { StateID = 8, StateName = "Entre Rios" },
                    new State() { StateID = 9, StateName = "Formosa" },
                    new State() { StateID = 10, StateName = "Jujuy" },
                    new State() { StateID = 11, StateName = "La Pampa" },
                    new State() { StateID = 12, StateName = "La Rioja" },
                    new State() { StateID = 13, StateName = "Mendoza" },
                    new State() { StateID = 14, StateName = "Misiones" },
                    new State() { StateID = 15, StateName = "Neuquen" },
                    new State() { StateID = 16, StateName = "Rio Negro" },
                    new State() { StateID = 17, StateName = "Salta" },
                    new State() { StateID = 18, StateName = "San Juan" },
                    new State() { StateID = 19, StateName = "San Luis" },
                    new State() { StateID = 20, StateName = "Santa Cruz" },
                    new State() { StateID = 21, StateName = "Santa Fe" },
                    new State() { StateID = 22, StateName = "Santiago del Estero" },
                    new State() { StateID = 23, StateName = "Tierra del Fuego" },
                    new State() { StateID = 24, StateName = "Tucuman" }
            );

            modelBuilder.Entity<City>().HasData(
                    new City() { CityID = 1, CityName = "Bahia Blanca", StateID = 1 },
                    new City() { CityID = 2, CityName = "Punta Alta", StateID = 1 },
                    new City() { CityID = 3, CityName = "Medanos", StateID = 1 },
                    new City() { CityID = 4, CityName = "La Boca", StateID = 2 },
                    new City() { CityID = 5, CityName = "Balvanera", StateID = 2 },
                    new City() { CityID = 6, CityName = "Caballito", StateID = 2 },
                    new City() { CityID = 7, CityName = "Villa Crespo", StateID = 2 },
                    new City() { CityID = 8, CityName = "Monte Hermoso", StateID = 1 },
                    new City() { CityID = 9, CityName = "La Matanza", StateID = 1 },
                    new City() { CityID = 10, CityName = "Mar del Plata", StateID = 1 },
                    new City() { CityID = 11, CityName = "Córdoba", StateID = 3 },
                    new City() { CityID = 12, CityName = "Villa General Belgrano", StateID = 3 },
                    new City() { CityID = 13, CityName = "Pigüé", StateID = 1 },
                    new City() { CityID = 14, CityName = "Villa Iris", StateID = 1 }
            );

            modelBuilder.Entity<Contact>().HasData(
                new Contact() {
                    ContactID = Guid.Parse("4F01ED59-E0F3-4AC2-B688-79D759183EBB"),
                    ContactName = "NOMBRE 2",
                    ContactAddress = "DIRECCION 2",
                    ContactPhone = "1141112222",
                    CityID = 1
                },
                new Contact()
                {
                    ContactID = Guid.Parse("FB37D4B7-CAEB-4FFD-8824-876BF0993447"),
                    ContactName = "PRUEBA 4",
                    ContactAddress = "DIRECCION 4",
                    ContactPhone = "2233334444",
                    CityID = 4
                },
                new Contact()
                {
                    ContactID = Guid.Parse("BC21A495-9C03-4E9C-8558-ACEAD3D92085"),
                    ContactName = "PRUEBA 3",
                    ContactAddress = "DIRECCION 3",
                    ContactPhone = "2253334444",
                    CityID = 2
                },
                new Contact()
                {
                    ContactID = Guid.Parse("27FD0B27-465B-43AF-929E-E0A2C33DDCB5"),
                    ContactName = "PRUEBA 5",
                    ContactAddress = "DIRECCION 5",
                    ContactPhone = "1155556666",
                    CityID = 1
                }
            );
        }
    }
}
