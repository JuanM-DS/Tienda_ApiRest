using FluentValidation;
using Tienda_ApiRest.Modelos;

namespace Tienda_ApiRest.Validaciones
{
    public class ValidarCategoria : AbstractValidator<Categoria>
    {
        public ValidarCategoria()
        {
            RuleFor(x => x.Nombre).NotEmpty().Must(x => !x.Any(Char.IsDigit)).WithMessage("El nombre no puede contener digitos");
            RuleFor(x => x.Descripcion).NotEmpty();
        }
    }
}
