using BombastLauncher.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace BombastLauncher
{
    class ApplicationViewModel
    {

        private ICommand _changePageCommand;

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                }
            }
        }

        public ApplicationViewModel()
        {
            _pageViewModels = new List<IPageViewModel>
            {
                new LoginViewModel(),
                new BaseLauncherViewModel()
            };

            ChangeViewModel(_pageViewModels[0]);
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if(!_pageViewModels.Contains(viewModel))
            {
                _pageViewModels.Add(viewModel);
            }

            _currentPageViewModel = _pageViewModels.FirstOrDefault(vm => vm == viewModel);
        }
    }
}
