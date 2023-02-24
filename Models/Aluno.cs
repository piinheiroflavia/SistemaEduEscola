using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using SistemaEduEscola.Context;
using System.Linq;

namespace SistemaEduEscola.Models
{
	public class Aluno
	{
		public int Id { get; set; }
		public string NomeCompleto { get; set; }
		public string Cpf { get; set; }

		[DataType(DataType.Date)]
		public DateTime DataNascimento { get; set; }
		public int Matricula { get; set; }


		[ForeignKey("Turma")]
		public int TurmaId { get; set; }
		public virtual Turma Turmas { get; set; }

		[ForeignKey("Unidade")]
		public string UnidadeId { get; set; }
		public virtual Unidade Unidades { get; set; }

		public void Salvar()
		{
			var db = new TabelaEscola();
			object value = db.Alunos.Add(this);
			db.SaveChanges();
		}

		public List<Aluno> Todos()
		{
			var db = new TabelaEscola();
			return db.Alunos.ToList();
		}
	}
}
