using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthDemo.Service;
using HealthDemo.Models;
using HealthDemo;
using HealthDemo.Service.RequestModel;
using HealthDemo.Models.ResponseModel;


//[assembly: Xamarin.Forms.Dependency(typeof(MockWebService))]
using System.Threading.Tasks;


namespace HealthDemo
{
    public class MockWebService : IWebService
    {
        public void SearchDoctors(SearchDoctorRequest request, Action<DoctorResponse> onCompleted)
        {
            onCompleted(new DoctorResponse()
            {
                Success = true,
                Result = new List<Doctor>()
                             {
                                new Doctor(){Title = "Doctor1", ID = 1, Department = "dep1", QualifiList = new List<string>(){ "asfsdf, sdfds"}, Bio = "asdf sdaf sda fsda fasd fasdf asdf adgdf sdf gsdfg sdfg sdf gsdf gsdfg sdf gsdfgsdfgdsgsd gsdf gsdf", Position="sfasdfa fsdafd fds"},
                                new Doctor(){Title = "Doctor2", ID = 2, Department = "dep2", QualifiList = new List<string>(){ "asfsdf, sdfds"}, Bio = "asdf sdaf sda fsda fasd fasdf asdf adgdf sdf gsdfg sdfg sdf gsdf gsdfg sdf gsdfgsdfgdsgsd gsdf gsdf", Position="sfasdfa fsdafd fds"},
                                new Doctor(){Title = "Doctor3", ID = 3, Department = "dep3", QualifiList = new List<string>(){ "asfsdf, sdfds"}, Bio = "asdf sdaf sda fsda fasd fasdf asdf adgdf sdf gsdfg sdfg sdf gsdf gsdfg sdf gsdfgsdfgdsgsd gsdf gsdf", Position="sfasdfa fsdafd fds"},
                                new Doctor(){Title = "Doctor4", ID = 4, Department = "dep4", QualifiList = new List<string>(){ "asfsdf, sdfds"}, Bio = "asdf sdaf sda fsda fasd fasdf asdf adgdf sdf gsdfg sdfg sdf gsdf gsdfg sdf gsdfgsdfgdsgsd gsdf gsdf", Position="sfasdfa fsdafd fds"},
                                new Doctor(){Title = "Doctor5", ID = 5, Department = "dep5", QualifiList = new List<string>(){ "asfsdf, sdfds"}, Bio = "asdf sdaf sda fsda fasd fasdf asdf adgdf sdf gsdfg sdfg sdf gsdf gsdfg sdf gsdfgsdfgdsgsd gsdf gsdf", Position="sfasdfa fsdafd fds"},
                                new Doctor(){Title = "Doctor6", ID = 6, Department = "dep6", QualifiList = new List<string>(){ "asfsdf, sdfds"}, Bio = "asdf sdaf sda fsda fasd fasdf asdf adgdf sdf gsdfg sdfg sdf gsdf gsdfg sdf gsdfgsdfgdsgsd gsdf gsdf", Position="sfasdfa fsdafd fds"},
                             }
            });
        }

        public void GetCategories(Action<CategoryResponse> onCompleted)
        {
            onCompleted(new CategoryResponse()
                {
                    Success = true,
                    Result = new List<HealthCategory>()
                                    {
                                        new HealthCategory(){ ID = 1, Title = "General"},
                                        new HealthCategory(){ ID = 1, Title = "Food"},
                                        new HealthCategory(){ ID = 1, Title = "Other"}
                                    }
                });
        }

