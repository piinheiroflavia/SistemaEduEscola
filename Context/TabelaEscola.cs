using Microsoft.EntityFrameworkCore;
using SistemaEduEscola.Models;
//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;

namespace SistemaEduEscola.Context
{
	public class TabelaEscola : DbContext
	{
		public DbSet<Aluno> Alunos { get; set; }
		public DbSet<Unidade> Unidades { get; set; }
		public DbSet<Turma> Turmas { get; set; }
		public DbSet<Materia> Materias { get; set; }
		public DbSet<Professor> Professors { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(connectionString: @"server=(localdb)\mssqllocaldb;Database=TabelaEscola;Integrated Security=True");
		}

		//protected override void OnModelCreating(DbModelBuilder modelBuilder)
		//{

		//	modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		//}
	}
}
