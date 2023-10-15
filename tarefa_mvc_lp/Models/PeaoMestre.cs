using System.ComponentModel.DataAnnotations;

namespace tarefa_mvc_lp.Models
{
    public class PeaoMestre 
    {

        [Key]
        [Display(Name = "Identificação do Peão Mestre (ID)")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório!")]
        [StringLength(35, MinimumLength = 4, ErrorMessage = "Nome deve ter entre 4 e 35 caracteres")]
        [Display(Name = "Nome do Peão Mestre")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo telefone é obrigatório!")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone do Peão Mestre")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "Campo e-mail é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail do Peão Mestre: ")]
        [StringLength(35)]
        public string email { get; set; }

        [Required(ErrorMessage = "Campo data é obrigatório!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento do Peão Mestre")]
        public DateTime data_nasc { get; set; }

        [Required(ErrorMessage = "Campo quantidade é obrigatório!")]
        [Range(0, 100, ErrorMessage = "A quantidade deve estar entre 0 e 100!")]
        [Display(Name = "Quantidade que o Peão Mestre foi contratado")]
        public int quantidade { get; set; }

        public void adicionaQuantidade() => quantidade++;
    }
}
