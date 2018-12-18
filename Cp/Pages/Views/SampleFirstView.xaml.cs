using Xamarin.Forms;
using Xamvvm;

namespace Cp
{
    public partial class SampleFirstView : ContentView, IBaseView<SampleFirstViewModel>
    {
        public SampleFirstView()
        {
            InitializeComponent();
        }
    }
}
