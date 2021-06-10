using LeaveMgt.Models;
using LeaveMgt.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMgt.API_Services.EmployeeServices
{
    public class EmployeeService
    {
        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync("https://leavemanagementsdsd.azurewebsites.net/api/v1/Employee");
            return JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(result);
        }
        public async Task<EmployeeModel> GetEmployee(string id)
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync("https://leavemanagementsdsd.azurewebsites.net/api/v1/Employee{id}" + id);
            return JsonConvert.DeserializeObject<EmployeeModel>(result);
        }

        public async Task<EmployeeModel> Addemployee(string firstName, string lastName, string address, DateTime dateOfBirth, DateTime employmentDate, string email, object telephone, object userRole)
        {
            EmployeeModel employee = new EmployeeModel()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                DateOfBirth = dateOfBirth,
                EmploymentDate = employmentDate,
                Email = email,
                Telephone = telephone,
                UserRole = userRole    
            };

            HttpClient client = new HttpClient();
            var response = await client.PostAsync("https://leavemanagementsdsd.azurewebsites.net/api/v1/Employee",
                new StringContent(
                    JsonConvert.SerializeObject(employee),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<EmployeeModel>(
                await response.Content.ReadAsStringAsync());
        }
    }
}
