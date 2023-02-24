using SistemaEduEscola.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SistemaEduEscola.Models
{
	public class Materia
	{
		[Key]
		public int Id { get; set; }
		public string NomeMateria { get; set; }
		public string Professor { get; set; }

		public int TurmaId { get; set; }
		public int UnidadeId { get; set; }
		public virtual Unidade Unidades { get; set; }

		public void Salvar()
		{
			var db = new TabelaEscola();
			object value = db.Materias.Add(this);
			db.SaveChanges();
		}

		public List<Materia> Todos()
		{
			var db = new TabelaEscola();
			return db.Materias.ToList();
		}
	}
}
