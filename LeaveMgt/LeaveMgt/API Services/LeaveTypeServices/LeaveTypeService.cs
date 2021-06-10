using LeaveMgt.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMgt.API_Services.LeaveTypeServices
{
    public class LeaveTypeService
    {
        public async Task<IEnumerable<LeaveTypeModel>> GetAll()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync("https://localhost:44320/api/v1/LeaveType");
            return JsonConvert.DeserializeObject<IEnumerable<LeaveTypeModel>>(result);
        }

        public async Task<LeaveTypeModel> GetALeaveType(string id)
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync("https://leavemanagementsdsd.azurewebsites.net/api/v1/LeaveType/{id}" + id);
            return JsonConvert.DeserializeObject<LeaveTypeModel>(result);
        }

        public async Task<LeaveTypeModel> AddLeave(LeaveTypeModel model)
        {
            LeaveTypeModel leaveType = new LeaveTypeModel()
            {
               Id = model.Id,
               Duration = model.Duration,
               Name = model.Name
            };

            HttpClient client = new HttpClient();
            var response = await client.PostAsync("https://leavemanagementsdsd.azurewebsites.net/api/v1/LeaveType",
                new StringContent(
                    JsonConvert.SerializeObject(leaveType),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<LeaveTypeModel>(
                await response.Content.ReadAsStringAsync());
        }
        
        public async Task DeleteLeave(string id)
        {
            HttpClient client = new HttpClient();
            await client.DeleteAsync("https://leavemanagementsdsd.azurewebsites.net/api/v1/LeaveType/delete_{id}" + id);
        }
    }
}
