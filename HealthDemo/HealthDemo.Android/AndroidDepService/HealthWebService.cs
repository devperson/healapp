using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using HealthDemo.Service;
using HealthDemo.Models.ResponseModel;
using HealthDemo.Service.RequestModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HealthDemo;
using HealthDemo.Models;

[assembly: Xamarin.Forms.Dependency(typeof(HealthWebService))]
namespace HealthDemo
{
    /// <summary>
    /// This class provides functions for accessing data service.
    /// </summary>
    public class HealthWebService : IWebService
    {
        private RestClient client;
        private string _local;
        protected RestClient Client
        {
            get
            {
                return client;
            }
        }
        public HealthWebService()
		{            
			client = new RestClient(Constants.ApiUrl);
			client.AddDefaultHeader("Accept", "application/json");
		}

        /// <summary>
        /// Helper method produce string with local param
        /// </summary>        
        private string AddLocalVar(string apiName)
        {
            return string.Format("{0}?local={1}", apiName, _local);
        }

        /// <summary>
        /// Method provides Search doctors service call.
        /// </summary>        
        public async void SearchDoctors(SearchDoctorRequest request, Action<DoctorResponse> onCompleted)
        {
            request.Local = this._local;
            var asyncResult = await ExecuteServiceMethod<DoctorResponse>("doctors/SearchDoctors", Method.POST,content =>
            {
                var response = new DoctorResponse() { Result = JsonConvert.DeserializeObject<List<Doctor>>(content) };
                return response;
            }, request);
            onCompleted(asyncResult);
        }

        /// <summary>
        /// Method provides load tip categories service call.
        /// </summary>     
        public async void GetCategories(Action<CategoryResponse> onCompleted)
        {
            var asyncResult = await ExecuteServiceMethod<CategoryResponse>(AddLocalVar("TipCategories"), Method.GET, content =>
            {
                var response = new CategoryResponse() { Result = JsonConvert.DeserializeObject<List<HealthCategory>>(content) };
                return response;
            });
            onCompleted(asyncResult);
        }

        /// <summary>
        /// Method provides load tips service call.
        /// </summary>    
        public async void GetHealthTipsByCategory(int categoryID, Action<HealthTipResponse> onCompleted)
        {
            var asyncResult = await ExecuteServiceMethod<HealthTipResponse>(string.Format("Tips/GetByCatId/?id={0}&local={1}", categoryID, _local), Method.GET, content =>
            {
                var response = new HealthTipResponse() { Result = JsonConvert.DeserializeObject<List<HealthTip>>(content) };
                return response;
            });
            onCompleted(asyncResult);
        }

        /// <summary>
        /// Method provides load specialties service call.
        /// </summary>    
        public async void GetSpecialties(Action<PositionResponse> onCompleted)
        {
            var asyncResult = await ExecuteServiceMethod<PositionResponse>(AddLocalVar("position"), Method.GET, content =>
                {
                    var response = new PositionResponse() { Result = JsonConvert.DeserializeObject<List<DocPosition>>(content) };
                    return response;
                });
            onCompleted(asyncResult);
        }

        /// <summary>
        /// Method provides load insurances service call.
        /// </summary>    
        public async void GetInsurances(Action<InsuranceResponse> onCompleted)
        {
            var asyncResult = await ExecuteServiceMethod<InsuranceResponse>(AddLocalVar("insurance"), Method.GET, content =>
            {
                var response = new InsuranceResponse() { Result = JsonConvert.DeserializeObject<List<Insurance>>(content) };
                return response;
            });
            onCompleted(asyncResult);
        }

        /// <summary>
        /// Method provides register appointment service call.
        /// </summary>    
		public async void CreateAppointment(Appointment appoint, Action<ResponseBase> onCompleted)
		{
			var asyncResult = await ExecuteServiceMethod<ResponseBase> ("appointment/RequestAppointment", Method.POST, content => {
				var response = new ResponseBase();
				return response;
			}, appoint);
			onCompleted(asyncResult);
		}

        /// <summary>
        /// Method provides register file service call.
        /// </summary>    
		public async void CreateFile(FileModel file, Action<ResponseBase> onCompleted)
		{
			var asyncResult = await ExecuteServiceMethod<ResponseBase> ("fileservice/createfile", Method.POST, content => {
				var response = new ResponseBase();
				return response;
			}, file);
			onCompleted(asyncResult);
		}

        /// <summary>
        /// Method provides register object service call.
        /// </summary>    
        public async void PostObject<T>(string requestUrl, T obj, Action<ResponseBase> onCompleted)
        {
            var asyncResult = await ExecuteServiceMethod<ResponseBase>(requestUrl, Method.POST, content =>
            {
                var response = new ResponseBase();
                return response;
            }, obj);
            onCompleted(asyncResult);
        }

        /// <summary>
        /// Helper method for sending http commands.
        /// </summary>        
        public Task<T> ExecuteServiceMethod<T>(string resource, Method method, Func<string, T> deserialiser, object requestObject = null) where T : ResponseBase
        {
            var restRequest = new RestRequest(resource, method);
            if (requestObject != null)
            {
                restRequest.RequestFormat = DataFormat.Json;
				restRequest.AddBody(requestObject);
            }

            return Task.Run<T>(() =>
            {
                T response = Activator.CreateInstance<T>();
                var errorResponse = new ErrorResponseModel();
                try
					{
                    var restResponse = Client.Execute(restRequest);
                    this.CheckServer(restResponse.Content);
                    if (!string.IsNullOrEmpty(restResponse.Content))
                    {
                        response = deserialiser(restResponse.Content);// JsonConvert.DeserializeObject<T>(restResponse.Content);
                        if (restResponse.Content.Contains("ExceptionMessage"))
                            errorResponse = JsonConvert.DeserializeObject<ErrorResponseModel>(restResponse.Content);
                        else response.Success = true;
                    }
                    else
                    {                        
                        errorResponse.ExceptionMessage = Constants.NoInternetMessage;
					    response.Success = false;
                    }
                    if (errorResponse != null && !string.IsNullOrEmpty(errorResponse.ExceptionMessage))
                    {
                        response.Success = false;
                        response.ErrorMessage = errorResponse.ExceptionMessage;
                    }
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.ErrorMessage = "Server is down please try later.";
                }
                return response;
            });
        }

        /// <summary>
        /// Helper method for validating service result.
        /// </summary>        
        public void CheckServer(string responsString)
        {
            string htmlContent = "<!DOCTYPE";
            if (responsString.Contains(htmlContent))
                throw new Exception("Server is down please try later.");
        }

        /// <summary>
        /// Generic method for retriving list data from service
        /// </summary>        
        public async void GetList<T, modelT>(string uri, Action<T> onCompleted) where T : ResponseBase
        {
            var asyncResult = await ExecuteServiceMethod<T>(AddLocalVar(uri), Method.GET, content =>
            {
                var response = Activator.CreateInstance<T>();
                var list = JsonConvert.DeserializeObject<List<modelT>>(content);
                response.GetType().GetProperty("Result").SetValue(response, list);
                return response;
            });
            onCompleted(asyncResult);
        }

        /// <summary>
        /// Helper method for setting localization information.
        /// </summary>        
        public void SetLocal(string localName)
        {
            this._local = localName;
        }
    }
}