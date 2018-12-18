using System;

using Xamarin.Forms;

namespace Cp.Model
{
    public class MasterMenuItem 
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string IconSource { get; set; }
       
        public Type TargetType { get; set; }
        
        public MasterMenuItem(string Title,string IconSource,string Id,Type TargetType)
        {
            this.Id = Id;
            this.Title = Title;
            this.IconSource = IconSource;
            
            this.TargetType = TargetType;
        }

    }
}

