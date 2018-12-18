using System;
using Xamvvm;
using System.Windows.Input;
using Cp.Views;

namespace Cp
{
    public class SampleNavigationViewPageModel : BasePageModel
    {
        readonly IViewNavigation<SampleNavigationViewNavigationModel> _nav;

        public SampleNavigationViewPageModel(IViewNavigation<SampleNavigationViewNavigationModel> nav)
        {
            _nav = nav;

            NavigateFirstCommand = new BaseCommand(async (arg) =>
            {
                await _nav.SetMainViewAsync<SampleFirstViewModel>();
            });

            NavigateSecondCommand = new BaseCommand(async (arg) =>
            {
                await _nav.SetMainViewAsync<SampleSecondViewModel>();
            });
        }
        //public async void showViewPageAsync(int page_id)
        //{
           
        //    {
        //        //Glo.Data.Page_ID = item.Page_Id;
        //        //Detail = new NavigationPage(obj);

        //        //var masterDetailPage = this.GetPageFromCache<MasterDetailPageModel>();

        //        //Page p = null;
        //        //p = this.GetPageFromCache<HomePageModel>() as Page;



        //        //var page;
        //        if (page_id == Constants.PAGEID_HOME)
        //        {
        //            await _nav.SetMainViewAsync<SendPageModel>();
        //        }
        //        else if (page_id == Constants.PAGEID_SEND)
        //        {
        //            await _nav.SetMainViewAsync<SendPageModel>();
        //        }
        //        else if (page_id == Constants.PAGEID_RECV)
        //        {
        //            await _nav.SetMainViewAsync<SendPageModel>();
        //        }
        //        else if (page_id == Constants.PAGEID_TRADE)
        //        {
        //            await _nav.SetMainViewAsync<SendPageModel>();
        //        }
        //        else if (page_id == Constants.PAGEID_WALLET)
        //        {
        //            await _nav.SetMainViewAsync<SendPageModel>();
        //        }
        //        else if (page_id == Constants.PAGEID_SETTING)
        //        {
        //            await _nav.SetMainViewAsync<SampleFirstViewModel>();
        //        }
        //        else if (page_id == Constants.PAGEID_BUYNSELL)
        //        {
        //            await _nav.SetMainViewAsync<SampleFirstViewModel>();
                     
        //        }


        //    }
        //}

        public ICommand NavigateFirstCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        public ICommand NavigateSecondCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }
    }
}
