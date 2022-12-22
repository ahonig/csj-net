using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using csj.Models;

namespace csj.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {

        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "El usuario o clave no está correcto");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Users = "ADMIN, AGOMEZ")]
        public ActionResult List()
        {
            ViewData["usuarios"] = Membership.GetAllUsers();
            return View();
        }

        [Authorize(Users = "ADMIN, AGOMEZ")]
        [HttpPost]
        public JsonResult bloquearUsuario(Usuario usuario)
        {
            var vlMessage = "";
            var vlResult = "Ok";

            MembershipUser user = Membership.GetUser(usuario.id);
            if (user != null)
            {
                user.IsApproved = false;
                try
                {
                    Membership.UpdateUser(user);
                }
                catch (Exception e)
                {
                    vlMessage = e.Message;
                    vlResult = "error";
                }
            }
            else {
                vlMessage = "Usuario no encontrado";
                vlResult = "error";
            }
            //Objeto respuesta
            var respuesta = new
            {
                result = vlResult,
                message = vlMessage
            };



            return Json(respuesta);
        }

        [Authorize(Users = "ADMIN, AGOMEZ")]
        [HttpPost]
        public JsonResult activarUsuario(Usuario usuario)
        {
            var vlMessage = "";
            var vlResult = "Ok";

            MembershipUser user = Membership.GetUser(usuario.id);
            if (user != null)
            {
                user.IsApproved = true;
                try {
                    Membership.UpdateUser(user);
                }
                catch (Exception e) {
                    vlMessage = e.Message;
                    vlResult = "error";
                }
            }
            else {
                vlMessage = "Usuario no encontrado";
                vlResult = "error";
            }
            //Objeto respuesta
            var respuesta = new
            {
                result = vlResult,
                message = vlMessage
            };
            return Json(respuesta);
        }

        public class Usuario {
            public string id { get; set; }
        }
        // **************************************
        // URL: /Account/Register
        // **************************************
        [Authorize(Users = "ADMIN, AGOMEZ")]
        public ActionResult Register()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                string[] weakPasswords = { "123456", "123456789", "qwerty", "password", "12345", "qwerty123", "1q2w3e", "12345678", "111111", "1234567890" };
                Boolean passwordIsStrong = true;
                foreach (string weakPassword in weakPasswords)
                {
                    if (model.Password == weakPassword)
                    {
                        passwordIsStrong = false;
                    }
                }
                if (passwordIsStrong)
                {
                    // Attempt to register the user
                    MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);
                    if (createStatus == MembershipCreateStatus.Success)
                    {
                        //FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                        return RedirectToAction("List", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                    }
                } else {
                    ModelState.AddModelError("","La clave es demasiado debil. No esta permitido su uso.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "El password actual es incorrecto o el nuevo password es invalido");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }



    }
}
