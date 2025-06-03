using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Tuya.Domain.Contracts;
using Test_Tuya.Domain.Entities;
using Test_Tuya.Domain.Services;

namespace Test_Tuya.Application
{
    public record RequestData(string Input);
    public record ResponseData(string Output);
    public sealed class UseCase
    {
        private readonly IRepository _repo;
        private readonly DomainService _domain;

        public UseCase(IRepository repo, DomainService domain)
            => (_repo, _domain) = (repo, domain);

        public ResponseData Execute(RequestData request)
        {
            var entity = new Entity();
            entity.SetData(new DataValue(request.Input));

            var processed = _domain.Process(entity);         // reglas
            _repo.Save(new DataValue(processed.Value));      // persistencia

            return new ResponseData(processed.Value);
        }
    }
}
