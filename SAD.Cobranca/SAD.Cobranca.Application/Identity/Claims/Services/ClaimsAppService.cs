using System;
using System.Collections.Generic;
using AutoMapper;
using SAD.Cobranca.Application.Identity.Claims.Interfaces;
using SAD.Cobranca.Domain.Identity.Commands;
using SAD.Cobranca.Domain.Identity.Interfaces;
using SAD.Cobranca.Infra.Data.IoC.UnitOfWork;

namespace SAD.Cobranca.Application.Identity.Claims.Services
{
    public class ClaimsAppService : IClaimsAppService
    {
        private readonly IClaimsService _claimsService;
        private readonly IUnitOfWork _unitOfWork;

        public ClaimsAppService(IClaimsService claimsService, IUnitOfWork unitOfWork)
        {
            _claimsService = claimsService;
            _unitOfWork = unitOfWork;
        }

        public ClaimsViewModel Registrar(ClaimsViewModel claimViewModel)
        {
            var claims = Mapper.Map<RegistrarClaimsCommand>(claimViewModel);
            var claimsRetorno = _claimsService.Registrar(claims);

            if (claimsRetorno.ValidationResult.IsValid)
            {
                _unitOfWork.Commit();
            }

            claimViewModel = Mapper.Map<ClaimsViewModel>(claimsRetorno);
            return claimViewModel;
        }

        public ClaimsViewModel Editar(ClaimsViewModel claimViewModel)
        {
            var claims = Mapper.Map<EditarClaimsCommand>(claimViewModel);
            var claimsRetorno = _claimsService.Editar(claims);

            if (claimsRetorno.ValidationResult.IsValid)
            {
                _unitOfWork.Commit();
            }

            claimViewModel = Mapper.Map<ClaimsViewModel>(claimsRetorno);
            return claimViewModel;
        }

        public void Remover(Guid id)
        {
            _claimsService.Remover(id);
            _unitOfWork.Commit();
        }

        public ClaimsViewModel ObterPorId(Guid claimId)
        {
            return Mapper.Map<ClaimsViewModel>(_claimsService.ObterPorId(claimId));
        }

        public IEnumerable<ClaimsViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClaimsViewModel>>(_claimsService.ObterTodos());
        }
    }
}
