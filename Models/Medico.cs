using System;
using System.Collections.Generic;

#nullable disable

namespace DesafioCase.Models
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int Id { get; set; }
        public string Crm { get; set; }
        public int? IdEspecialidade { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
