using System;
using LogisticsGame.Models;
using LogisticsGame.Common;
using System.Windows.Input;

namespace LogisticsGame.ViewModels
{
    public class StepFourViewModel : Extensions, IApplicationWindow
    {
        public Action<IApplicationWindow> Navigate { get; set; }
        /// <summary>
        /// Command for navigating to next view
        /// </summary>
       private ICommand _nextWindow;
        public ICommand NextWindow
        {
            get
            {
                return _nextWindow ?? (_nextWindow = new DelegateCommand
                {
                    Execute = () =>
                    {
                        Navigate(new StepFiveViewModel
                        {
                            Navigate = Navigate,
                            UserPoints = UserPoints

                        });
                    }
                });
            }
        }
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
        /// <summary>
        /// Higly educated employees
        /// </summary>
        private DelegateCommand _addHighlyEducatedEmployees;
        public DelegateCommand AddHighlyEducatedEmployees
        {
            get
            {
                return _addHighlyEducatedEmployees ?? (_addHighlyEducatedEmployees = new DelegateCommand
                {
                    Execute = () =>
                    {
                        UserPoints.Quality += 1;
                        UserPoints.Price += 1;
                        UserPoints.EmployeesUser = Employees.EMPLOYEESPREFERENCE.HiglyEducated.ToString();
                        ToogleBoolNonEducatedEmployees = false;
                    }
                });
            }
        }
        private bool _toogleBoolHiglyEducatedEmployees = true;
        public bool ToogleBoolHiglyEducatedEmployees
        {
            get { return _toogleBoolHiglyEducatedEmployees; }
            set
            {
                _toogleBoolHiglyEducatedEmployees = value;
                OnPropertyChanged(nameof(ToogleBoolHiglyEducatedEmployees));
            }
        }
        /// <summary>
        /// Non Educated Employees
        /// </summary>
        private DelegateCommand _addNonEducatedEmployees;
        public DelegateCommand AddNonEducatedEmployees
        {
            get
            {
                return _addNonEducatedEmployees ?? (_addNonEducatedEmployees = new DelegateCommand
                {
                    Execute = () =>
                    {
                        UserPoints.Quality -= 1;
                        UserPoints.Price -= 1;
                        UserPoints.EmployeesUser = Employees.EMPLOYEESPREFERENCE.NonEducated.ToString();
                        ToogleBoolHiglyEducatedEmployees = false;
                    }
                });
            }
        }
        private bool _toogleBoolNonEducatedEmployees = true;
        public bool ToogleBoolNonEducatedEmployees
        {
            get { return _toogleBoolNonEducatedEmployees; }
            set
            {
                _toogleBoolNonEducatedEmployees = value;
                OnPropertyChanged(nameof(ToogleBoolNonEducatedEmployees));
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
                    " quality " + UserPoints.Quality.ToString();
            }
        }
    }
}