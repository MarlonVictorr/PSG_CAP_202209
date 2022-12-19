using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTec.Poco
{
    public class ReservaPoco
    {       
        public int Codigo { get; set; }     
        public int CodigoUsuario { get; set; }       
        public int CodigoItem { get; set; }       
        public int CodigoStatus { get; set; }     
        public bool? Ativo { get; set; }       
        public DateTime? DataInclusao { get; set; }       
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
