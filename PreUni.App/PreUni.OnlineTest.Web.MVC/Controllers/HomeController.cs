using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PreUni.Core.EFModel;
using PreUni.Core.Repository;
using PreUni.OnlineTest.DAL.EntityFramework;
using PreUni.OnlineTest.UserDAL.IdentityManagers;
using PreUni.OnlineTest.UserDAL.Repository;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace PreUni.OnlineTest.Web.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        /// <summary>
        /// Unity Container to deal with dynamic situation like one ICreateRepository with multiple sub-classes(implementation)
        /// </summary>
        [Dependency]
        public IUnityContainer Container { get; set; }

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        }

        public HomeController(IUnityContainer muhContainer)
        {
            ICreateRepository defaultRepository = muhContainer.Resolve<ICreateRepository>(typeof(CreateEFRepository).Name) as CreateEFRepository;
            ICreateUserRepository userRepository = muhContainer.Resolve<ICreateUserRepository>(typeof(CreateEFUserRepository).Name) as CreateEFUserRepository;
        }

        public async Task<ActionResult> Index()
        {
            // Get a Current User Info
            var UserID = User.Identity.GetUserId<int>();

            // Get Branch info from a current user
            var currentUser = UserManager.FindById(User.Identity.GetUserId<int>());

            var branchCode = currentUser.BranchCode;

            if (!branchCode.HasValue)
                return RedirectToAction("STTCReWriting", "Assessment");

            if (branchCode.Value == 57) // VIC Burwood
                return RedirectToAction("Index", "Assessment");
            else
                return RedirectToAction("STTCReWriting", "Assessment");
        }

        [AllowAnonymous]
        public ActionResult HandleTheUnauthorized()
        {
            return View();
        }

        public ActionResult HandleNoData()
        {
            return View();
        }
    }
}