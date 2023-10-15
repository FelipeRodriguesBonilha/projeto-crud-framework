using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tarefa_mvc_lp.Models
{
    [Table("Obra")]
    public class Obra
    {
        [Key]
        [Display(Name = "Identificação da Obra (ID)")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo descrição é obrigatório!")]
        [StringLength(35, MinimumLength = 4, ErrorMessage = "Descrição deve ter entre 4 e 35 caracteres")]
        [Display(Name = "Descrição da Obra")]
        public string descricao { get; set; }

        public int peaoID { get; set; }
        [ForeignKey("peaoID")]
        [Display(Name = "Identificação do Peão")]
        public Peao peao { get; set; }

        public int peaoMestreID { get; set; }
        [ForeignKey("peaoMestreID")]
        [Display(Name = "Identificação do Peão Mestre")]
        public PeaoMestre peaoMestre { get; set; }

        public int empreiteiraID { get; set; }
        [ForeignKey("empreiteiraID")]
        [Display(Name = "Identificação da Empreiteira")]
        public Empreiteira empreiteira { get; set; }

        [Required(ErrorMessage = "Campo valor da hora é obrigatório!")]
        [Display(Name = "Valor da hora da Obra")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public float valorHora { get; set; }

        [Required(ErrorMessage = "Campo status é obrigatório!")]
        [MaxLength(1)]
        [Display(Name = "Status da Obra")]
        public string status { get; set; }
    }
}
