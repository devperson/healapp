using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Models
{
    public class FileModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Thiqa { get; set; }
        public string EmirateID { get; set; }
        public string Path { get; set; }
        public string ImageAsString { get; set; }
        public byte[] ImageBytes { get; set; }
        public string ImageExtension { get; set; }
    }
}
