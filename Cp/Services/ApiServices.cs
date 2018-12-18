using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Cp.Helpers;
using Cp.Model;
using Cp.Viewmodel;
using Newtonsoft.Json;

using Newtonsoft.Json.Linq;


namespace Cp.Services
{
    public class ApiServices
    {


        public string xmlserialize(object o)
        {
            // Create a new XmlSerializer instance with the type of the test class
            //XmlSerializer SerializerObj = new XmlSerializer(o.GetType());
            var memoryStream = new MemoryStream();
            TextWriter stringWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8);
            XmlSerializer serializer = new XmlSerializer(o.GetType());
            serializer.Serialize(stringWriter, o);
            string xml = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
            return xml;
        }

        /*
         sample for tinyserialize
             
             private static void OnePet()
        {
            var petData = File.ReadAllText("OnePet.txt");
            var pet = TinySerializer.TinySerializer.DeSerialize(petData, new Pet());
            Console.WriteLine(
                $"This pet is a {pet.Type} and it is called {pet.Name}.\nAge:{pet.Age}\nWeight:{pet.Weight}KG");
        }

        private static void ManyPets()
        {
            var petsData =
                TinySerializer.TinySerializer.ExtractData(File.ReadAllText("ManyPets.txt"), "<?", "?>", true);
            var pets = new List<Pet>();
            Console.WriteLine($"This list contains {petsData.Count} pets.");
            foreach (var pet in petsData)
                pets.Add(TinySerializer.TinySerializer.DeSerialize(pet, new Pet()));
            foreach (var pet in pets)
                Console.WriteLine($"\nThis pet is called {pet.Name}.\nAge:{pet.Age}\nWeight:{pet.Weight}KG");
        }
        private static void Serialize()
        {
            var pet = new Pet();
            Console.Write("Type of the pet:"); var type = Console.ReadLine();
            Console.Write("Name of the pet:"); var name = Console.ReadLine();
            Console.Write("Age of the pet:"); var age = Console.ReadLine();
            Console.Write("Weight of the pet:"); var weight = Convert.ToDouble(Console.ReadLine());
            pet.Age = age;
            pet.Name = name;
            pet.Weight = weight;
            pet.Type = type;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Generated code:\n{TinySerializer.TinySerializer.Serialize(pet)}");
        }
        private static void Main()
        {
            Console.Title = "TinySerializer for .NET";
            Console.WriteLine("1)Serialize\n2)Deserialize");
            var choice = Console.ReadLine();
            if (choice == "1")
                Serialize();
            else if (choice == "2")
            {
                Console.WriteLine("1)Show one pet\n2)Show many pets");
                choice = Console.ReadLine();
                if (choice == "1")
                    OnePet();
                else if (choice == "2")
                    ManyPets();

            }

            Console.ReadKey();
        }

        private class Pet
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public string Age { get; set; }
            public double Weight { get; set; }
        }
        */

        public string tiny_serialize(object o)
        {
            string tiny_txt = TinySerializer.TinySerializer.Serialize(o);
            return tiny_txt;
        }

        public T tiny_deserialize<T>(string serializeData, T target) where T : new()
        {
            T res_obj = TinySerializer.TinySerializer.DeSerialize(serializeData, target);
            return res_obj;
        }

        /// <summary>
        /// serialize
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string serialize(object o)
        {
            string txt;

            // TEST
            if (Constants.IS_LIVEPLAYER)
            {
                txt = TinySerializer.TinySerializer.Serialize(o);
                //Helpers.Utils.Msgbox(xml);
            }
            else
            {
                txt = JsonConvert.SerializeObject(o);
            }

            return txt;
        }

        public object deserialize<T>(string serializeData, T target) where T : new()
        {
            object res_obj;

            // TEST
            if (Constants.IS_LIVEPLAYER)
            {
                res_obj = TinySerializer.TinySerializer.DeSerialize(serializeData, target);
            }
            else
            {
                res_obj = JsonConvert.DeserializeObject<T>(serializeData);
            }
            return res_obj;
        }

