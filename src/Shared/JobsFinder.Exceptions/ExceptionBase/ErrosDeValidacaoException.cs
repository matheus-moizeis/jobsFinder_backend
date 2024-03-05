namespace JobsFinder.Exceptions.ExceptionBase;
public class ErrosDeValidacaoException : JobsFinderException
{
    public List<string> MensagensDeErro {  get; set; }

    public ErrosDeValidacaoException(List<string> mensagensDeErro)
    {
        MensagensDeErro = mensagensDeErro;
    }
}
