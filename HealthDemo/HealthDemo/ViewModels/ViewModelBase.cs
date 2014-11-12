using HealthDemo.Models;
using HealthDemo.Service;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {                      
        }        

        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); 
            }
        }        

        public void RaisePropertyChanged(object owner, string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(owner, new PropertyChangedEventArgs(propertyName));
            }
        }       
        #endregion        

        private bool _isloading;
        public bool IsLoading
        {
            get { return _isloading; }
            set
            {
                _isloading = value;
                this.RaisePropertyChanged("IsLoading");
            }
        }

        private IWebService _service;
        public IWebService WebService
        {
            get 
            {
                if (_service == null)
                    _service = DependencyService.Get<IWebService>();
                return _service; 
            }
        }

        public Func<string, string, string, Task> ShowAlert;
        public async void ShowError(string errorMessage)
        {
            await ShowAlert("Error", errorMessage, "OK");
        }

        
    }

    public static class ObservableBaseEx
    {
        //override 1
        public static void RaisePropertyChanged<T, TProperty>(this T observableBase, Expression<Func<T, TProperty>> expression) where T : ViewModelBase
        {
            observableBase.RaisePropertyChanged(observableBase.GetPropertyName(expression));
        }

        public static string GetPropertyName<T, TProperty>(this T owner, Expression<Func<T, TProperty>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                var unaryExpression = expression.Body as UnaryExpression;
                if (unaryExpression != null)
                {
                    memberExpression = unaryExpression.Operand as MemberExpression;
                    if (memberExpression == null)
                        throw new NotImplementedException();
                }
                else
                    throw new NotImplementedException();
            }

            var propertyName = memberExpression.Member.Name;
            return propertyName;
        }
    }

  
}
