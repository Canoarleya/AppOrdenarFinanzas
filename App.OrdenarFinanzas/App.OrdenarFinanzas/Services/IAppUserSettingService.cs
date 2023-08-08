using System;
using System.Collections.Generic;
using System.Text;

namespace App.OrdenarFinanzas.Services
{
    public interface IAppUserSettingService
    {
        string UserName { get; set; }
        string UserToken { get; set; }
        void Clear();

    }

}
