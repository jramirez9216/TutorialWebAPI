namespace DemoPPP.LogicaNegocio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tbl_Cat_Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(150)]
        public string ApellidoPaterno { get; set; }

        [Required]
        [StringLength(150)]
        public string ApellidoMaterno { get; set; }

        public DateTime? FechaRegistro { get; set; }


       //Generamos un nuevo metodo para aobtener lista personalizada de usuarios
       public List<tbl_Cat_Usuario> getAllUsers()
        {
            try
            {
                List<tbl_Cat_Usuario> listUsuarios = new List<tbl_Cat_Usuario>();
                using (var context = new dbContext())
                {
                    listUsuarios = context.tbl_Cat_Usuario.ToList();
                }

                return listUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }
    }
}
