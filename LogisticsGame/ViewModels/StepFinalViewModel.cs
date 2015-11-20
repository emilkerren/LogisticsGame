using LogisticsGame.Common;
using LogisticsGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LogisticsGame.ViewModels
{
    public class StepFinalViewModel : Extensions, IApplicationWindow
    {
        public Action<IApplicationWindow> Navigate { get; set; }
        //private ICommand _nextWindow;
        //public ICommand NextWindow
        //{
        //    get
        //    {
        //        return _nextWindow ?? (_nextWindow = new DelegateCommand
        //        {
        //            Execute = () =>
        //            {
        //                Navigate(new StepFinalViewModel
        //                {
        //                    Navigate = Navigate,
        //                    UserPoints = UserPoints

        //                });
        //            }
        //        });
        //    }
        //}
        private UserClass _userPoints;
        public UserClass UserPoints
        {
            get { return _userPoints; }
            set
            {
                _userPoints = value;
                OnPropertyChanged(nameof(UserPoints));
            }
        }
        public string UserStats
        {
            get
            {
                return "safety " + UserPoints.Safety.ToString() +
                    " envirement: " + UserPoints.Envirement.ToString() +
                    " price: " + UserPoints.Price.ToString() +
                    " time:  " + UserPoints.Time.ToString() +
                    " quality " + UserPoints.Quality.ToString()+
                    " delivery " + UserPoints.Delivery.ToString();
            }
        }
    }
}
