using System;
using Cp.Helpers;
using Cp.Views;
using Xamarin.Forms;
using Xamvvm;

namespace Cp
{
    public class MasterDetailPage : Xamarin.Forms.MasterDetailPage, IBasePage<MasterDetailPageModel>
    {
        public MasterDetailPage()
        {

            NavigationPage.SetHasNavigationBar(this, false); // remove actionbar from masterdetail

            // create & set menu
            Page p_master=this.GetPageFromCache<MasterDetailMenuPageModel>() as Page;
            //Glo.Data.MasterDetailPageObj = this;
            Master = p_master;

            // create detail
            Page p_detail = this.GetPageFromCache<HomePageModel>() as Page;
            NavigationPage.SetHasNavigationBar(p_detail, false); // it works
            //ToolbarItems.RemoveAt(0);

            // set detail
            Detail = new NavigationPage(p_detail);
            //ToolbarItems.RemoveAt(0);
        }

        public async void SetDetail(Page p)
        {
            Console.WriteLine("MasterDetailPage->SetDetail()");

            //var masterDetailPage = (this).GetCurrentPage() as Xamarin.Forms.MasterDetailPage;
            NavigationPage.SetHasNavigationBar(p, false);
            //Detail = new NavigationPage(p)
            //{
            //    Title = ""
            //};

            /* HOW TO AVOID FLICKERING ?
             Based on a hunch, creating the new NavigationPage firstly removes the current Navigation and replaces it and must show whatever is in the background, in this case the splash screen. This creates the flicker effect.
             Here is what I've done to correct this:
             */

            //System.ArgumentException: Cannot insert page which is already in the navigation stack
            try
            {
                /*
                var _navigation = Application.Current.MainPage.Navigation;
                var _stack_cnt = _navigation.NavigationStack.Count;
                if (_stack_cnt > 0)
                {
                    var _lastPage = _navigation.NavigationStack[_stack_cnt - 1];
                    //Remove last page
                    _navigation.RemovePage(_lastPage);
                }
                //Go back 
                //_navigation.PopAsync();
                */

                //// remove last page
                var _navigation = Detail.Navigation;
                var _stack_cnt = Detail.Navigation.NavigationStack.Count;
                if (_stack_cnt > 1)
                {
                    var _lastPage = Detail.Navigation.NavigationStack[_stack_cnt - 1];
                    //Remove last page
                    _navigation.RemovePage(_lastPage);
                }

                // add new & set root
                var root = Detail.Navigation.NavigationStack[0];
                //Detail.Navigation.InsertPageBefore((Page)Activator.CreateInstance(p.GetType()), root);

                try
                {
                    Detail.Navigation.InsertPageBefore(p, root);
                }
                catch (System.ArgumentException e)
                {
                    // Cannot insert page which is already in the navigation stack)
                    Detail.Navigation.RemovePage(p);
                    Detail.Navigation.InsertPageBefore(p, root);
                }
                await Detail.Navigation.PopToRootAsync(false);
                IsPresented = false;

                Glo.Data.showpage_running = false;

            }
            catch (Exception e) {
                Console.WriteLine("MasterDetailPage->SetDetail: Exception=" + e.ToString());

            }
            //
            //MasterPage.ListView.SelectedItem = null;



            //Detail = p;

            /*
             * MasterDetailPage Navigation
             * 
            All pushing and popping is always done from the PageModel and not from Pages

            var pageToPush = this.GetPageFromCache<DetailPageModel>();
            await this.PushPageAsync(pageToPush);

            // OR even shorter way:
            this.PushPageFromCache<DetailPageModel>();
            You can pass an int action too that is executed on the Pagemodel before displaying the page

            await this.PushPageAsync(pageToPush, (pm) => pm.Init("blue", Color.Blue));

            // OR even shorter way:
            var pageToPush = this.GetPageFromCache<DetailPageModel>();
            this.PushPageFromCache<DetailPageModel>((pm) => pm.Init("blue", Color.Blue));
            Popping is as easy

            await this.PopPageAsync();
            */

            // popup new page
            //var pageToPush = this.GetPageFromCache<TradePageModel>();
            //await this.PushPageAsync(p);


            //IsPresented = false;

            Glo.Data.showpage_running = false;

        }


        public void drawer_open()
        {
            IsPresented = true;
        }

        public void drawer_close()
        {
            IsPresented = false;
        }

        public void drawer_toggle()
        {
            IsPresented = IsPresented?false:true;
        }

        protected override bool OnBackButtonPressed()
        {
            // preventing error
            if (!Glo.Data.showpage_running)
            {
                if (Glo.Data.Page_ID != Constants.PAGEID_HOME)
                {
                    Glo.Data.openPage(Constants.PAGEID_HOME);
                }
                else
                {
                    //if (!Constants.IS_LIVEPLAYER)
                    //{
                    //    if (Device.OS == TargetPlatform.Android)
                    //    {
                    //        DependencyService.Get<IAndroidMethods>().CloseApp();
                    //    }
                    //    else
                    //    {
                    //        //return base.OnBackButtonPressed();
                    //    }
                    //}
                    //else
                    //{

                    if (Glo.Data.last_back_pressed != null && Glo.Data.last_back_pressed + Constants.DOUBLEBACK_EXIT_SEC > Utils.time())
                    {
                        return base.OnBackButtonPressed();
                    }
                    else
                    {
                        Glo.Data.last_back_pressed = Utils.time();
                        Helpers.Utils.Msgbox("press one more time if you want to exit the application.");
                    }

                }
            }

            return true;
        }
    }
}

