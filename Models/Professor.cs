using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetosEscola.Models;

public class Professor
{
    public int Id {get; set;}
    [Required(ErrorMessage = "Informe o nome do professor.")]
    public string NomeProfessor { get; set; }
    [Required(ErrorMessage = "Informe a matrícula do professor.")]
    public string Matricula { get; set; } 
    [Required(ErrorMessage = "Informe a área de atuação do professor.")]   
    public string AreaAtuacao { get; set; }
    public virtual ICollection<Orientacao> Orientacao { get; set; }
}