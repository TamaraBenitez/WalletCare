using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using generico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using walletCare.Models;

namespace walletCare.Controllers
{


     public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UsuarioContext db;

        public UserController(ILogger<UserController> logger,UsuarioContext usuarioContext)
        {
            _logger = logger;
            db = usuarioContext ;
        }


     public IActionResult Index()
        {
            return View();
        }

    public IActionResult NuevoAhorro() {

        return View();
    }


    public IActionResult ResultadoIngreso() {

        return View();
    }

        public IActionResult SacarUsuarioEnSesion() {


             HttpContext.Session.Remove("UsuarioLogueado");
             return RedirectToAction("Index","Home");
        }


         public IActionResult AgregarIngreso(double aporte) {

                Usuario usuario= HttpContext.Session.Get<Usuario>("UsuarioLogueado");
               

                if(usuario !=null){


                Usuario usuarioBase = db.Usuarios.FirstOrDefault(u => u.Mail.Equals(usuario.Mail));
                Ingreso nuevoIngreso = new Ingreso(){

                  
                    Aporte=aporte,
                    fecha=DateTime.Now,
                    mailUsuario = usuarioBase.Mail
                    
                };

              

        
                db.Ingresos.Add(nuevoIngreso);
                db.SaveChanges();

                 return RedirectToAction("ResultadoIngreso","User");
                
              }

                else {
                        ViewBag.IngresoError= true;
                    return RedirectToAction("ResultadoIngreso","User");
                }

        } 




        public JsonResult ConsultarIngresos(){


            return Json(db.Ingresos.ToList());
        }


        public IActionResult MostrarIngresos() {

           Usuario usuario= HttpContext.Session.Get<Usuario>("UsuarioLogueado");
           if (usuario != null ) {

               List<Ingreso> ahorros = new List<Ingreso>();
               ahorros = db.Ingresos.Where(i => i.mailUsuario.Equals(usuario.Mail)).ToList();
                return View ("MostrarIngresos",ahorros);


           }
            else {

             return Redirect("/User/ErrorUser");
            
            }
        }


    public IActionResult ErrorUser() {

        return View();
    }


    }
}