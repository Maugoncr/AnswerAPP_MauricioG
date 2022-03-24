using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using System.Net;

namespace AnswerAPP_MauricioG.Models
{
    public class User
    {
        public User()
        {
            Answers = new HashSet<Answer>();
            Asks = new HashSet<Ask>();
            ChatReceivers = new HashSet<Chat>();
            ChatSenders = new HashSet<Chat>();
            Likes = new HashSet<Like>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserPassword { get; set; }
        public int StrikeCount { get; set; }
        public string BackUpEmail { get; set; }
        public string JobDescription { get; set; }
        public int UserStatusId { get; set; }
        public int CountryId { get; set; }
        public int UserRoleId { get; set; }

        public virtual Country Country { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual UserStatus UserStatus { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Ask> Asks { get; set; }
        public virtual ICollection<Chat> ChatReceivers { get; set; }
        public virtual ICollection<Chat> ChatSenders { get; set; }
        public virtual ICollection<Like> Likes { get; set; }


        public async Task<bool> AddNewUser() {

            bool R = false;

            string FinalApiRoute = CnnToAPI.ProductiorRoute + "users";  // puede que falte el /

            var client = new RestClient(FinalApiRoute);

            var request = new RestRequest();
            
            request.Method = Method.Post;




            // se debe agregar la info del apikey en el header
            request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
            request.AddHeader("Content-Type", "application/json");

            //se serializa la clase junto con la informacion contenida en sus atributos
            string SerializedClass = JsonConvert.SerializeObject(this);

            // Agregar la clase serializada al body del request.
            // esto puede ser facilmente interseptado 
            request.AddParameter("application/json", SerializedClass, ParameterType.RequestBody);

            //ahora ejecutamos la ruta del api

            RestResponse response = await client.ExecuteAsync(request);

            HttpStatusCode statusCode = response.StatusCode;

            if (statusCode == HttpStatusCode.Created) 
            {
                R = true;
                
            
            }


            return R;
        }



    }
}
