using System.Web.Mvc;
using HomeworkPaul.Areas.Registration.Models;
using HomeworkPaul.Extensions;

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
            this.AddNotification(result.Message, result.Success ? NotificationType.SUCCESS : NotificationType.ERROR);

            return RedirectToAction("Index");
        }
    }
}