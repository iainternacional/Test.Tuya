using Test_Tuya.Domain.DTOs;

namespace Aplicacion.WebApi.ViewModels
{
    public sealed class ProcessResponsiveView
    {
        public string Result { get; init; }

        public ProcessResponsiveView(string result) => Result = result;
    }
}
