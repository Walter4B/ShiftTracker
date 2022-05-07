using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ShiftsTrackerUI.Models;

namespace ShiftsTrackerUI
{
    internal class CRUDEngine
    {
       

        static HttpClient client = new HttpClient();

        static void ShowALLShift(List<Shift> shift)
        {
            List<string> titles = new List<string>();
            TableDisplayEngine tableDisplayEngine = new TableDisplayEngine();
            tableDisplayEngine.DisplayTable(shift, titles);
        }

        static void ShowShift(Shift shift)
        {
            Console.WriteLine(shift.ShiftId);
        }

        static async Task<Uri> CreateShiftAsync(Shift shift)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/Shifts", shift);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<Shift> GetShiftAsync(string path)
        {
            Shift shift = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                shift = await response.Content.ReadAsAsync<Shift>();
            }
            return shift;
        }

        static async Task<Shift> UpdateShiftAsync(Shift shift)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/shifts/{shift.ShiftId}", shift);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated shift from the response body.
            shift = await response.Content.ReadAsAsync<Shift>();
            return shift;
        }

        static async Task<HttpStatusCode> DeleteShiftAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/Shifts/{id}");
            return response.StatusCode;
        }

        static async Task RunAsync(int option)
        {
            DataUserToEngine dataUserToEngine = new DataUserToEngine();

            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:7419/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Shift shift = new Shift();
            try
            {
                switch (option)
                {
                    case 0:
                        break;
                    case 1: //Create shift
                        shift = dataUserToEngine.PopulateShiftData();
                        CreateShiftAsync(shift);
                        break;
                    case 2: //Read shifts

                        break;
                    case 3: //Update shift
                        shift = dataUserToEngine.PopulateShiftData();
                        UpdateShiftAsync(shift);
                        break;
                    case 4: //Delete shift
                        int deleteID = dataUserToEngine.GetDelitionId();
                        DeleteShiftAsync(deleteID.ToString());
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
}

        internal void RunEngine(int operationOption)
        {
            
            RunAsync(operationOption).GetAwaiter().GetResult();
        }

        internal async Task CreateShift()
        {
            try
            {
                // Create a new shift
                Shift shift = new Shift
                {
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Pay = 1.5M,
                    Minutes = 1,
                    Location = "London"
                };

                var url = await CreateShiftAsync(shift);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
