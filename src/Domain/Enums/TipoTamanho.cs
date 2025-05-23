using System.ComponentModel.DataAnnotations;

namespace Tililin.Domain.Enums;

public enum TamanhoProduto
{
    [Display(Name = "Extra Pequeno")]
    PP = 0,

    [Display(Name = "Pequeno")]
    P = 1,

    [Display(Name = "Médio")]
    M = 2,

    [Display(Name = "Grande")]
    G = 3,

    [Display(Name = "Extra Grande")]
    GG = 4,

    [Display(Name = "Extra Grande")]
    XG = 5,

    [Display(Name = "Duplo Extra Grande")]
    XGG = 6,

    [Display(Name = "XXL")]
    XXL = 7,

    [Display(Name = "XXXL")]
    XXXL = 8,

    [Display(Name = "Extra Extra Grande")]
    EXG = 9
}