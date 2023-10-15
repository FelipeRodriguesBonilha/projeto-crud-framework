using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tarefa_mvc_lp.Models
{
    [Table("Peao")]
    public class Peao
    {
        [Key]
        [Display(Name = "Identificação do Peão (ID)")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório!")]
        [StringLength(35, MinimumLength = 4, ErrorMessage = "Nome deve ter entre 4 e 35 caracteres")]
        [Display(Name = "Nome do Peão")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo telefone é obrigatório!")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone do Peão")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "Campo e-mail é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail do Peão: ")]
        [StringLength(35)]
        public string email { get; set; }

        [Required(ErrorMessage = "Campo data é obrigatório!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento do Peão")]
        public DateTime data_nasc { get; set; }
    }
}
