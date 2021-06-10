using LeaveMgt.API_Services.LeaveServices;
using LeaveMgt.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMgt.ViewModels
{
    public class AllRequestsViewModel : BaseViewModel
    {
        private ObservableCollection<LeaveModel> _leaveApplication;

        public ObservableCollection<LeaveModel> LeaveApplication
        {
            get { return _leaveApplication; }
            set { _leaveApplication = value; OnPropertyChanged(); }
        }

        public AllRequestsViewModel()
        {
            LeaveApplication = new ObservableCollection<LeaveModel>();
            GetAllRequests();
        }

        private async void GetAllRequests()
        {
           var result =  await new LeaveService().GetAll();
            LeaveApplication.Clear();
            foreach(var item in result)
            {
                LeaveApplication.Add(item);
            }
        }
    }
}
