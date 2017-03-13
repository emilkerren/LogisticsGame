using LogisticsGame.Common;

namespace LogisticsGame.ViewModels
{
    public class ApplicationViewModel : Extensions
    {
        /// <summary>
        ///Keeps track of/sets the current window and viewmodel being used
        /// </summary>
        private IApplicationWindow _currentPage;
        public IApplicationWindow CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }
        public ApplicationViewModel()
        {
            CurrentPage = new StepOneViewModel { Navigate = Navigate };
        }
        /// <summary>
        /// Main method of changing viewmodel
        /// </summary>
        /// <param name="viewModel"></param>
        public void Navigate(IApplicationWindow viewModel)
        {
            CurrentPage = viewModel;
        }
        
    }
}
