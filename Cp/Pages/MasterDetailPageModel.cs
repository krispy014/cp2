using System;
using Xamvvm;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.ComponentModel;

namespace Cp
{
    public class MasterDetailPageModel : BasePageModel
    {
        public MasterDetailPageModel()
        {

            //Glo.Data.MasterDetailModelObj = this;

        }

        

        //public void SetDetail<TPageModel>(IBasePage<TPageModel> page) where TPageModel: class, IBasePageModel
        //{
        //    var masterDetailPage = (this).GetCurrentPage() as Xamarin.Forms.MasterDetailPage;
        //    masterDetailPage.Detail = new NavigationPage(page as Page);
        //    masterDetailPage.IsPresented = false;
        //}



    }
}
