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
        }
    }
}
