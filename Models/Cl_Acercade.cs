using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2P.Models
{
    class Cl_Acercade
    {
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string MoreInfoUrl => "https://pae.ec/adopciones/";
        public string Message => "\n" + "Esta aplicación permite comentar una mascota " +
        "\n " + "y si deseas más informacion o como adoptar una mascota da click al botón de abajo" + "\n";
    }
}
