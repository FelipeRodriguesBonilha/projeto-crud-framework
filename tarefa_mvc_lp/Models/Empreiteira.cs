using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tarefa_mvc_lp.Models
{
    [Table("Empreiteira")]
    public class Empreiteira
    {
        [Key]
        [Display(Name = "Identificação da Empreiteira (ID)")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo CNPJ é obrigatório!")]
        [MaxLength(14, ErrorMessage = "CNPJ deve ter 14 caracteres")]
        [Display(Name = "CNPJ da Empreiteira")]
        public string cnpj { get; set; }

        [Required(ErrorMessage = "Campo descrição é obrigatório!")]
        [StringLength(35, MinimumLength = 4, ErrorMessage = "Descrição deve ter entre 4 e 35 caracteres")]
        [Display(Name = "Descrição da Empreiteira")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo endereço é obrigatório!")]
        [StringLength(35, MinimumLength = 4, ErrorMessage = "Endereço deve ter entre 4 e 35 caracteres")]
        [Display(Name = "Endereço da Empreiteira")]
        public string endereco { get; set; }
        
        [Required(ErrorMessage = "Campo telefone é obrigatório!")]
        [MaxLength(35, ErrorMessage = "Telefone deve ter 11 caracteres")]
        [Display(Name = "Telefone da Empreiteira")]
        public string telefone { get; set; }
    }
}
