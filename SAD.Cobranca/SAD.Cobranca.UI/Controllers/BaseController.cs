using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Results;

namespace SAD.Cobranca.UI.Controllers
{
    public class BaseController : Controller
    {
        public void AddModelErrors(IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }
        }

        public void AddModelErrors(IList<ValidationFailure> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }

        public void AddModelError(string error)
        {
            ModelState.AddModelError(string.Empty, error);
        }
    }
}