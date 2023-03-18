using Microsoft.EntityFrameworkCore;
using repaso1.models;
namespace repaso1;

public class TareasContext:DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options):base(options) {  }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        List<Categoria> CategoriasInit=new List<Categoria>();
        CategoriasInit.Add(new Categoria(){CategoriaId=Guid.Parse("2109c605-8b39-4004-8650-26284c471ea1"), Nombre="Activdades Personales", Descripcion="Nada que hacer", Peso=10});
        CategoriasInit.Add(new Categoria(){CategoriaId=Guid.Parse("2109c605-8b39-4004-8650-26284c471ea7"), Nombre="Activdades Academicas", Descripcion="Nada que hacer", Peso=20});
        CategoriasInit.Add(new Categoria(){CategoriaId=Guid.Parse("2109c605-8b39-4004-8650-26284c471ea3"), Nombre="Activdades Laborales", Descripcion="Nada que hacer", Peso=30});

        modelBuilder.Entity<Categoria> (categoria=>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=>p.CategoriaId);
            categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=>p.Descripcion);
            categoria.Property(p=>p.Peso);
            categoria.HasData(CategoriasInit);
        });

        modelBuilder.Entity<Tarea> (tarea=>{
            tarea.ToTable("Tarea");
            tarea.HasKey(p=>p.TareaId);
            tarea.HasOne(c=>c.Categoria).WithMany(p=>p.Tareas).HasForeignKey(p=>p.CategoriaId).HasConstraintName("FK_Tarea_Categoria");
            tarea.Property(p=>p.Titulo).IsRequired().HasMaxLength(150);
            tarea.Property(p=>p.Descripcion);
            tarea.Property(p=>p.FechaCreacion);
            tarea.Property(p=>p.Prioridad);
            tarea.Ignore(p=>p.Resumen);
        });





    }
}