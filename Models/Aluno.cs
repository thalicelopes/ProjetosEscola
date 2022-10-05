using System.ComponentModel.DataAnnotations;

namespace ProjetosEscola.Models;

public class Aluno
{
    public int Id {get; set;}
    [Required(ErrorMessage = "Informe o nome do aluno.")]
    public string NomeAluno {get; set;}
    [Required(ErrorMessage = "Informe a matrícula do aluno.")]
    public string Matricula {get; set;}
    [Required(ErrorMessage = "Informe o período do aluno.")]
    public int Periodo {get; set;}
    public virtual ICollection<Orientacao> Orientacao { get; set; }
}