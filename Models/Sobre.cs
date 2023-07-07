using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notas.Models
{
    internal class Sobre
    {
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string MoreInfoUrl => "https://www.islagaia.pt/";
        public string Message => "Esta aplicação foi desenvolvida em .NET MAUI.";
    }
}
