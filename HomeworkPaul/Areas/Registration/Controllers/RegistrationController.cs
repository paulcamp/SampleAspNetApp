using System.Web.Mvc;
using HomeworkPaul.Areas.Registration.Models;
using HomeworkPaul.Areas.Registration.Repository;

namespace HomeworkPaul.Areas.Registration.Controllers
{
    [AllowAnonymous]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationController(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
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
            
            _registrationRepository.CreateUser(registrationDetails);

            //TODO: show DONE! page
            return RedirectToAction("Index");
        }


    }
}