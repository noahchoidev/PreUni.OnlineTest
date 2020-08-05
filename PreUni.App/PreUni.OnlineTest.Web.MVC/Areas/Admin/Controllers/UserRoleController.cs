using Microsoft.AspNet.Identity.Owin;
using PreUni.Core.EFModel;
using PreUni.OnlineTest.UserDAL.IdentityManagers;
using PreUni.OnlineTest.Web.MVC.CustomAttribute;
using PreUni.OnlineTest.Web.MVC.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PreUni.OnlineTest.Web.MVC.Areas.Admin.Controllers
{
    [CustomAuthorize("Developer,Admin")]
    public class UserRoleController : Controller
    {
        private ApplicationRoleManager _roleManager;

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        // GET: Role
        public ActionResult Index()
        {
            //context
            List<RoleViewModel> list = new List<RoleViewModel>();

            foreach (var role in RoleManager.Roles)
            {
                list.Add(new RoleViewModel(role));
            }

            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            var role = new ApplicationRole(model.Name);

            await RoleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int? id)
        {
            var role = await RoleManager.FindByIdAsync(id.Value);
            return View(new RoleViewModel(role));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RoleViewModel model)
        {
            var role = new ApplicationRole() { Id = model.Id, Name = model.Name };

            await RoleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int? id)
        {
            var role = await RoleManager.FindByIdAsync(id.Value);
            return View(new RoleViewModel(role));
        }

        public async Task<ActionResult> Delete(int? id) // string
        {
            var role = await RoleManager.FindByIdAsync(id.Value);
            return View(new RoleViewModel(role));
        }

        public async Task<ActionResult> DeleteConfirmed(int? id) // // string
        {
            var role = await RoleManager.FindByIdAsync(id.Value);
            await RoleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
    }
}