using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace POE_PART_1_ST10115510
{
    public static class VacMonitor
    {
        [FunctionName("id")]
        public static async Task<IActionResult> Run(

            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "id/{idNum1?}")] HttpRequest req, float idNum1,
            ILogger log)

        {
            log.LogInformation("Vaccine monitor processed an action ");
           
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            string responseMessage;

            if (idNum1 == null)
            {
                responseMessage = "Please enter a ID or Passport ";
            }
            else 
            {
                if (idNum1.Equals(3205065800080))
                {
                    responseMessage = "Welcome Peter Davids" + "\n" + "Gender: MALE" + "\n" + "Covid status: NEGATIVE" + "\n" + "vaccination status: FULLY VACCINATED ";
                }
                else 
                {
                    if (idNum1.Equals(2605064800083))
                    {
                        responseMessage = "Welcome Sandra Woods" + "\n" + "Gender: FEMALE" + "\n" + "Covid status: NEGATIVE" + "\n" +  "vaccination status: FULLY VACCINATED";
                    }
                    else
                    {
                        if (idNum1.Equals(5811154800085))
                        {
                            responseMessage = "Welcome Lena Reed" + "\n" + "Gender: FEMALE" + "\n" + "Covid status: NEGATIVE" + "\n" + "vaccination status: NOT VACCINATED ";
                        }
                        else
                        {
                            if (idNum1.Equals(2811195800089))
                            {
                                responseMessage = "Welcome Joseph James" + "\n" +  "Gender: MALE" + "\n" + "Covid status: NEGATIVE" + "\n" + "vaccination status: 1/2 VACCINATED ";
                            }
                            else
                            {
                                responseMessage = "invallid ID or Passport no entered.";
                            }
                        }
                    }
                }
            }
            return new OkObjectResult(responseMessage);
        }
    }
}
