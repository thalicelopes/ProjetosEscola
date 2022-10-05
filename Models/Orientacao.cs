using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetosEscola.Models;

public class Orientacao
{
    public int Id {get; set;}
    [Required(ErrorMessage = "Informe o nome do aluno!")]
    public int IdAluno {get; set;}
    [Required(ErrorMessage = "Informe o nome do professor!")]
    public int IdProfessor {get; set;}
    [Required(ErrorMessage = "Informe o nome do projeto!")]
    public string NomeProjeto {get; set;}    
    [Required(ErrorMessage = "Informe a data limite do projeto!")]
    public DateTime DataLimite {get; set;}

    [ForeignKey("IdAluno")]
    public virtual Aluno Aluno { get; set; }
    [ForeignKey("IdProfessor")]
    public virtual Professor Professor { get; set; }
}