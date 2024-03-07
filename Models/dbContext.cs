using Microsoft.EntityFrameworkCore;
using rubinetti.alessandro._5i.primaWeb.Models;
using Microsoft.EntityFrameworkCore.Sqlite;

public class dbContext : DbContext
{
    public dbContext(){}
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=database.db");

    public DbSet<Prodotti> Prodottis {get; set;}
    public DbSet<Prenotazione> Prenotaziones { get; set; }
    //public DbSet<Prenotazione_Prodotti> Prenotazione_Prodottis { get; set; }
}