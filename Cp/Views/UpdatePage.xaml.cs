using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using Cp.Services;
using Cp.Viewmodel;
using Cp.Views;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamvvm;

namespace Cp
{
    public partial class UpdatePage : ContentPage,IBasePage<UpdatePageModel>
    {
        public UpdatePage()
        {
            InitializeComponent();  
        }
        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var name = CountryPicker2.Items[CountryPicker2.SelectedIndex];

            if (name == "Philippines")
            {
                mnumber.Text = "+63";
            }
            else if (name == "South Korea")
            {
                mnumber.Text = "+82";
            }
            else if (name == "Afghanistan")
            {
                mnumber.Text = "+93";
            }
            else if (name == "Albania")
            {
                mnumber.Text = "+355";
            }
            else if (name == "Algeria")
            {
                mnumber.Text = "+213";
            }
            else if (name == "American Samoa")
            {
                mnumber.Text = "+1-684";
            }
            else if (name == "Andorra")
            {
                mnumber.Text = "+376";
            }
            else if (name == "Angola")
            {
                mnumber.Text = "+244";
            }
            else if (name == "Anguilla")
            {
                mnumber.Text = "+1-264";
            }
            else if (name == "Antarctica")
            {
                mnumber.Text = "+672";
            }
            else if (name == "Antigua and Barbuda")
            {
                mnumber.Text = "+1-268";
            }
            else if (name == "Argentina")
            {
                mnumber.Text = "+54";
            }
            else if (name == "Armenia")
            {
                mnumber.Text = "+374";
            }
            else if (name == "Aruba")
            {
                mnumber.Text = "+297";
            }
            else if (name == "Australia")
            {
                mnumber.Text = "+61";
            }
            else if (name == "Austria")
            {
                mnumber.Text = "+43";
            }
            else if (name == "Azerbaijan")
            {
                mnumber.Text = "+994";
            }
            else if (name == "Bahamas")
            {
                mnumber.Text = "+1-246";
            }
            else if (name == "Bahrain")
            {
                mnumber.Text = "+973";
            }
            else if (name == "Bangladesh")
            {
                mnumber.Text = "+880";
            }
            else if (name == "Barbados")
            {
                mnumber.Text = "+1-246";
            }
            else if (name == "Belarus")
            {
                mnumber.Text = "+375";
            }
            else if (name == "Belgium")
            {
                mnumber.Text = "+32";
            }
            else if (name == "Belize")
            {
                mnumber.Text = "+501";
            }
            else if (name == "Benin")
            {
                mnumber.Text = "+229";
            }
            else if (name == "Bermuda")
            {
                mnumber.Text = "+1-441";
            }
            else if (name == "Bhutan")
            {
                mnumber.Text = "+975";
            }
            else if (name == "Bolivia")
            {
                mnumber.Text = "+591";
            }
            else if (name == "Bosnia and Herzegovina")
            {
                mnumber.Text = "+378";
            }
            else if (name == "Botswana")
            {
                mnumber.Text = "+267";
            }
            else if (name == "Brazil")
            {
                mnumber.Text = "+55";
            }
            else if (name == "British Indian Ocean Territory")
            {
                mnumber.Text = "+1-284";
            }
            else if (name == "British Virgin Islands")
            {
                mnumber.Text = "+246";
            }
            else if (name == "Brunei")
            {
                mnumber.Text = "+359";
            }
            else if (name == "Bulgaria")
            {
                mnumber.Text = "+82";
            }
            else if (name == "Burkina Faso")
            {
                mnumber.Text = "+226";
            }
            else if (name == "Burundi")
            {
                mnumber.Text = "+257";
            }
            else if (name == "Cambodia")
            {
                mnumber.Text = "+855";
            }
            else if (name == "Burundi")
            {
                mnumber.Text = "+257";
            }
            else if (name == "Cameroon")
            {
                mnumber.Text = "+237";
            }
            else if (name == "Canada")
            {
                mnumber.Text = "+1";
            }
            else if (name == "Cape Verde")
            {
                mnumber.Text = "+238";
            }
            else if (name == "Cayman Islands")
            {
                mnumber.Text = "+1-345";
            }
            else if (name == "Central African Republic")
            {
                mnumber.Text = "+236";
            }
            else if (name == "Chad")
            {
                mnumber.Text = "+235";
            }
            else if (name == "Chile")
            {
                mnumber.Text = "+56";
            }
            else if (name == "China")
            {
                mnumber.Text = "+86";
            }
            else if (name == "Christmas Island")
            {
                mnumber.Text = "+61";
            }
            else if (name == "Cocos Islands")
            {
                mnumber.Text = "+61";
            }
            else if (name == "Colombia")
            {
                mnumber.Text = "+57";
            }
            else if (name == "Comoros")
            {
                mnumber.Text = "+269";
            }
            else if (name == "Cook Islands")
            {
                mnumber.Text = "+682";
            }
            else if (name == "Costa Rica")
            {
                mnumber.Text = "+506";
            }
            else if (name == "Croatia")
            {
                mnumber.Text = "+385";
            }
            else if (name == "Cuba")
            {
                mnumber.Text = "+53";
            }
            else if (name == "Curacao")
            {
                mnumber.Text = "+599";
            }
            else if (name == "Cyprus")
            {
                mnumber.Text = "+357";
            }
            else if (name == "Czech Republic")
            {
                mnumber.Text = "+420";
            }
            else if (name == "Democratic Republic of the Congo")
            {
                mnumber.Text = "+243";
            }
            else if (name == "Denmark")
            {
                mnumber.Text = "+45";
            }
            else if (name == "Djibouti")
            {
                mnumber.Text = "+253";
            }
            else if (name == "Dominica")
            {
                mnumber.Text = "+1-767";
            }
            else if (name == "Dominican Republic")
            {
                mnumber.Text = "+1-806, +1-829, +1-849";
            }
            else if (name == "East Timor")
            {
                mnumber.Text = "+670";
            }
            else if (name == "Ecuador")
            {
                mnumber.Text = "+593";
            }
            else if (name == "Egypt")
            {
                mnumber.Text = "+20";
            }
            else if (name == "El Salvador")
            {
                mnumber.Text = "+503";
            }
            else if (name == "Equatorial Guinea")
            {
                mnumber.Text = "+240";
            }
            else if (name == "Eritrea")
            {
                mnumber.Text = "+291";
            }
            else if (name == "Estonia")
            {
                mnumber.Text = "+372";
            }
            else if (name == "Ethiopia")
            {
                mnumber.Text = "+251";
            }
            else if (name == "Falkland Islands")
            {
                mnumber.Text = "+500";
            }
            else if (name == "Faroe Islands")
            {
                mnumber.Text = "+298";
            }
            else if (name == "Fiji")
            {
                mnumber.Text = "+679";
            }
            else if (name == "Finland")
            {
                mnumber.Text = "+358";
            }
            else if (name == "French Polynesia")
            {
                mnumber.Text = "+689";
            }
            else if (name == "Gabon")
            {
                mnumber.Text = "+241";
            }
            else if (name == "Gambia")
            {
                mnumber.Text = "+220";
            }
            else if (name == "Georgia")
            {
                mnumber.Text = "+995";
            }
            else if (name == "Germany")
            {
                mnumber.Text = "+49";
            }
            else if (name == "Ghana")
            {
                mnumber.Text = "+233";
            }
            else if (name == "Gibraltar")
            {
                mnumber.Text = "+350";
            }
            else if (name == "Greece")
            {
                mnumber.Text = "+30";
            }
            else if (name == "Greenland")
            {
                mnumber.Text = "+299";
            }
            else if (name == "Grenada")
            {
                mnumber.Text = "+1-473";
            }
            else if (name == "Guam")
            {
                mnumber.Text = "+1-671";
            }
            else if (name == "Guatemala")
            {
                mnumber.Text = "+502";
            }
            else if (name == "Guernsey")
            {
                mnumber.Text = "+44-1481";
            }
            else if (name == "Guinea")
            {
                mnumber.Text = "+224";
            }
            else if (name == "Guinea-Bissau")
            {
                mnumber.Text = "+245";
            }
            else if (name == "Guyana")
            {
                mnumber.Text = "+592";
            }
            else if (name == "Haiti")
            {
                mnumber.Text = "+509";
            }
            else if (name == "Honduras")
            {
                mnumber.Text = "+504";
            }
            else if (name == "Hong Kong")
            {
                mnumber.Text = "+852";
            }
            else if (name == "Hungary")
            {
                mnumber.Text = "+36";
            }
            else if (name == "Iceland")
            {
                mnumber.Text = "+354";
            }
            else if (name == "India")
            {
                mnumber.Text = "+91";
            }
            else if (name == "Indonesia")
            {
                mnumber.Text = "+62";
            }
            else if (name == "Iran")
            {
                mnumber.Text = "+98";
            }
            else if (name == "Iraq")
            {
                mnumber.Text = "+964";
            }
            else if (name == "Ireland")
            {
                mnumber.Text = "+353";
            }
            else if (name == "Isle of Man")
            {
                mnumber.Text = "+44-1624";
            }
            else if (name == "Israel")
            {
                mnumber.Text = "+972";
            }
            else if (name == "Italy")
            {
                mnumber.Text = "+39";
            }
            else if (name == "Ivory Coast")
            {
                mnumber.Text = "+225";
            }
            else if (name == "Jamaica")
            {
                mnumber.Text = "+1-876";
            }
            else if (name == "Japan")
            {
                mnumber.Text = "+81";
            }
            else if (name == "Jersey")
            {
                mnumber.Text = "+44-1534";
            }
            else if (name == "Jordan")
            {
                mnumber.Text = "+962";
            }
            else if (name == "Kazakhstan")
            {
                mnumber.Text = "+7";
            }
            else if (name == "Kenya")
            {
                mnumber.Text = "+254";
            }
            else if (name == "Kiribati")
            {
                mnumber.Text = "+686";
            }
            else if (name == "Kosovo")
            {
                mnumber.Text = "+383";
            }
            else if (name == "Kuwait")
            {
                mnumber.Text = "+965";
            }
            else if (name == "Kyrgyzstan")
            {
                mnumber.Text = "+996";
            }
            else if (name == "Laos")
            {
                mnumber.Text = "+856";
            }
            else if (name == "Latvia")
            {
                mnumber.Text = "+371";
            }
            else if (name == "Lebanon")
            {
                mnumber.Text = "+961";
            }
            else if (name == "Lesotho")
            {
                mnumber.Text = "+266";
            }
            else if (name == "Liberia")
            {
                mnumber.Text = "+231";
            }
            else if (name == "Libya")
            {
                mnumber.Text = "+218";
            }
            else if (name == "Liechtenstein")
            {
                mnumber.Text = "+423";
            }
            else if (name == "Lithuania")
            {
                mnumber.Text = "+370";
            }
            else if (name == "Luxembourg")
            {
                mnumber.Text = "+352";
            }
            else if (name == "Macau")
            {
                mnumber.Text = "+853";
            }
            else if (name == "Macedonia")
            {
                mnumber.Text = "+389";
            }
            else if (name == "Madagascar")
            {
                mnumber.Text = "+261";
            }
            else if (name == "Malawi")
            {
                mnumber.Text = "+265";
            }
            else if (name == "Malaysia")
            {
                mnumber.Text = "+60";
            }
            else if (name == "Maldives")
            {
                mnumber.Text = "+960";
            }
            else if (name == "Mali")
            {
                mnumber.Text = "+223";
            }
            else if (name == "Malta")
            {
                mnumber.Text = "+356";
            }
            else if (name == "Marshall Islands  ")
            {
                mnumber.Text = "+692";
            }
            else if (name == "Mauritania")
            {
                mnumber.Text = "+222";
            }
            else if (name == "Mauritius")
            {
                mnumber.Text = "+230";
            }
            else if (name == "Mayotte")
            {
                mnumber.Text = "+262";
            }
            else if (name == "Mexico")
            {
                mnumber.Text = "+52";
            }
            else if (name == "Micronesia")
            {
                mnumber.Text = "+691";
            }
            else if (name == "Moldova")
            {
                mnumber.Text = "+373";
            }
            else if (name == "Monaco")
            {
                mnumber.Text = "+377";
            }
            else if (name == "Monaco")
            {
                mnumber.Text = "+377";
            }
            else if (name == "Mongolia")
            {
                mnumber.Text = "+976";
            }
            else if (name == "Montenegro")
            {
                mnumber.Text = "+382";
            }
            else if (name == "Montserrat")
            {
                mnumber.Text = "+1-664";
            }
            else if (name == "Morocco")
            {
                mnumber.Text = "+212";
            }
            else if (name == "Mozambique")
            {
                mnumber.Text = "+258";
            }
            else if (name == "Myanmar")
            {
                mnumber.Text = "+95";
            }
            else if (name == "Namibia")
            {
                mnumber.Text = "+264";
            }
            else if (name == "Nauru")
            {
                mnumber.Text = "+674";
            }
            else if (name == "Nepal")
            {
                mnumber.Text = "+977";
            }
            else if (name == "Netherlands")
            {
                mnumber.Text = "+31";
            }
            else if (name == "Netherlands Antilles")
            {
                mnumber.Text = "+599";
            }
            else if (name == "New Caledonia")
            {
                mnumber.Text = "+687";
            }
            else if (name == "New Zealand")
            {
                mnumber.Text = "+64";
            }
            else if (name == "Nicaragua")
            {
                mnumber.Text = "+505";
            }
            else if (name == "Niger")
            {
                mnumber.Text = "+234";
            }
            else if (name == "Niue")
            {
                mnumber.Text = "+683";
            }
            else if (name == "North Korea")
            {
                mnumber.Text = "+850";
            }
            else if (name == "Northern Mariana Islands")
            {
                mnumber.Text = "+1-670";
            }
            else if (name == "Norway")
            {
                mnumber.Text = "+47";
            }
            else if (name == "Oman")
            {
                mnumber.Text = "+968";
            }
            else if (name == "Pakistan")
            {
                mnumber.Text = "+92";
            }
            else if (name == "Palau")
            {
                mnumber.Text = "+680";
            }
            else if (name == "Palestine")
            {
                mnumber.Text = "+970";
            }
            else if (name == "Panama")
            {
                mnumber.Text = "+507";
            }
            else if (name == "Papua New Guinea")
            {
                mnumber.Text = "+675";
            }
            else if (name == "Paraguay")
            {
                mnumber.Text = "+565";
            }
            else if (name == "Peru")
            {
                mnumber.Text = "+51";
            }
            else if (name == "Pitcairn")
            {
                mnumber.Text = "+64";
            }
            else if (name == "Poland")
            {
                mnumber.Text = "+48";
            }
            else if (name == "Portugal")
            {
                mnumber.Text = "+351";
            }
            else if (name == "Puerto Rico")
            {
                mnumber.Text = "+1-787, +1-939";
            }
            else if (name == "Qatar")
            {
                mnumber.Text = "+974";
            }
            else if (name == "Republic of the Congo")
            {
                mnumber.Text = "+242";
            }
            else if (name == "Reunion")
            {
                mnumber.Text = "+262";
            }
            else if (name == "Romania")
            {
                mnumber.Text = "+40";
            }
            else if (name == "Russia")
            {
                mnumber.Text = "+7";
            }
            else if (name == "Rwanda")
            {
                mnumber.Text = "+250";
            }
            else if (name == "Saint Barthelemy")
            {
                mnumber.Text = "+590";
            }
            else if (name == "Saint Helena")
            {
                mnumber.Text = "+290";
            }
            else if (name == "Saint Kitts and Nevis")
            {
                mnumber.Text = "+1-869";
            }
            else if (name == "Saint Lucia")
            {
                mnumber.Text = "+1-758";
            }
            else if (name == "Saint Martin")
            {
                mnumber.Text = "+590";
            }
            else if (name == "Saint Pierre and Miquelon")
            {
                mnumber.Text = "+508";
            }
            else if (name == "Saint Vincent and the Grenadines")
            {
                mnumber.Text = "+1-784";
            }
            else if (name == "Samoa")
            {
                mnumber.Text = "+685";
            }
            else if (name == "San Marino")
            {
                mnumber.Text = "+378";
            }
            else if (name == "Sao Tome and Principe")
            {
                mnumber.Text = "+239";
            }
            else if (name == "Saudi Arabia")
            {
                mnumber.Text = "+966";
            }
            else if (name == "Senegal")
            {
                mnumber.Text = "+221";
            }
            else if (name == "Serbia")
            {
                mnumber.Text = "+381";
            }
            else if (name == "Seychelles")
            {
                mnumber.Text = "+248";
            }
            else if (name == "Sierra Leone")
            {
                mnumber.Text = "+232";
            }
            else if (name == "Singapore")
            {
                mnumber.Text = "+65";
            }
            else if (name == "Sint Maarten")
            {
                mnumber.Text = "+1-721";
            }
            else if (name == "Slovakia")
            {
                mnumber.Text = "+421";
            }
            else if (name == "Slovenia")
            {
                mnumber.Text = "+386";
            }
            else if (name == "Solomon Islands")
            {
                mnumber.Text = "+677";
            }
            else if (name == "Somalia")
            {
                mnumber.Text = "+252";
            }
            else if (name == "South Africa")
            {
                mnumber.Text = "+27";
            }
            else if (name == "South Sudan")
            {
                mnumber.Text = "+211";
            }
            else if (name == "Spain")
            {
                mnumber.Text = "+34";
            }
            else if (name == "Sri Lanka")
            {
                mnumber.Text = "+94";
            }
            else if (name == "Sudan")
            {
                mnumber.Text = "+249";
            }
            else if (name == "Suriname")
            {
                mnumber.Text = "+597";
            }
            else if (name == "Svalbard and Jan Mayen")
            {
                mnumber.Text = "+47";
            }
            else if (name == "Swaziland")
            {
                mnumber.Text = "+268";
            }
            else if (name == "Sweden")
            {
                mnumber.Text = "+46";
            }
            else if (name == "Switzerland")
            {
                mnumber.Text = "+41";
            }
            else if (name == "Syria")
            {
                mnumber.Text = "+963";
            }
            else if (name == "Taiwan")
            {
                mnumber.Text = "+886";
            }
            else if (name == "Tajikistan")
            {
                mnumber.Text = "+992";
            }
            else if (name == "Tanzania")
            {
                mnumber.Text = "+255";
            }
            else if (name == "Thailand")
            {
                mnumber.Text = "+66";
            }
            else if (name == "Togo")
            {
                mnumber.Text = "+228";
            }
            else if (name == "Tokelau")
            {
                mnumber.Text = "+690";
            }
            else if (name == "Tonga")
            {
                mnumber.Text = "+676";
            }
            else if (name == "Trinidad and Tobago")
            {
                mnumber.Text = "+1-868";

            }
            else if (name == "Tunisia")
            {
                mnumber.Text = "+216";
            }
            else if (name == "Turkey")
            {
                mnumber.Text = "+90";
            }
            else if (name == "Turkmenistan")
            {
                mnumber.Text = "+993";
            }
            else if (name == "Turks and Caicos Islands")
            {
                mnumber.Text = "+1-649";
            }
            else if (name == "Tuvalu")
            {
                mnumber.Text = "+688";
            }
            else if (name == "U.S. Virgin Islands")
            {
                mnumber.Text = "+1-340";
            }
            else if (name == "U.S. Virgin Islands")
            {
                mnumber.Text = "+1-340";
            }
            else if (name == "Uganda")
            {
                mnumber.Text = "+256";
            }
            else if (name == "Ukraine")
            {
                mnumber.Text = "+380";
            }
            else if (name == "United Arab Emirates")
            {
                mnumber.Text = "+971";
            }
            else if (name == "United Kingdom")
            {
                mnumber.Text = "+44";
            }
            else if (name == "United States")
            {
                mnumber.Text = "+1";
            }
            else if (name == "Uruguay")
            {
                mnumber.Text = "+598";
            }
            else if (name == "Uzbekistan")
            {
                mnumber.Text = "+998";
            }
            else if (name == "Vanuatu")
            {
                mnumber.Text = "+678";
            }
            else if (name == "Vatican")
            {
                mnumber.Text = "+379";
            }
            else if (name == "Venezuela")
            {
                mnumber.Text = "+58";
            }
            else if (name == "Vietnam")
            {
                mnumber.Text = "+84";
            }
            else if (name == "Wallis and Futuna")
            {
                mnumber.Text = "+681";
            }
            else if (name == "Western Sahara")
            {
                mnumber.Text = "+212";
            }
            else if (name == "Yemen")
            {
                mnumber.Text = "+967";
            }
            else if (name == "Zambia")
            {
                mnumber.Text = "+260";
            }
            else if (name == "Zimbabwe")
            {
                mnumber.Text = "+263";
            }




        }

        public async void Updatebtn(object sender, EventArgs e)
        {

            ApiServices _apiServices = new ApiServices();
            bool update_result = await _apiServices.ProfileUpdateAsync(
                Eemail.Text,
                Epassword.Text,
                Ename.Text,
                mnumber.Text
                );
            if (update_result)
            {
                //Helpers.Utils.Msgbox(cont);

                await DisplayAlert("Result", "Update Successful", "OK");
                //await Navigation.PushModalAsync(new Login());
            }
            else
            {
                await DisplayAlert("Result", "Sorry. an error occurred. Please try again later.", "OK");
            }


        }
        void lblclickFucn()
        {
            lblclick.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new Login());
                }
                )
            });
        }
    }
}
