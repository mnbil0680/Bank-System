using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsGlobal
    {
        public static clsUser CurrentUser = clsUser.Find("", "");
    }

}

