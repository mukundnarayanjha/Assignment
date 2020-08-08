using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.API.Models.Context
{
    public class AssignmentDBContext : DbContext
    {
        public AssignmentDBContext(DbContextOptions<AssignmentDBContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Multiplex> Multiplexes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }
    }
}
