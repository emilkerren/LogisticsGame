using LogisticsGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsGame.ViewModels
{
    public interface IApplicationWindow
    {
        Action<IApplicationWindow> Navigate { get; set; }
       
    }
}
