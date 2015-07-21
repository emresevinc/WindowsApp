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

        JsonObject _jObject = null;
        JsonArray jArr = null;
        List<Movie> _movieList = null;
        uint currentMovIndex;
        String title, year, released, rated, runtime, genre, director, writer, actors, plot, language, country, awards, poster,
            metascore, imdbRating, imdbVotes, type, response, imdbID;
        Movie selectedMovie;
   
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

                selectedMovie = new Movie();
                //----------------------------------------------------
                _jObject = JsonObject.Parse(text);  // Burada json dosyası parse ediliyor.
                jArr = _jObject.GetNamedArray("movies"); // Json verileri içindeki movies array'i
                fillToMovieList();
            }
            catch (Exception)
            {
               new MessageDialog("Bir hata gerceklesti").ShowAsync();
            }
        }

        private void fillToMovieList()
        {
            _movieList = new List<Movie>();
            int movieCount = jArr.Count;
            Movie mov = null;
            for (uint i = 0; i < movieCount; i++)
            {
                mov = new Movie();
                mov.Title = jArr.GetObjectAt(i).GetNamedString("Title");
                mov.Year = jArr.GetObjectAt(i).GetNamedString("Year");
                mov.Rated = jArr.GetObjectAt(i).GetNamedString("Rated");
                mov.Released = jArr.GetObjectAt(i).GetNamedString("Released");
                mov.Runtime = jArr.GetObjectAt(i).GetNamedString("Runtime");
                mov.Genre = jArr.GetObjectAt(i).GetNamedString("Genre");
                mov.Director = jArr.GetObjectAt(i).GetNamedString("Director");
                mov.Writer = jArr.GetObjectAt(i).GetNamedString("Writer");
                mov.Actors = jArr.GetObjectAt(i).GetNamedString("Actors");
                mov.Plot = jArr.GetObjectAt(i).GetNamedString("Plot");
                mov.Language = jArr.GetObjectAt(i).GetNamedString("Language");
                mov.Country = jArr.GetObjectAt(i).GetNamedString("Country");
                mov.Awards = jArr.GetObjectAt(i).GetNamedString("Awards");
                mov.Poster = jArr.GetObjectAt(i).GetNamedString("Poster");
                mov.Metascore = jArr.GetObjectAt(i).GetNamedString("Metascore");
                mov.imdbRating = jArr.GetObjectAt(i).GetNamedString("imdbRating");
                mov.imdbVotes = jArr.GetObjectAt(i).GetNamedString("imdbVotes");
                mov.Type = jArr.GetObjectAt(i).GetNamedString("Type");
                mov.Response = jArr.GetObjectAt(i).GetNamedString("Response");
                mov.imdbID = jArr.GetObjectAt(i).GetNamedString("imdbID");

                _movieList.Add(mov); // Adding mov to list
            }
        }

        
        private void RandomBtn_Click(object sender, RoutedEventArgs e)
        {
            getRandomMovie();
        }

        private Random r = new Random();
        private void getRandomMovie() 
        {
            int sayi = r.Next(jArr.Count); // 0 ile film sayisi arasinda rasgele bir filmi secmek icin sayi uretiyor
            currentMovIndex = (uint)sayi;
            

            selectedMovie.Title = _movieList[(Int32)currentMovIndex].Title;
            selectedMovie.Year = _movieList[(Int32)currentMovIndex].Year;
            selectedMovie.Rated = _movieList[(Int32)currentMovIndex].Rated;
            selectedMovie.Released = _movieList[(Int32)currentMovIndex].Released;
            selectedMovie.Runtime = _movieList[(Int32)currentMovIndex].Runtime;
            selectedMovie.Genre = _movieList[(Int32)currentMovIndex].Genre;
            selectedMovie.Director = _movieList[(Int32)currentMovIndex].Director;
            selectedMovie.Writer = _movieList[(Int32)currentMovIndex].Writer;
            selectedMovie.Actors = _movieList[(Int32)currentMovIndex].Actors;
            selectedMovie.Plot = _movieList[(Int32)currentMovIndex].Plot;
            selectedMovie.Language = _movieList[(Int32)currentMovIndex].Language;
            selectedMovie.Country = _movieList[(Int32)currentMovIndex].Country;
            selectedMovie.Awards = _movieList[(Int32)currentMovIndex].Awards;
            selectedMovie.Poster = _movieList[(Int32)currentMovIndex].Poster;
            selectedMovie.Metascore = _movieList[(Int32)currentMovIndex].Metascore;
            selectedMovie.imdbRating = _movieList[(Int32)currentMovIndex].imdbRating;
            selectedMovie.imdbVotes = _movieList[(Int32)currentMovIndex].imdbVotes;
            selectedMovie.Type = _movieList[(Int32)currentMovIndex].Type;
            selectedMovie.Response = _movieList[(Int32)currentMovIndex].Response;
            selectedMovie.imdbID = _movieList[(Int32)currentMovIndex].imdbID;
            loadPoster(selectedMovie.Poster);
            fillToMovieInfo();
        }

        private void fillToMovieInfo() 
        {
            titleTxt.Text = selectedMovie.Title;
            yearTxt.Text = selectedMovie.Year;
            ratedTxt.Text = selectedMovie.Rated;
            releasedTxt.Text = selectedMovie.Released;
            runtimeTxt.Text = selectedMovie.Runtime;
            genreTxt.Text = selectedMovie.Genre;
            directorTxt.Text = selectedMovie.Director;
            writerTxt.Text = selectedMovie.Writer;
            actorsTxt.Text = selectedMovie.Actors;
            plotTxt.Text = selectedMovie.Plot;
            languageTxt.Text = selectedMovie.Language;
            countryTxt.Text = selectedMovie.Country;
            awardsTxt.Text = selectedMovie.Awards;
            metascoreTxt.Text = selectedMovie.Metascore;
            imdbRatingTxt.Text = selectedMovie.imdbRating;
            imdbVotesTxt.Text = selectedMovie.imdbVotes;
            typeTxt.Text = selectedMovie.Type;
            responseTxt.Text = selectedMovie.Response;
            imdbIDTxt.Text = selectedMovie.imdbID;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

    }
}
