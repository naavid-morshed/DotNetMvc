using DotNetMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetMvc.Data;

public class MyAppContext(DbContextOptions<MyAppContext> options) : DbContext(options) { 
    public DbSet<Item> Items { get; set; }
}
