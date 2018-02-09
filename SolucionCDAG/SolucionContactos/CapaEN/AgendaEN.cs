using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEN
{
    public class AgendaEN
    {
        
    }

    public class ContactosEN
    {
        public string ID_CONTACTO { get; set; }
        public string NOMBRE { get; set; }
        public string CUI { get; set; }
        public string NIT { get; set; }
        public string GENERO { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO_RESIDENCIAL { get; set; }
        public string TELEFONO_CELULAR { get; set; }
        public string TELEFONO_TRABAJO { get; set; }
        public string OBSERVACIONES { get; set; }
        public string EMAIL_PERSONAL { get; set; }
        public string EMAIL_TRABAJO { get; set; }
        public string ESTADO { get; set; }
        public string USUARIO { get; set; }

    }

    public class CasosEN
    {
        public string ID_CASO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public string ID_TIPO_CASO { get; set; }
        public string FECHA_APERTURA { get; set; }
        public string FECHA_FINALIZACION { get; set; }
        public string OBSERVACIONES { get; set; }
        public string ESTADO { get; set; }
        public string USUARIO { get; set; }

    }

    public class AsignacionCasosEN
    {
        public string ID_ASIGNACION { get; set; }
        public string ID_CONTACTO { get; set; }
        public string ID_CASO { get; set; }
        public string ESTADO { get; set; }
        public string OBSERVACIONES { get; set; }
        public string USUARIO { get; set; }

    }

    public class TiposCasosEN
    {
        public string ID_TIPO_CASO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public string ESTADO { get; set; }
        public string USUARIO { get; set; }

    }
}
