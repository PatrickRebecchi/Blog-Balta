using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels;

public class EditorCategoryViewModel
{
    [Required(ErrorMessage = "O nome é obrigátorio")]
    [StringLength(40, MinimumLength = 3, ErrorMessage ="Esse campo deve conter de 3 a 40 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O slug é obrigátorio")]
    public string Slug { get; set; }
}
