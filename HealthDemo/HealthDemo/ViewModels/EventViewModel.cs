using HealthDemo.Models;
using HealthDemo.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.ViewModels
{
    public class EventViewModel : ViewModelBase
    {
        public EventViewModel()
        {
            EventsList = new List<Event>();
        }

        public Event SelectedEvent { get; set; }
        public List<Event> EventsList { get; set; }
        private bool IsPrevCME { get; set; }
        public void LoadEvents(int cmeID = 0)
        {
            if (!IsPrevCME && cmeID == 0 && EventsList.Count > 0)
                return;
            IsLoading = true;
            var query = cmeID == 0 ? "event" : "event/GetByCME?cmeId=" + cmeID.ToString();
            WebService.GetList<EventResponse, Event>(query, result =>
            {
                if (result.Success)
                {
                    IsPrevCME = cmeID != 0;
                    EventsList = result.Result;
                    RaisePropertyChanged("EventsList");
                }
                else
                {
                    ShowError(result.ErrorMessage);
                }
                IsLoading = false;
            });
        }
    }
}
