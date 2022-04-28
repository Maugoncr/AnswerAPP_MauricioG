using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace AnswerAPP_MauricioG.Models
{
    public class Ask
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public Ask()
        {
            Answers = new HashSet<Answer>();
        }

        public long AskId { get; set; }
        public DateTime Date { get; set; }
        public string Ask1 { get; set; }
        public int UserId { get; set; }
        public int AskStatusId { get; set; }
        public bool? IsStrike { get; set; }
        public string ImageUrl { get; set; }
        public string AskDetail { get; set; }

        public virtual AskStatus AskStatus { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }


        //esta funcion llama a la ruta GetQuestionsListByUserID(pUserID) que retornará un json 
        //que luego debemos convertir a clase(modelo) Ask.

        public async Task<ObservableCollection<Ask>>  GetQuestionListByUser()
        {

            try
            {
  
                string routeSufix = string.Format("Asks/GetQuestionsListByUserID?pUserID={0}",
                    this.UserId);

                string FinalApiRoute = CnnToAPI.ProductiorRoute + routeSufix;


                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);


                //agregar la info de seguridad, en este caso api key

                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);

                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject< ObservableCollection<Ask>>(response.Content);



                if (statusCode == HttpStatusCode.OK)
                {
                    return QList;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                throw;
            }





        }





    }
}
