using LogisticsGame.Common;

namespace LogisticsGame.Models
{
    public class UserClass : Extensions
    {
        /// <summary>
        /// sets the type we select in view
        /// </summary>
        private string _corporateCulture;
        public string CorporateCultureUser
        {
            get { return _corporateCulture; }
            set
            {
                _corporateCulture = value;
                OnPropertyChanged(nameof(CorporateCultureUser));
            }
        }
        /// <summary>
        /// sets the type we select in view
        /// </summary>
        private string _qualityAssurance;
        public string QualityAssuranceUser
        {
            get { return _qualityAssurance; }
            set
            {
                _qualityAssurance = value;
                OnPropertyChanged(nameof(QualityAssuranceUser));
            }
        }
        /// <summary>
        /// sets the type we select in view
        /// </summary>
        private string _supplier;
        public string SupplierUser
        {
            get { return _supplier; }
            set
            {
                _supplier = value;
                OnPropertyChanged(nameof(SupplierUser));
            }
        }
        /// <summary>
        /// sets the type we select in view
        /// </summary>
        private string _employees;
        public string EmployeesUser
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(EmployeesUser));
            }
        }
        /// <summary>
        /// sets the type we select in view
        /// </summary>
        private string _inventoryManagement;
        public string InventoryManagement
        {
            get { return _inventoryManagement; }
            set
            {
                _inventoryManagement = value;
                OnPropertyChanged(nameof(InventoryManagement));
            }
        }
        /*private Production _production;
        private OutboundStock _outboundStock;
        private Distributor _distributor;
        private Sales _sales;*/

        /// <summary>
        /// user stat property
        /// </summary>
        private int _safety;
        public int Safety
        {
            get { return _safety; }
            set
            {
                _safety = value;
                OnPropertyChanged(nameof(Safety));
            }
        }
        /// <summary>
        /// user stat property
        /// </summary>
        private int _time;

        public int Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }
        /// <summary>
        /// user stat property
        /// </summary>
        private int _quality;
        public int Quality
        {
            get { return _quality; }
            set
            {
                _quality = value;
                OnPropertyChanged(nameof(Quality));
            }
        }
        /// <summary>
        /// user stat property
        /// </summary>
        private int _envirement;
        public int Envirement
        {
            get { return _envirement; }
            set
            {
                _envirement = value;
                OnPropertyChanged(nameof(Envirement));
            }
        }
        /// <summary>
        /// user stat property
        /// </summary>
        private int _price;
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        /// <summary>
        /// user stat property
        /// </summary>
        private int _delivery;
        public int Delivery
        {
            get { return _delivery; }
            set
            {
                _delivery = value;
                OnPropertyChanged(nameof(Delivery));
            }
        }
        /// <summary>
        /// constructor that sets initial values of the user stat properties
        /// </summary>
        public UserClass()
        {
            Price = 5;
            Quality = 5;
            Safety = 5;
            Time = 5;
            Envirement = 5;
            Delivery = 5;
        }

    } 
}
