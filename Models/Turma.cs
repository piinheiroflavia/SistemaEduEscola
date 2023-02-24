using SistemaEduEscola.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SistemaEduEscola.Models
{
	public class Turma
	{
		public int Id { get; set; }
		public int CodigoTurma { get; set; }


		[ForeignKey("Alunos")]
		public int QtdAlunos { get; set; }
		public virtual Aluno Alunos { get; set; }

        //[ForeignKey("Unidade")]
        public int UnidadeId { get; set; }
		//public virtual Unidade Unidades { get; set; }

		public void Salvar()
		{
			var db = new TabelaEscola();
			object value = db.Turmas.Add(this);
			db.SaveChanges();
		}

		public List<Turma> Todos()
		{
			var db = new TabelaEscola();
			return db.Turmas.ToList();
		}

	}
}
