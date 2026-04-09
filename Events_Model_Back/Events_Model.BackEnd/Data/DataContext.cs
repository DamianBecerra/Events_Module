using Events_Model.BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace Events_Model.BackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Asignacion de locacion a un evento
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Location)
                .WithOne()
                .HasForeignKey<EventLocation>(l => l.IdEvent);

            //Indice por fecha
            modelBuilder.Entity<Event>().HasIndex(e => e.Date);

            // Datos de prueba para la paginacion
            var EventsList = new List<Event>();
            var LocationList = new List<EventLocation>();
            //se crea una fecha del 1 de mayo para que los eventos no sean antiguos cuando se revise esta prueba
            DateTime fechaBase = new DateTime(2026, 4, 30, 10, 0, 0, DateTimeKind.Utc);

            for (int i = 1; i <= 20; i++)
            {
                EventsList.Add(new Event
                {
                    IdEvent = i,
                    Title = $"Evento Musical #{i}",
                    Description = $"Descripción del evento {i}.",
                    Date = fechaBase.AddDays(i)
                });

                LocationList.Add(new EventLocation
                {
                    IdLocation = i,
                    IdEvent = i,
                    Lat = 4.711 + (i * 0.001),
                    Lng = -74.072 - (i * 0.001),
                    Address = $"Sede Principal - Auditorio {i}"
                });
            }


            modelBuilder.Entity<Event>().HasData(EventsList);
            modelBuilder.Entity<EventLocation>().HasData(LocationList);
        }
    }
}
