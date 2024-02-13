using Microsoft.EntityFrameworkCore;
using rubinetti.alessandro._5i.primaWeb.Models;
using Microsoft.EntityFrameworkCore.Sqlite;

public class dbContext : DbContext
{
    private readonly DbContextOptions? _options;
    public dbContext(){}
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=database.db");

    public DbSet<Prodotti> Prodottis {get; set;}
    public DbSet<Prenotazione> Prenotaziones { get; set; }
}