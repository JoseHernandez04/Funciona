using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_PTC
{
    public class Datos1
    {
        private static string _valorGlobal = string.Empty;
        public static string valorGlobal
        {
            get {return _valorGlobal; }
            set { _valorGlobal = value; }
        }
    }
}