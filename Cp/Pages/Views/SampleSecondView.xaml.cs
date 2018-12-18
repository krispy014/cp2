using Xamarin.Forms;
using Xamvvm;

namespace Cp
{
    public partial class SampleSecondView : ContentView, IBaseView<SampleSecondViewModel>
    {
        public SampleSecondView()
        {
            InitializeComponent();
        }
    }
}
