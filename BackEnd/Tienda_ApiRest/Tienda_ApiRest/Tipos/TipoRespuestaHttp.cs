namespace Tienda_ApiRest.Tipos
{

    /*Enum para catelogar el tipos de respuestas*/
    public enum TipoRespuestaHttp
    {
        Ok = 200,
        Created = 201,
        NotFound = 404,
		BadRequest = 400,
		InternalServerError = 500
    }

}
