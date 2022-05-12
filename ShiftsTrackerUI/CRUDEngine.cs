using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ShiftsTrackerUI.Models;
using System.Threading.Tasks;

namespace ShiftsTrackerUI
{
    internal class CRUDEngine
    {
        Shift shift = new Shift();

        static HttpClient client = new HttpClient();

        static async Task<Uri> CreateProductAsync(Shift shift)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "shifts", shift);
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
                $"shifts/{shift.ShiftId}", shift);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated shift from the response body.
            shift = await response.Content.ReadAsAsync<Shift>();
            return shift;
        }

        static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"shifts/{id}");
            return response.StatusCode;
        }

        internal async void Run()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync() //Implemented using local functions
        {
            OutputEngine outputEngine = new OutputEngine();
            InputEngine inputEngine = new InputEngine();

            client.BaseAddress = new Uri("https://localhost:7197/api/");
           
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
                            await StartShift();
                            break;
                        case 2: //Show a shift by ID
                            await GetShiftByID();
                            break;
                        case 3: //Show all shifts
                            await GetAllShifts();
                            break;
                        case 4: //End a shift
                            await EndShift();
                            break;
                        case 5: //Update a shift
                            await FullUpdateShift();
                            break;
                        case 6: //Delete a shift
                            await DeleteShift();
                            break;
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
                TableDisplayEngine tableDisplayEngine = new TableDisplayEngine();

                Shift shift = new Shift();

                int ShiftID = dataUserToEngine.IDshiftPopulate();
                shift = await GetProductAsync($"Shifts/{ShiftID}");
                tableDisplayEngine.DisplayTable(shift);
            }

            static async Task GetAllShifts()
            {
                DataUserToEngine dataUserToEngine = new DataUserToEngine();
                TableDisplayEngine tableDisplayEngine = new TableDisplayEngine();

                List<Shift> shifts = new List<Shift>();

                shifts = await GetMultipleProductAsync("Shifts");
                tableDisplayEngine.DisplayTable(shifts);
            }

            static async Task EndShift()
            {
                DataUserToEngine dataUserToEngine = new DataUserToEngine();

                Shift shift = new Shift();

                int ShiftID = dataUserToEngine.IDshiftPopulate();
                shift = await GetProductAsync($"Shifts/{ShiftID}");
                shift = dataUserToEngine.EndShiftPopulate(shift);
                await UpdateProductAsync(shift);
            }

            static async Task FullUpdateShift()
            {
                DataUserToEngine dataUserToEngine = new DataUserToEngine();

                Shift shift = new Shift();

                int ShiftID = dataUserToEngine.IDshiftPopulate();
                shift = await GetProductAsync($"Shifts/{ShiftID}");
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