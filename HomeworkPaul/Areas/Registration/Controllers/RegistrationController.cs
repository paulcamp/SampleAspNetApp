using System.Web.Mvc;
using HomeworkPaul.Areas.Registration.Models;

namespace HomeworkPaul.Areas.Registration.Controllers
{
    [AllowAnonymous]
    public class RegistrationController : Controller
    {
        private readonly RegistrationFacade _registrationFacade;

        public RegistrationController(RegistrationFacade registrationFacade)
        {
            _registrationFacade = registrationFacade;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "FirstName,Surname,Email,Password,ConfirmPassword")] RegistrationDetails registrationDetails)
        {
            if (!ModelState.IsValid)
            {
                return View(registrationDetails);
            }
            
            var result = _registrationFacade.RegisterUser(registrationDetails);

            TempData["SuccessMessage"] = result.Success ? result.Message : string.Empty;
            TempData["ErrorMessage"] = result.Success ? string.Empty : result.Message;

            return RedirectToAction("Index");
        }
    }
}