        public async Task<bool> SignupAsync(
            string email,
            string password,
            string name,
            string mobile)
        {

            try
            {
                RegistartionViewModel register = new RegistartionViewModel()
                {
                    email = email,
                    password = password,
                    name = name,
                    mobile = mobile
                };

                string txt = this.serialize(register);

                //var xml = this.tiny_serialize(register);
                //await DisplayAlert("Result", xml, "OK");
                //Helpers.Utils.Msgbox(xml);

                //var aaa = await content.ReadAsStringAsync();
                //await DisplayAlert("Request", json, "OK");

                var content = new StringContent(txt, Encoding.UTF8, "application/json");
                //txt = await content.ReadAsStringAsync();

                HttpClient client = new HttpClient();
                var resp = await client.PostAsync(Constants.API_URL + "/user/register", content);
                //var resp = await client.GetAsync(Constants.API_URL+"/user/register");

                //System.Console.WriteLine("@Signupbtn: content="+content);
                //Helpers.Utils.Msgbox(""+result.StatusCode);

                if (resp.StatusCode == HttpStatusCode.OK)
                {

                    //var cont= resp.Content.ReadAsStringAsync().ToString();

                    string cont = await resp.Content.ReadAsStringAsync();
                    //await DisplayAlert("Result", cont, "OK");
                    //cont = await resp.Content.ReadAsStringAsync().Result;

                    ResponseJSON res_json = (ResponseJSON)this.deserialize(cont, new ResponseJSON());

                    if (res_json.result_code == 100)
                    {
                        //await DisplayAlert("Result", cont, "OK");
                        return true;
                    }

                    //Helpers.Utils.Msgbox(cont);

                    //await DisplayAlert("Hey", "Your record has been added", "Alright");
                }
            }
            catch (Exception e)
            {
                //throw new Exception(e.ToString());

            }

            return false;
        }

        public async Task<bool> ProfileUpdateAsync(
            string email,
            string password,
            string name,
            string mobile)
        {

            try
            {
                RegistartionViewModel register = new RegistartionViewModel()
                {
                    email = email,
                    password = password,
                    name = name,
                    mobile = mobile
                };

                string txt = this.serialize(register);

                var content = new StringContent(txt, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer "+Glo.Data.token);
                var resp = await client.PostAsync(Constants.API_URL + "/user/register", content);

                if (resp.StatusCode == HttpStatusCode.OK)
                {

                    //var cont= resp.Content.ReadAsStringAsync().ToString();

                    string cont = await resp.Content.ReadAsStringAsync();
                    //await DisplayAlert("Result", cont, "OK");
                    //cont = await resp.Content.ReadAsStringAsync().Result;

                    ResponseJSON res_json = (ResponseJSON)this.deserialize(cont, new ResponseJSON());

                    if (res_json.result_code == 100)
                    {
                        //await DisplayAlert("Result", cont, "OK");
                        return true;
                    }

                    //Helpers.Utils.Msgbox(cont);

                    //await DisplayAlert("Hey", "Your record has been added", "Alright");
                }
            }
            catch (Exception e)
            {
                //throw new Exception(e.ToString());
            }

            return false;
        }

        public async Task<bool> LoginAsync(string id, string password)
        {
            //var keyValues = new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("id", userName),
            //    new KeyValuePair<string, string>("pass", password),

            //};

            //var request = new HttpRequestMessage(
            //    HttpMethod.Post, Constants.API_URL);

            //request.Content = new FormUrlEncodedContent(keyValues);

            //var client = new HttpClient();
            //var response = await client.SendAsync(request);
            //var content = await response.Content.ReadAsStringAsync();

            //Debug.WriteLine(content);

            try
            {
                LoginViewModel login_data = new LoginViewModel()
                {
                    id = id,
                    password = password
                };

                string txt = this.serialize(login_data);
                var content = new StringContent(txt, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                var resp = await client.PostAsync(Constants.API_URL + "/user/login", content);

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    string cont = await resp.Content.ReadAsStringAsync();
                    ResponseJSON res_json = (ResponseJSON)this.deserialize(cont, new ResponseJSON());

                    if (res_json.result_code == 100)
                    {
                        Glo.Data.id = id;
                        Glo.Data.token = res_json.new_token;

                        return true;
                    }

                }
            }
            catch (Exception e)
            {
                //throw new Exception(e.ToString());
            }
            return false;

        }


    }
}