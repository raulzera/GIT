using System.Collections.Generic;
using AutoMapper;
using SAD.Cobranca.Application.Identity.UsuarioClaims.Interfaces;
using SAD.Cobranca.Domain.Identity.UsuarioClaim.Commands;
using SAD.Cobranca.Domain.Identity.UsuarioClaim.Interfaces;
using SAD.Cobranca.Infra.Data.IoC.UnitOfWork;

namespace SAD.Cobranca.Application.Identity.UsuarioClaims.Services
{
    public class UsuarioClaimsAppService : IUsuarioClaimsAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioClaimsService _usuarioClaimsService;

        public UsuarioClaimsAppService(IUsuarioClaimsService usuarioClaimsService, IUnitOfWork unitOfWork)
        {
            _usuarioClaimsService = usuarioClaimsService;
            _unitOfWork = unitOfWork;
        }

        public UsuarioClaimsViewModel Registrar(UsuarioClaimsViewModel usuarioClaimsViewModel)
        {
            var usuarioClaims = Mapper.Map<RegistrarUsuarioClaimCommand>(usuarioClaimsViewModel);
            var usuarioClaimsRetorno = _usuarioClaimsService.Registrar(usuarioClaims);

            if (usuarioClaimsRetorno.ValidationResult.IsValid)
            {
                _unitOfWork.Commit();
            }

            usuarioClaimsViewModel = Mapper.Map<UsuarioClaimsViewModel>(usuarioClaimsRetorno);
            return usuarioClaimsViewModel;
        }

        public UsuarioClaimsViewModel Editar(UsuarioClaimsViewModel usuarioClaimsViewModel)
        {
            var usuarioClaims = Mapper.Map<EditarUsuarioClaimCommand>(usuarioClaimsViewModel);
            var usuarioClaimsRetorno = _usuarioClaimsService.Editar(usuarioClaims);

            if (usuarioClaimsRetorno.ValidationResult.IsValid)
            {
                _unitOfWork.Commit();
            }

            usuarioClaimsViewModel = Mapper.Map<UsuarioClaimsViewModel>(usuarioClaimsRetorno);
            return usuarioClaimsViewModel;
        }

        public void Remover(int id)
        {
            _usuarioClaimsService.Remover(id);
            _unitOfWork.Commit();
        }

        public IEnumerable<UsuarioClaimsViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<UsuarioClaimsViewModel>>(_usuarioClaimsService.ObterTodos());
        }

        public UsuarioClaimsViewModel ObterPorId(int usuarioClaimId)
        {
            return Mapper.Map<UsuarioClaimsViewModel>(_usuarioClaimsService.ObterPorId(usuarioClaimId));
        }

        public IEnumerable<UsuarioClaimsViewModel> ObterUsuarioClaims(string id)
        {
            return Mapper.Map<IEnumerable<UsuarioClaimsViewModel>>(_usuarioClaimsService.ObterUsuarioClaim(id));
        }
    }
}
