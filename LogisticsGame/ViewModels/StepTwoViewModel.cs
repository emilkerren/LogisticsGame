using LogisticsGame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsGame.Models;
using System.Windows.Input;

namespace LogisticsGame.ViewModels
{
    public class StepTwoViewModel : Extensions, IApplicationWindow
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
                        Navigate(new StepThreeViewModel
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
        /// Quality
        /// </summary>
        private DelegateCommand _addQualityPoints;
        public DelegateCommand AddQualityPoints
        {
            get
            {
                return _addQualityPoints ?? (_addQualityPoints = new DelegateCommand
                {
                    Execute = () =>
                    {
                        //UserPoints = new UserClass();
                        UserPoints.Time += 1;
                        UserPoints.Safety += 1;
                        UserPoints.Price -= 1;
                        UserPoints.SupplierUser = Supplier.SUPPLIERPREFERENCE.Quality.ToString();
                        ToogleBoolQuantity = false;
                        ToogleBoolEfficiancy = false;
                    }
                });
            }
        }
        private bool _toogleBoolQuality = true;
        public bool ToogleBoolQuality
        {
            get { return _toogleBoolQuality; }
            set
            {
                _toogleBoolQuality = value;
                OnPropertyChanged(nameof(ToogleBoolQuality));
            }
        }

        /// <summary>
        /// Quantity
        /// </summary>
        private DelegateCommand _addQuantityPoints;
        public DelegateCommand AddQuantityPoints
        {
            get
            {
                return _addQuantityPoints ?? (_addQuantityPoints = new DelegateCommand
                {
                    Execute = () =>
                    {
                        //UserPoints = new UserClass();
                        UserPoints.Price += 1;
                        UserPoints.Time -= 1;
                        UserPoints.Safety -= 1;
                        UserPoints.SupplierUser = Supplier.SUPPLIERPREFERENCE.Quantity.ToString();
                        ToogleBoolQuality = false;
                        ToogleBoolEfficiancy = false;
                    }
                });
            }
        }
        private bool _toogleBoolQuantity = true;
        public bool ToogleBoolQuantity
        {
            get { return _toogleBoolQuantity; }
            set
            {
                _toogleBoolQuantity = value;
                OnPropertyChanged(nameof(ToogleBoolQuantity));
            }
        }

        /// <summary>
        /// Efficiancy
        /// </summary>
        private DelegateCommand _addEfficiancyPoints;
        public DelegateCommand AddEfficiancyPoints
        {
            get
            {
                return _addEfficiancyPoints ?? (_addEfficiancyPoints = new DelegateCommand
                {
                    Execute = () =>
                    {
                        //UserPoints = new UserClass();
                        UserPoints.Time -= 1;
                        UserPoints.Price += 1;
                        UserPoints.Safety += 1;
                        UserPoints.SupplierUser = Supplier.SUPPLIERPREFERENCE.Efficiancy.ToString();
                        ToogleBoolQuantity = false;
                        ToogleBoolQuality = false;
                    }
                });
            }
        }
        private bool _toogleBoolEfficiancy = true;
        public bool ToogleBoolEfficiancy
        {
            get { return _toogleBoolEfficiancy; }
            set
            {
                _toogleBoolEfficiancy = value;
                OnPropertyChanged(nameof(ToogleBoolEfficiancy));
            }
        }
        public string UserStats
        {
            get
            {
                return "safety " + UserPoints.Safety.ToString() + 
                    " envirement: " + UserPoints.Envirement.ToString() + 
                    " price: " + UserPoints.Price.ToString() + 
                    " time:  "+UserPoints.Time.ToString()+
                    " quality "+UserPoints.Quality.ToString();
            }
        }
        
    }
}
