using HealthDemo.Models;
using HealthDemo.Service.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.ViewModels
{
    public class DoctorViewModel : ViewModelBase
    {
        public DoctorViewModel()
        {
            DoctorList = new List<Doctor>();
            SpeicaltyList = new List<DocPosition>();
        }
        public DocPosition SelectedSpeicalties { get; set; }
        public string SearchText { get; set; }
        
        

        public List<Doctor> DoctorList { get; set; }
        public List<DocPosition> SpeicaltyList { get; set; }
        
        private Doctor _doctor;
        public Doctor SelectedDoctor
        {
            get { return _doctor; }
            set 
            { 
                _doctor = value;
                RaisePropertyChanged("SelectedDoctor");
            }
        }



        public void DoSearch(Action onComplete)
        {
            IsLoading = true;
            WebService.SearchDoctors(new SearchDoctorRequest()
                {
                    Title = SearchText,
                    PositionId = SelectedSpeicalties!=null ? SelectedSpeicalties.ID : 0
                }, result =>
                {
                    if (result.Success)
                    {
                        DoctorList.Clear();
                        DoctorList = result.Result;
                        RaisePropertyChanged("DoctorList");
                    }
                    else
                    {
                        ShowError(result.ErrorMessage);
                    }
                    IsLoading = false;
                    onComplete();
                });
        }

        public void LoadSpeicalties(Action onComplete)
        {
			if (SpeicaltyList.Count == 0 || SpeicaltyList.Count == 1)
            {
                IsLoading = true;
                WebService.GetSpeicalties(result =>
                    {   
                        if (result.Success)
                        {
                            SpeicaltyList = result.Result;
                            RaisePropertyChanged("SpeicaltyList");
                        }
                        else
                        {
                            ShowError(result.ErrorMessage);
                        }
                        if (!SpeicaltyList.Any(s => s.ID == 0))
                            SpeicaltyList.Insert(0, new DocPosition() { ID = 0, Title = "All" });
                        IsLoading = false;
                        onComplete();
					});
			}
			else onComplete();
		}
	}
}
       