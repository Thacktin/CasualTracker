using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasualTracker.ViewModel
{
    public class AddWorkplaceViewModel : BindingSource
    {
        public DelegateCommand ReturnCommand { get; private set; }
        public DelegateCommand AddWorkplaceCommand { get; private set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public AddWorkplaceViewModel(DelegateCommand returnCommand, DelegateCommand addWorkplaceCommand)
        {
            ReturnCommand = returnCommand;
            AddWorkplaceCommand = addWorkplaceCommand;
        }

    }
}
