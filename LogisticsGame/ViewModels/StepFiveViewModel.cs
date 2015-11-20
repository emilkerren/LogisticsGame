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
    public class StepFiveViewModel : Extensions, IApplicationWindow
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
                        Navigate(new StepFinalViewModel
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
        /// Big Inventory management
        /// </summary>
        private DelegateCommand _addInventoryManagemenBig;
        public DelegateCommand AddInventoryManagemenBig
        {
            get
            {
                return _addInventoryManagemenBig ?? (_addInventoryManagemenBig = new DelegateCommand
                {
                    Execute = () =>
                    {
                        UserPoints.Price += 1;
                        UserPoints.Safety += 1;
                        UserPoints.Delivery += 1;
                        UserPoints.InventoryManagement = InventoryManagement.INVENTORYMANAGEMENT.Small.ToString();
                        ToogleBoolInventoryManagementSmall = false;
                        ToogleBoolInventoryManagementAgile = false;
                    }
                });
            }
        }
        private bool _toogleBoolInventoryManagementBig = true;
        public bool ToogleBoolInventoryManagementBig
        {
            get { return _toogleBoolInventoryManagementBig; }
            set
            {
                _toogleBoolInventoryManagementBig = value;
                OnPropertyChanged(nameof(ToogleBoolInventoryManagementBig));
            }
        }
        /// <summary>
        /// Small Inventory management
        /// </summary>
        private DelegateCommand _addInventoryManagementSmall;
        public DelegateCommand AddInventoryManagementSmall
        {
            get
            {
                return _addInventoryManagementSmall ?? (_addInventoryManagementSmall = new DelegateCommand
                {
                    Execute = () =>
                    {
                        UserPoints.Price -= 1;
                        UserPoints.Safety -= 1;
                        UserPoints.Delivery -= 1;
                        UserPoints.InventoryManagement = InventoryManagement.INVENTORYMANAGEMENT.Small.ToString();
                        ToogleBoolInventoryManagementBig = false;
                        ToogleBoolInventoryManagementAgile = false;
                    }
                });
            }
        }
        private bool _toogleBoolInventoryManagementSmall = true;
        public bool ToogleBoolInventoryManagementSmall
        {
            get { return _toogleBoolInventoryManagementSmall; }
            set
            {
                _toogleBoolInventoryManagementSmall = value;
                OnPropertyChanged(nameof(ToogleBoolInventoryManagementSmall));
            }
        }
        /// <summary>
        /// Agile Inventory management
        /// </summary>
        private DelegateCommand _addInventoryManagemenAgile;
        public DelegateCommand AddInventoryManagemenAgile
        {
            get
            {
                return _addInventoryManagemenAgile ?? (_addInventoryManagemenAgile = new DelegateCommand
                {
                    Execute = () =>
                    {
                        //random
                        UserPoints.InventoryManagement = InventoryManagement.INVENTORYMANAGEMENT.Agile.ToString();
                        ToogleBoolInventoryManagementBig = false;
                        ToogleBoolInventoryManagementSmall = false;
                    }
                });
            }
        }
        private bool _toogleBoolInventoryManagementAgile = true;
        public bool ToogleBoolInventoryManagementAgile
        {
            get { return _toogleBoolInventoryManagementAgile; }
            set
            {
                _toogleBoolInventoryManagementAgile = value;
                OnPropertyChanged(nameof(ToogleBoolInventoryManagementAgile));
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
                    " quality " + UserPoints.Quality.ToString() +
                    " delivery " + UserPoints.Delivery.ToString();
            }
        }
    }
}
