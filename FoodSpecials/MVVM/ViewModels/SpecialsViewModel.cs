using FoodSpecials.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpecials.MVVM.ViewModels
{
    public class SpecialsViewModel
    {
        public ObservableCollection<Specials> Specials { get; set; }
        public ObservableCollection<Icons> Icons { get; set; }
        public SpecialsViewModel()
        {
            var listOfIcons=GetSqlIcons();
            var listOfSpecials = GetSqlSpecials();
            Specials = new ObservableCollection<Specials>();
            foreach (var item in listOfSpecials)
            {
                Specials.Add(item);
            }
            Icons = new ObservableCollection<Icons>();
            foreach (var item in listOfIcons)
            {
                Icons.Add(item);
            }
        }
        private List<Icons> GetSqlIcons()
        {
            List<Icons> iconstrings = new List<Icons>();
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7006/api/Specials/GetIcons");
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            // Get data response
            var response = client.GetAsync(string.Empty).Result;
            if (response.IsSuccessStatusCode)
            {
                var JsonString = response.Content.ReadAsStringAsync();

                string jsonArray = JsonString.Result;
                var _icons = JsonConvert.DeserializeObject<List<Icons>>(jsonArray);
                foreach (var item in _icons)
                {
                    byte[] Base64Stream = Convert.FromBase64String(item.ImageString);
                    var imgSource = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
                    Icons icon = new Icons() { ImageId =item.ImageId, ImageString = item.ImageString, _ImageSource = imgSource };
                    iconstrings.Add(icon);
                    
                }
                return iconstrings;
            }
            return iconstrings;

        }
        private List<Specials> GetSqlSpecials()
        {
            List<Specials> specials = new List<Specials>();
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7006/api/Specials");
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            // Get data response
            var response = client.GetAsync(string.Empty).Result;
            if (response.IsSuccessStatusCode)
            {
                var JsonString = response.Content.ReadAsStringAsync();

                string jsonArray = JsonString.Result;
                var _specials = JsonConvert.DeserializeObject<List<Specials>>(jsonArray);
                foreach (var item in _specials)
                {
                    byte[] Base64Stream = Convert.FromBase64String(item.ImageString);
                    var imgSource = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
                    Specials special = new Specials() {SpecialDescription= item.SpecialDescription,
                        RestaurantName = item.RestaurantName,
                        FullPrice= item.FullPrice,
                        DiscountedPrice= item.DiscountedPrice,
                        FullAdress= item.FullAdress,
                        Dates= item.Dates,
                        SpecialName= item.SpecialName,
                        Image_Source= imgSource,
                    };
                    specials.Add(special);
                }

            }
            return specials;

        }
    }
}
