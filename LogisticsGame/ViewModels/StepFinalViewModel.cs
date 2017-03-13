using LogisticsGame.Common;
using LogisticsGame.Models;
using System;

namespace LogisticsGame.ViewModels
{
    public class StepFinalViewModel : Extensions, IApplicationWindow
    {
        public Action<IApplicationWindow> Navigate { get; set; }

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
