using Aplicacion.WebApi.ViewModels;
using Test_Tuya.Domain.DTOs;

namespace Aplicacion.WebApi.Presenters
{
    public sealed class ProcessPresenter
    {
        public ProcessResponsiveView ToView(DomainData data) =>
        new(data.Value);          // mapea DomainData → ViewModel
    }
}
