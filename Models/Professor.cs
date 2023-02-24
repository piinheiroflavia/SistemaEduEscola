using SistemaEduEscola.Context;
using System.Collections.Generic;
using System.Linq;

namespace SistemaEduEscola.Models
{
	public class Professor
	{
		public int Id { get; set; }
		public string NomeProfessor { get; set; }
		public int UnidadeId { get; set; }
		public int MateriaId { get; }

		public void Salvar()
		{
			var db = new TabelaEscola();
			object value = db.Professors.Add(this);
			db.SaveChanges();
		}

		public List<Professor> Todos()
		{
			var db = new TabelaEscola();
			return db.Professors.ToList();
		}
	}
}
