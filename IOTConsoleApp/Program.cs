using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IOTConsoleApp
{
    class Program
    {
        //initialize httpClient to make http calls
        private HttpClient _httpClient = null;

        //The const(final) value of token assigned by OPen Weather Api
        private string ApiKey = string.Empty;

        //Constructor
        public Program()
        {
            _httpClient = new HttpClient();

            //assigning the base address to http client for open weather
            _httpClient.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/weather");
            ApiKey = "f964cb899d76cf18bf20cdba2c6ef574";

        }
        /// <summary>
        /// Get the data from Open weather api by entering location name on the console
        /// This method is asyncronous as it makes call to external source(open weather api), hence it returns data as Task
        /// </summary>
        /// <param name="locationInUs"></param>
        /// <returns></returns>
        public async Task<string> GetByLocationName(string locationInUs)
        {
            //?q=phoenix,US&appId=f964cb899d76cf18bf20cdba2c6ef574
            
            string appendingUrl = "?q=" + locationInUs + "&appId=" + ApiKey;

            HttpResponseMessage apiResponse = await _httpClient.GetAsync(appendingUrl);
            
            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await apiResponse.Content.ReadAsStringAsync();
            }
            else return "";
        }

        /// <summary>
        /// Get the data from Open weather api by entering zipcode on the console
        /// This method is asyncronous as it makes call to external source(open weather api), hence it returns data in thread
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public async Task<string> GetByZipCodeAsync(string zipCode)
        {
            // url for zipcode ?zip=94040,us&appid=b6907d289e10d714a6e88b30761fae22
            string appendingUrlZipCode = "?zip=" + zipCode + "&appId=" + ApiKey;

            //Making a Get Http Call to Oopen Weather with parameters zip and apikey
            //We hae to await this call, since it is in asynchronous method
            var apiResponse = await _httpClient.GetAsync(appendingUrlZipCode);

            //checking the status code returned by httpresponse
            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await apiResponse.Content.ReadAsStringAsync();
            }
            else return string.Empty;
            
            
        }

        //Main Method
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the Location");
            //reading from console
            string locationInUs = Console.ReadLine();
            //creating an object of program since in static method
            Program program = new Program();

            //getting the location by locationName
            //I did not await the method GetByLocationName, because to await methods in a static method is not a good practice
            //Hence I got the reult by GetAwaiter.GetResult
            string locationJSOnData = program.GetByLocationName(locationInUs).GetAwaiter().GetResult();

            //displaying gotten data in JSONn format
            Console.WriteLine(locationJSOnData);
            //Console.Read();

            // getting data by zip code

             Console.WriteLine("Enter Zip Code");
             string zipCode = Console.ReadLine();
            string zipCodeJSonData = program.GetByZipCodeAsync(zipCode).GetAwaiter().GetResult();

            Console.WriteLine(zipCodeJSonData);
            Console.Read();
        }

    }
}
