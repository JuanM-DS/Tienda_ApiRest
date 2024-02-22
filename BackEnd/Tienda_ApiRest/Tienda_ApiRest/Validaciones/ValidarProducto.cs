using FluentValidation;
using Tienda_ApiRest.Modelos;

namespace Tienda_ApiRest.Validaciones
{
    public class ValidarProducto : AbstractValidator<Producto>
	{
		public ValidarProducto()
		{
			RuleFor(x => x.Nombre).NotEmpty().Must(x => !x.Any(Char.IsDigit)).WithMessage("El nombre no puede contener digitos");
			RuleFor(x => x.Precio).NotEqual(0);
		}
	}
}
