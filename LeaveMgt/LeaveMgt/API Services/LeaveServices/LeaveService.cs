using LeaveMgt.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMgt.API_Services.LeaveServices
{
    public class LeaveService
    {
        public async Task<IEnumerable<LeaveModel>> GetAll()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync("https://leavemanagementsdsd.azurewebsites.net/api/v1/Leave");
            return JsonConvert.DeserializeObject<IEnumerable<LeaveModel>>(result);
        }

        public async Task<LeaveModel> GetALeave(string id)
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync("https://leavemanagementsdsd.azurewebsites.net/api/v1/Leave{id}" + id);
            return JsonConvert.DeserializeObject<LeaveModel>(result);
        }

        public async Task<LeaveModel> AddLeave(LeaveModel model)
        {
            LeaveModel leave = new LeaveModel()
            {
                Id = model.Id,
                Employee = model.Employee,
                LeaveType = model.LeaveType,
                Status = model.Status,
                EmployeeId = model.EmployeeId,
                LeaveTypeId = model.LeaveTypeId
            };

            HttpClient client = new HttpClient();
            var response = await client.PostAsync("https://leavemanagementsdsd.azurewebsites.net/api/v1/Leave",
                new StringContent(
                    JsonConvert.SerializeObject(leave),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<LeaveModel>(
                await response.Content.ReadAsStringAsync());
        }


        public async Task DeleteLeave(string id)
        {
            HttpClient client = new HttpClient();
            await client.DeleteAsync("https://leavemanagementsdsd.azurewebsites.net/api/v1/Leave/delete_{id}" + id);
        }
    }
}
