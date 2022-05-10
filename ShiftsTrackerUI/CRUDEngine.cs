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
        Shift shift = new Shift();

        static HttpClient client = new HttpClient();

        static void ShowProduct(Shift shift)
        {
            Console.WriteLine($"Name: {shift.ShiftId.ToString()}\tPrice: " +
                $"{shift.Pay}\tCategory: {shift.Location}");
        }

        static async Task<Uri> CreateProductAsync(Shift shift)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/shifts", shift);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<Shift> GetProductAsync(string path)
        {
            Shift shift = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                shift = await response.Content.ReadAsAsync<Shift>();
            }
            return shift;
        }

        static async Task<List<Shift>> GetMultipleProductAsync(string path)
        {
            List<Shift> shifts = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                shifts = await response.Content.ReadAsAsync<List<Shift>>();
            }
            return shifts;
        }

        static async Task<Shift> UpdateProductAsync(Shift shift)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/shifts/{shift.ShiftId}", shift);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated shift from the response body.
            shift = await response.Content.ReadAsAsync<Shift>();
            return shift;
        }

        static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/shifts/{id}");
            return response.StatusCode;
        }

        internal async void Run()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            OutputEngine outputEngine = new OutputEngine();
            InputEngine inputEngine = new InputEngine();

            // Update port # in the following line.
            client.BaseAddress = new Uri("https://localhost:7197/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("api/Shifts"));
            //Shift shift = new Shift();
            while (true)
            {
                try
                {
                    //Console.Clear();
                    outputEngine.DisplayMessage("MainMenu");
                    int option = inputEngine.GetInputInt();
                    switch (option)
                    {
                        case 0: //Close app
                            Environment.Exit(0);
                            break;
                        case 1: //Start shift
                            StartShift();
                            break;
                        case 2: //Show a shift by ID
                            GetShiftByID();
                            break;
                        case 3: //Show all shifts
                            GetAllShifts();
                            break;
                        case 4: //End a shift
                            EndShift();
                            break;
                        case 5: //Update a shift
                            FullUpdateShift();
                            break;
                        case 6: //Delete a shift
                            break;
                            DeleteShift();
                        default:
                            outputEngine.DisplayMessage("InvalidInput");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            static async Task StartShift()
            {
                DataUserToEngine dataUserToEngine = new DataUserToEngine();

                Shift shift = dataUserToEngine.StartShiftPopulate();
                
                var url = await CreateProductAsync(shift);
            }

            static async Task GetShiftByID()
            {
                DataUserToEngine dataUserToEngine = new DataUserToEngine();

                Shift shift = new Shift();

                int ShiftID = dataUserToEngine.IDshiftPopulate();
                shift = await GetProductAsync($"https://localhost:7197/api/Shifts/{ShiftID}");
            }

            static async Task GetAllShifts()
            {
                DataUserToEngine dataUserToEngine = new DataUserToEngine();

                List<Shift> shifts = new List<Shift>();

                shifts = await GetMultipleProductAsync("https://localhost:7197/api/Shifts/");
            }

            static async Task EndShift()
            {
                DataUserToEngine dataUserToEngine = new DataUserToEngine();

                Shift shift = new Shift();

                int ShiftID = dataUserToEngine.IDshiftPopulate();
                shift = await GetProductAsync($"https://localhost:7197/api/Shifts/{ShiftID}");
                shift = dataUserToEngine.EndShiftPopulate(shift);
                await UpdateProductAsync(shift);
            }

            static async Task FullUpdateShift()
            {
                DataUserToEngine dataUserToEngine = new DataUserToEngine();

                Shift shift = new Shift();

                int ShiftID = dataUserToEngine.IDshiftPopulate();
                shift = await GetProductAsync($"https://localhost:7197/api/Shifts/{ShiftID}");
                shift = dataUserToEngine.FullUpdatePopulate();
                await UpdateProductAsync(shift);
            }

            static async Task DeleteShift()
            {
                DataUserToEngine dataUserToEngine = new DataUserToEngine();
                int ShiftID = dataUserToEngine.IDshiftPopulate();

                var statusCode = await DeleteProductAsync(ShiftID.ToString());
            }
        }
    }
}