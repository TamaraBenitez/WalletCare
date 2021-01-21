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


        public IActionResult PorMes() {

            return View();
        }


        public int elegirMes(string mes) {

          
        var map = new Dictionary<string, int>();

        
        map.Add("Enero", 1); map.Add("Febrero", 2); map.Add("Marzo", 3);
        map.Add("Abril", 4);  map.Add("Mayo", 5); map.Add("Junio", 6);
         map.Add("Julio", 7);  map.Add("Agosto", 8); map.Add("Septiembre", 9);
          map.Add("Octubre",10);  map.Add("Noviembre", 11);  map.Add("Diciembre", 12);

        
            return map.FirstOrDefault(m => m.Key == mes).Value;

        }


        [HttpPost]
        public IActionResult filtrarPorMes(string mes) {

             Usuario usuario= HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            if (usuario != null ) { 

                List<Ingreso> ahorros = new List<Ingreso>();
                ahorros = db.Ingresos.Where (i => i.fecha.Month.Equals(elegirMes(mes)) && i.mailUsuario.Equals(usuario.Mail)).ToList();

                if(ahorros.Count==0){

                    return View("SinIngresos");
                }


                    else {
                         return View ("MostrarIngresos",ahorros);
                   }

           }
            else {

             return Redirect("/User/ErrorUser");
            
            }

              
        }


    public IActionResult ErrorUser() {

        return View();
    }


    public IActionResult EliminarIngreso(int ID) {

        Ingreso ingreso = db.Ingresos.FirstOrDefault(i => i.ID == ID);
        
        db.Ingresos.Remove(ingreso);
        db.SaveChanges();

        return Redirect("MostrarIngresos");

    }


    }
}