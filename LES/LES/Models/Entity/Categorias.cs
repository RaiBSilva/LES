using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Model.Entity
{
    public enum Categorias
    {
        Romance,
        Terror,
        Aventura,
        Fantasia,
        [Display(Name ="Ficção Cientifíca")]
        SciFi,
        [Display(Name = "Comédia")]
        Comedia,
        [Display(Name = "Auto-Ajuda")]
        AutoAjuda,
        [Display(Name = "Baseado em fatos reais")]
        BaseadoFatos,
        [Display(Name = "Jovem Adulto")]
        JovemAdulto
    }
}
