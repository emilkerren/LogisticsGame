using LogisticsGame.Common;
using LogisticsGame.Models;
using System;
using System.Windows.Input;

namespace LogisticsGame.ViewModels
{
    public class StepThreeViewModel : Extensions, IApplicationWindow
    {
        public Action<IApplicationWindow> Navigate { get; set; }
        private ICommand _nextWindow;
        public ICommand NextWindow
        {
            get
            {
                return _nextWindow ?? (_nextWindow = new DelegateCommand
                {
                    Execute = () =>
                    {
                        Navigate(new StepFourViewModel
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
        /// Quality assurance Yes
        /// </summary>
        private DelegateCommand _addQualityAssuranceYesPoints;
        
        public DelegateCommand AddQualityAssuranceYesPoints
        {
            get
            {
                return _addQualityAssuranceYesPoints ?? (_addQualityAssuranceYesPoints = new DelegateCommand
                {
                    Execute = () =>
                    {
                        UserPoints.Time += 1;
                        UserPoints.Price += 1;
                        UserPoints.Safety += 1;
                        UserPoints.QualityAssuranceUser = QualityAssurance.QUALITYASSURANCE.Yes.ToString();
                        ToogleBoolQualityAssuranceNo = false;
                        ToogleBoolQualityAssuranceSemi = false;
                    }
                });
            }
        }
        private bool _toogleBoolQualityAssuranceYes = true;
        public bool ToogleBoolQualityAssuranceYes
        {
            get { return _toogleBoolQualityAssuranceYes; }
            set
            {
                _toogleBoolQualityAssuranceYes = value;
                OnPropertyChanged(nameof(ToogleBoolQualityAssuranceYes));
            }
        }
        /// <summary>
        /// Quality assurance No
        /// </summary>
        private DelegateCommand _addQualityAssuranceNoPoints;
        public DelegateCommand AddQualityAssuranceNoPoints
        {
            get
            {
                return _addQualityAssuranceNoPoints ?? (_addQualityAssuranceNoPoints = new DelegateCommand
                {
                    Execute = () =>
                    {
                        UserPoints.Time -= 1;
                        UserPoints.Price -= 1;
                        UserPoints.Safety -= 1;
                        UserPoints.QualityAssuranceUser = QualityAssurance.QUALITYASSURANCE.No.ToString();
                        ToogleBoolQualityAssuranceYes = false;
                        ToogleBoolQualityAssuranceSemi = false;
                    }
                });
            }
        }
        private bool _toogleBoolQualityAssuranceNo = true;
        public bool ToogleBoolQualityAssuranceNo
        {
            get { return _toogleBoolQualityAssuranceNo; }
            set
            {
                _toogleBoolQualityAssuranceNo = value;
                OnPropertyChanged(nameof(ToogleBoolQualityAssuranceNo));
            }
        }
        /// <summary>
        /// Quality assurance SEMI
        /// </summary>
        private DelegateCommand _addQualityAssuranceSemiPoints;
        public DelegateCommand AddQualityAssuranceSemiPoints
        {
            get
            {
                return _addQualityAssuranceSemiPoints ?? (_addQualityAssuranceSemiPoints = new DelegateCommand
                {
                    Execute = () =>
                    {
                        
                        UserPoints.Time -= 1;
                        UserPoints.Price += 1;
                        UserPoints.Safety += 1;
                        UserPoints.QualityAssuranceUser = QualityAssurance.QUALITYASSURANCE.Semi.ToString();
                        ToogleBoolQualityAssuranceYes = false;
                        ToogleBoolQualityAssuranceNo = false;
                    }
                });
            }
        }
        private bool _toogleBoolQualityAssuranceSemi = true;
        public bool ToogleBoolQualityAssuranceSemi
        {
            get { return _toogleBoolQualityAssuranceSemi; }
            set
            {
                _toogleBoolQualityAssuranceSemi = value;
                OnPropertyChanged(nameof(ToogleBoolQualityAssuranceSemi));
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
