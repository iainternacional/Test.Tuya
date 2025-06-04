using Aplicacion.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion.WebApi.Controllers
{
    public class ProcessController : ControllerBase
    {
        private readonly UseCase _useCase;
        private readonly ProcessPresenter _presenter;

        public ProcessController(UseCase useCase, ProcessPresenter presenter)
            => (_useCase, _presenter) = (useCase, presenter);

        /// <summary>
        /// Ejecuta el caso de uso principal.
        /// </summary>
        [HttpPost]
        public ActionResult<ProcessResponseView> Post([FromBody] RequestData request)
        {
            ResponseData response = _useCase.Execute(request);

            // Convertir DomainData → ViewModel
            var view = _presenter.ToView(new DomainData(response.Output));

            return Ok(view);
        }
    }
}
