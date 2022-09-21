using System;
using System.ComponentModel.DataAnnotations;

namespace PessoaAPi.Data.Dtos
{
    public class ReadPesssoaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "Nome máximo de 200 caracteres"),]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o email é obrigatório", AllowEmptyStrings = false)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage =
            "O Email deve ter no mínimo 5 e no máximo 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo idade é obrigatório")]
        [Range(18, 65, ErrorMessage = "A idade deve ser de 18 a 65 anos")]
        public int Idade { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
