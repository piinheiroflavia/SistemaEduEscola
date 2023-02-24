using SistemaEduEscola.Context;
using System.Collections.Generic;
using System.Linq;

namespace SistemaEduEscola.Models
{
	public class Unidade
	{
		public int Id { get; set; }
		public string NomeUnidade { get; set; }
		public string Enderoco { get; set; }
		public int QtdAlunos { get; set; }
		public int QtdTurmas { get; set; }

		public void Salvar()
		{
			var db = new TabelaEscola();
			object value = db.Unidades.Add(this);
			db.SaveChanges();
		}


		public List<Unidade> Todos()
		{
			var db = new TabelaEscola();
			return db.Unidades.ToList();
		}
	}
}
