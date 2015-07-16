using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Text;
using System.Diagnostics;
using Windows.Data.Json;
using Windows.UI.Xaml.Media.Imaging;


namespace App2
{
    public sealed partial class MainPage : Page
    {

        static JsonObject _jObject = null;

        public MainPage()
        {
            this.InitializeComponent();

            //this.NavigationCacheMode = NavigationCacheMode.Required;
            loadJsonInfo();
            
        }

        private void loadPoster(String uri)
        {
            img.Source = new BitmapImage(new Uri(uri, UriKind.Absolute));
        }


        async private void loadJsonInfo() 
        {
            try
            {
                //--------- Having content from website--------------
                HttpClient http = new HttpClient();
                var response = await http.GetByteArrayAsync("http://emresevinc.github.io/exrepo.html");
                String source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
                source = WebUtility.HtmlDecode(source);
                HtmlDocument resultat = new HtmlDocument();
                resultat.LoadHtml(source);

                List<HtmlNode> toftitle = resultat.DocumentNode.Descendants().Where
                    (x => (x.Name == "div" && x.Attributes["class"] != null &&
                    x.Attributes["class"].Value.Contains("container"))).ToList();
                String text = toftitle[0].InnerText;
                Debug.WriteLine(text);
                //----------------------------------------------------

                _jObject = JsonObject.Parse(text);  // Burada json dosyası parse ediliyor.
                //Debug.WriteLine(_jObject.GetNamedArray("movies").GetObjectAt(0).GetNamedValue("Year").GetString());
            }
            catch (Exception)
            {
                //new MessageDialog("hata gerçekleşti").ShowAsync();
            }
        }

        private static Random r = new Random();
        private void RandomBtn_Click(object sender, RoutedEventArgs e)
        {
            int sayi = r.Next(_jObject.GetNamedArray("movies").Count); // 0 ile film sayisi arasinda rasgele bir filmi secmek icin sayi uretiyor
            Debug.WriteLine(sayi);
            String uri = _jObject.GetNamedArray("movies").GetObjectAt((uint)sayi).GetNamedValue("Poster").GetString();
            loadPoster(uri);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

    }
}
