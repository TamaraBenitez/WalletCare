using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace generico.Models
{
    public class Usuario
    {


        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int ID {get;set;} 
     
       [Key]
      [Required]
        public string Mail {get;set;}
    

        [Required]
        public string NombreDeUsuario{get;set;}

        [Required]
        public string Password {get;set;}
        


        public List<Ingreso> Ingresos {get;set;} 

    }
}