namespace Aplicacion.WebApi.ViewModels
{
    public sealed class ProcessResponsiveView
    {
        public ProcessResponseView ToView(DomainData data) =>
        new(data.Value);
    }
}
