using LeaveMgt.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LeaveMgt.ViewModels
{
    public class LeaveApplicationViewModel : BaseViewModel
    {
       
        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
                this._IsBusy = false;
                OnPropertyChanged();
            }
            get
            {
                return this._IsBusy;
            }
        }


    
    }
}