        public void GetHealthTipsByCategory(int categoryID, Action<HealthTipResponse> onCompleted)
        {
            onCompleted(new HealthTipResponse()
                {
                    Success = true,
                    Result = new List<HealthTip>()
                                    {
                                        new HealthTip(){ ID = 1, CategoryID = categoryID, Title = "Health tip1", Description = "dasfsd afsd fdas fdas fdsa fdasgdfsg dfsg sdf gsdf gsdf sdf"},
                                        new HealthTip(){ ID = 1, CategoryID = categoryID, Title = "Health tip2", Description = "dasfsd afsd fdas fdas fdsa fdasgdfsg dfsg sdf gsdf gsdf sdf"},
                                        new HealthTip(){ ID = 1, CategoryID = categoryID, Title = "Health tip3", Description = "dasfsd afsd fdas fdas fdsa fdasgdfsg dfsg sdf gsdf gsdf sdf"},
                                        new HealthTip(){ ID = 1, CategoryID = categoryID, Title = "Health tip4", Description = "dasfsd afsd fdas fdas fdsa fdasgdfsg dfsg sdf gsdf gsdf sdf"},
                                        new HealthTip(){ ID = 1, CategoryID = categoryID, Title = "Health tip5", Description = "dasfsd afsd fdas fdas fdsa fdasgdfsg dfsg sdf gsdf gsdf sdf"},
                                        new HealthTip(){ ID = 1, CategoryID = categoryID, Title = "Health tip6", Description = "dasfsd afsd fdas fdas fdsa fdasgdfsg dfsg sdf gsdf gsdf sdf"},
                                        new HealthTip(){ ID = 1, CategoryID = categoryID, Title = "Health tip7", Description = "dasfsd afsd fdas fdas fdsa fdasgdfsg dfsg sdf gsdf gsdf sdf"},
                                        new HealthTip(){ ID = 1, CategoryID = categoryID, Title = "Health tip8", Description = "dasfsd afsd fdas fdas fdsa fdasgdfsg dfsg sdf gsdf gsdf sdf"},
                                        new HealthTip(){ ID = 1, CategoryID = categoryID, Title = "Health tip9", Description = "dasfsd afsd fdas fdas fdsa fdasgdfsg dfsg sdf gsdf gsdf sdf"},
                                    }
                });
        }

        public void GetSpeicalties(Action<PositionResponse> onCompleted)
        {
            onCompleted(new PositionResponse()
                {
                    Success = true,
                    Result = new List<DocPosition>()
                                    {
                                        new DocPosition(){Title = "Speicalties1", ID = 1},
                                        new DocPosition(){Title = "Speicalties2", ID = 2},
                                        new DocPosition(){Title = "Speicalties3", ID = 3},
                                        new DocPosition(){Title = "Speicalties4", ID = 4},
                                        new DocPosition(){Title = "Speicalties5", ID = 5}
                                    }
                });
        }

        public void GetInsurances(Action<InsuranceResponse> onCompleted)
        {
            onCompleted(new InsuranceResponse()
            {
                Success = true,
                Result = new List<Insurance>()
                                    {
                                        new Insurance(){Title = "Insurance1", ID = 1, Description = "Description1"},
                                        new Insurance(){Title = "Insurance2", ID = 2, Description = "Description2"},
                                        new Insurance(){Title = "Insurance3", ID = 3, Description = "Description3"},
                                        new Insurance(){Title = "Insurance4", ID = 4, Description = "Description4"},
                                        new Insurance(){Title = "Insurance5", ID = 5, Description = "Description5"}
                                    }
            });
        }


        public void GetList<T, modelT>(string uri, Action<T> onCompleted) where T : ResponseBase
        {
            var response = Activator.CreateInstance<T>();
            if (response is FaqResponse)
            {
                var list = new List<Faq>()
                                    {
                                        new Faq(){Title = "Question1", ID = 1, Description = "Answer1"},
                                        new Faq(){Title = "Question2", ID = 1, Description = "Answer2"},
                                        new Faq(){Title = "Question3", ID = 1, Description = "Answer3"},
                                        new Faq(){Title = "Question4", ID = 1, Description = "Answer4"},
                                        new Faq(){Title = "Question5", ID = 1, Description = "Answer5"}
                                    };
                response.GetType().GetProperty("Result").SetValue(response, list);
                response.Success = true;
                onCompleted(response);
            }
            else if(typeof(T) == typeof(NewsResponse))
            {
                var list = new List<News>()
                                    {
                                        new News(){Title = "Al Ain Hospital launches UAE’s first specialised Children’s Rheumatology Clinic", ID = 1, Date = DateTime.Now, Description = "Details1"},
                                        new News(){Title = "Al Ain Hospital launches UAE’s first specialised Children’s Rheumatology Clinic", ID = 2,Date = DateTime.Now, Description = "Details2"},
                                        new News(){Title = "Al Ain Hospital launches UAE’s first specialised Children’s Rheumatology Clinic", ID = 3,Date = DateTime.Now, Description = "Details3"},
                                        new News(){Title = "Al Ain Hospital launches UAE’s first specialised Children’s Rheumatology Clinic", ID = 4,Date = DateTime.Now, Description = "Details4"},
                                        new News(){Title = "Al Ain Hospital launches UAE’s first specialised Children’s Rheumatology Clinic", ID = 5,Date = DateTime.Now, Description = "Details5"}
                                    };
                response.GetType().GetProperty("Result").SetValue(response, list);
                response.Success = true;
                onCompleted(response);
            }
        }

		public async void CreateAppointment(Appointment appoint, Action<ResponseBase> onCompleted)
		{
		}

		public void CreateFile(FileModel file, Action<ResponseBase> onCompleted){}
    }
}