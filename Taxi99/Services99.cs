using System;
using System.Collections.Generic;
using System.Text;
using Taxi99.Models;
using Taxi99.GlobalServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Taxi99
{
    public class Services99 : IDisposable
    {
        private RestService _restService;

        /// <summary>
        /// Constroi o Serviço passando uma API Token
        /// Você pode solicitar a API em https://api-corp.99app.com/docs
        /// Você tambem pode passar o endereço de acesso da API caso esteja diferente.
        /// </summary>
        /// <param name="apiToken">Api Token adiquirido com a 99 Taxi</param>
        /// <param name="apiUrl">Url da api, OPCIONAL</param>
        public Services99(string apiToken, string apiUrl = "https://api-corp.99app.com/v1")
        {
            if (String.IsNullOrEmpty(apiToken))
                throw new Exception("Voce precisa passar um token");

            _restService = new RestService(apiToken, apiUrl);
        }

        public void Dispose()
        {
            _restService.Dispose();
        }

        #region Companies

        public async Task<ApiResponse<List<Company>>> GetCompanies()
        {
            var response = await _restService.Get<List<Company>>("companies");

            return response;
        }

        #endregion

        #region CostCenters

        public async Task<ApiResponse<List<CostCenter>>> GetListCostCenter(string search = "", int page = 1, int limit = 10)
        {
            var response = await _restService.Get<List<CostCenter>>($"costcenter", $"search={search}&page={page}&limit={limit}");

            return response;
        }

        public async Task<ApiResponse<CostCenter>> GetCostCenterByID(int id)
        {
            var response = await _restService.Get<CostCenter>($"costcenter/{id}");

            return response;
        }

        public async Task<ApiResponse<string>> DeleteCostCenter(int id)
        {
            var status = await _restService.Delete($"costcenter/{id}");

            return status;
        }

        public async Task<ApiResponse<CostCenter>> RegisterCostCenter(string name)
        {
            var costcenter = new CostCenter
            {
                name = name
            };
        
            var response = await _restService.Post<CostCenter>($"costcenter", JsonConvert.SerializeObject(costcenter));
        
            return response;
        }

        public async Task<ApiResponse<List<CostCenter>>> GetCostCenterByEmployeeID(int id)
        {
            var response = await _restService.Get< List<CostCenter>>($"/employee/{id}/costcenter");

            return response;
        }


        #endregion

        #region Employees

        public async Task<ApiResponse<Employee>> GetEmployeeByID(int id)
        {
            var response = await _restService.Get<Employee>($"employee/{id}");

            return response;
        }

        public async Task<ApiResponse<Employee>> UpdateEmployeeByID(int id, Employee employee)
        {
            var response = await _restService.Put<Employee>($"employee/{id}", JsonConvert.SerializeObject(employee));

            return response;
        }

        public async Task<ApiResponse<string>> DeleteEmployee(int id)
        {
            var status = await _restService.Delete($"employee/{id}");

            return status;
        }

        public async Task<ApiResponse<List<Employee>>> GetListEmployee(string search = "", int page = 1, int limit = 10, int offset = 0, string nationalId = "")
        {
            var response = await _restService.Get<List<Employee>>($"employee", 
                $"search={search}&page={page}&limit={limit}&offset={offset}&nationalId={nationalId}");

            return response;
        }

        public async Task<ApiResponse<Employee>> RegisterEmployee(EmployeeRegister employee)
        {
            var response = await _restService.Post<Employee>($"employee", JsonConvert.SerializeObject(employee));

            return response;
        }

        public async Task<ApiResponse<List<RideEstimate>>> EstimateEmployeeRide(int employeeID, int fromLat, int fromLng, int toLat, int toLng)
        {
            var response = await _restService.Get<List<RideEstimate>>($"employee/{employeeID}/categories", 
                $"employeeID={employeeID}&fromLat={fromLat}&fromLng={fromLng}&toLat={toLat}&toLng={toLng}");

            return response;
        }

        public async Task<ApiResponse<string>> DeleteEmployeeCostCenter(int employeeID, int costCenterID)
        {
            var status = await _restService.Delete($"/employee/{employeeID}/costcenter/{costCenterID}");

            return status;
        }

        public async Task<ApiResponse<string>> DeleteEmployeeSupervisor(int id)
        {
            var status = await _restService.Delete($"/employee/{id}/supervisor");

            return status;
        }

        #endregion

        #region Jobs

        public async Task<ApiResponse<Job>> GetJobByID(int id)
        {
            var response = await _restService.Get<Job>($"/job/{id}");

            return response;
        }

        public async Task<ApiResponse<List<Job>>> GetListJob(DateTime startDate, 
                                                DateTime endDate, 
                                                int? costCenterId = null, 
                                                int? projectId = null, 
                                                string taxiCategory = "", 
                                                int page = 1,
                                                int limit = 10,
                                                int offset = 0)
        {
            string query = "";

            query += $"{startDate.ToString("s")}&";
            query += $"{endDate.ToString("s")}&";
            query += costCenterId.HasValue ? $"{costCenterId.Value.ToString()}&" : "";
            query += projectId.HasValue ? $"{projectId.Value.ToString()}&" : "";
            query += $"{taxiCategory}&";
            query += $"{page}&";
            query += $"{limit}&";
            query += $"{offset}&";

            var response = await _restService.Get<List<Job>>($"employee", query);

            return response;
        }

        #endregion

        #region Projects

        //TODO

        #endregion

        #region Rides

        public async Task<ApiResponse<Ride>> GetRideByID(int id)
        {
            var response = await _restService.Get<Ride>($"/ride/{id}");

            return response;
        }

        public async Task<ApiResponse<string>> CancelRide(int id)
        {
            var status = await _restService.Delete($"/ride/{id}");

            return status;
        }

        public async Task<ApiResponse<List<Ride>>> GetActiveRide()
        {
            var response = await _restService.Get<List<Ride>>($"/ride");

            return response;
        }

        public async Task<ApiResponse<string>> BookRide(Ride ride)
        {
            var response = await _restService.Post<string>($"/ride", JsonConvert.SerializeObject(ride));
        
            return response;
        }

        #endregion
    }
}
