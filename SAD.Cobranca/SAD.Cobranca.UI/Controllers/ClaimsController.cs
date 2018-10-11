using System;
using System.Web.Mvc;
using CC.SAD.Cobranca.Infra.CrossCutting.MvcFilters;
using SAD.Cobranca.Application.Identity.Claims;
using SAD.Cobranca.Application.Identity.Claims.Interfaces;
using X.PagedList;

namespace SAD.Cobranca.UI.Controllers
{
    [RoutePrefix("conta/claims")]
    public class ClaimsController : BaseController
    {
        private readonly IClaimsAppService _claimsAppService;

        public ClaimsController(IClaimsAppService claimsAppService)
        {
            _claimsAppService = claimsAppService;
        }

        [Route("")]
        [ClaimsAuthorize("sad", "sadl")]
        public ActionResult Index(int? page)
        {
            var claims = _claimsAppService.ObterTodos();
            var pageNumber = page ?? 1;
            return View(claims.ToPagedList(pageNumber, 12));
        }

        [Route("{id:guid}")]
        [ClaimsAuthorize("sad", "sadd")]
        public ActionResult Details(Guid id)
        {
            var claimsViewModel = _claimsAppService.ObterPorId(id);
            if (claimsViewModel == null)
            {
                return HttpNotFound();
            }
            return View(claimsViewModel);
        }

        [Route("nova-claim")]
        [ClaimsAuthorize("sad", "sadc")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-claim")]
        [ClaimsAuthorize("sad", "sadc")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClaimsViewModel claimsViewModel)
        {
            if (ModelState.IsValid)
            {
                claimsViewModel = _claimsAppService.Registrar(claimsViewModel);
                if (!claimsViewModel.ValidationResult.IsValid)
                {
                    AddModelErrors(claimsViewModel.ValidationResult.Errors);
                    return View(claimsViewModel);
                }
                TempData["success"] = "Claim adicionado com sucesso!";
                return RedirectToAction("Index", "Claims");
            }

            return View(claimsViewModel);
        }

        [Route("{id:guid}/editar")]
        [ClaimsAuthorize("sad", "sadu")]
        public ActionResult Edit(Guid id)
        {
            var claimsViewModel = _claimsAppService.ObterPorId(id);
            if (claimsViewModel == null)
            {
                return HttpNotFound();
            }

            return View(claimsViewModel);
        }

        [HttpPost]
        [Route("{id:guid}/editar")]
        [ClaimsAuthorize("sad", "sadu")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClaimsViewModel claimsViewModel)
        {
            if (ModelState.IsValid)
            {
                claimsViewModel = _claimsAppService.Editar(claimsViewModel);
                if (!claimsViewModel.ValidationResult.IsValid)
                {
                    AddModelErrors(claimsViewModel.ValidationResult.Errors);
                    return View(claimsViewModel);
                }
                TempData["success"] = "Claim atualizado com sucesso!";
                return RedirectToAction("Index", "Claims");
            }
            return View(claimsViewModel);
        }

        [Route("{id:guid}/remover")]
        [ClaimsAuthorize("sad", "sadx")]
        public ActionResult Delete(Guid id)
        {
            var claimsViewModel = _claimsAppService.ObterPorId(id);
            if (claimsViewModel == null)
            {
                return HttpNotFound();
            }
            return View(claimsViewModel);
        }

        [HttpPost]
        [Route("{id:guid}/remover")]
        [ClaimsAuthorize("sad", "sadx")]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _claimsAppService.Remover(id);
            TempData["success"] = "Claim removido com sucesso!";
            return RedirectToAction("Index", "Claims");
        }
    }
}