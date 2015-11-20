using LogisticsGame.Common;
using LogisticsGame.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LogisticsGame.ViewModels
{
    public class StepOneViewModel : Extensions, IApplicationWindow
    {
        /// <summary>
        /// user class property we send and store our data in
        /// </summary>
        private UserClass _userPoints;
        public UserClass UserPoints
        {
            get { return _userPoints; }
            set {
                _userPoints = value;
                OnPropertyChanged(nameof(UserPoints));
            }
        }
        /// <summary>
        /// Interface action that we inherit from AppicationWindow to change window
        /// </summary>
        public Action<IApplicationWindow> Navigate{ get; set; }

        /// <summary>
        /// Delegate Command that we bind to in our view
        /// </summary>
        private DelegateCommand _addBureacracyPoints;
        private DelegateCommand _addDecentralizedPoints;
        /// <summary>
        /// Command that we bind to a button in our view to change window, sends our data to next viewmodel
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
                        Navigate(new StepTwoViewModel
                        {
                            Navigate = Navigate, UserPoints = UserPoints
                        });
                    }
                });
            }
        }
        /// <summary>
        /// Delegate Command that we bind to in our view
        /// </summary>
        public DelegateCommand AddBureacracyPoints
        {
            get
            {
                return _addBureacracyPoints ?? (_addBureacracyPoints = new DelegateCommand
                {
                    Execute = () =>
                    {
                        //UserPoints = new UserClass();
                        UserPoints.Envirement -= 1;
                        UserPoints.Safety -= 1;
                        UserPoints.CorporateCultureUser = CorporateCulture.CORPORATECULTURES.Bureacracy.ToString();
                        ToogleBoolDecentralized = false;
                    }
                });
            }
        }
        /// <summary>
        /// Delegate Command that we bind to in our view
        /// </summary>
        public DelegateCommand AddDecentralizedPoints
        {
            get
            {
                return _addDecentralizedPoints ?? (_addDecentralizedPoints = new DelegateCommand
                {
                    Execute = () =>
                    {
                        UserPoints.Price += 1;
                        UserPoints.Safety += 1;
                        UserPoints.CorporateCultureUser = CorporateCulture.CORPORATECULTURES.Decentrilized.ToString();
                        ToogleBoolBureaucracy = false;
                    }
                });

            }
        }

        /// <summary>
        /// sets and gets a buttons 'enabled' state
        /// </summary>
        private bool _toogleBoolDecentralized = true;
        public bool ToogleBoolDecentralized
        {
            get { return _toogleBoolDecentralized; }
            set
            {
                _toogleBoolDecentralized = value;
                OnPropertyChanged(nameof(ToogleBoolDecentralized));
            }
        }
        /// <summary>
        /// sets and gets a buttons 'enabled' state
        /// </summary>
        private bool _toogleBoolBureaucracy = true;
        public bool ToogleBoolBureaucracy
        {
            get { return _toogleBoolBureaucracy; }
            set
            {
                _toogleBoolBureaucracy = value;
                
                OnPropertyChanged(nameof(ToogleBoolBureaucracy));
            }
        }
        /// <summary>
        /// is bound in view to see current user properties stats
        /// </summary>
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
        public StepOneViewModel()
        {
            UserPoints = new UserClass();
        }

    }
}
