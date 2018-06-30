using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteBanDongHo.Models.ViewModel;

namespace WebsiteBanDongHo.Models.Service
{
    interface RegisterService
    {
        bool Register(RegisterViewModel register);
        bool isExistAccount(string account);
    }
}
