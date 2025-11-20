namespace Modelo.Domain
{
    public class Retorno
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public int StatusCode { get; set; }

        public void CarregaRetorno(bool sucesso, string mensagem, int statusCode)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            StatusCode = statusCode;
        }
    }
    public class Retorno<T> : Retorno where T : class
    {
        public T Modelo { get; set; }
        public void CarregaRetorno(T modelo, bool sucesso, string mensagem, int statusCode)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            StatusCode = statusCode;
            Modelo = modelo;
        }
        public Retorno(T modelo)
        {
            Modelo = modelo;
        }
    }
}
