﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace OtoServisSatis.WebFormUI.Tools
{
    public static class Araclar
    {
        public static void MessageBox(Control pctrlControl, string mesaj = "")
        {
            ScriptManager.RegisterStartupScript(pctrlControl, pctrlControl.GetType(), "Uyarı", $"alert('{mesaj}')", true);
        }
    }
}