using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApplication1
{
    
    class Program
    {
        
        static void trailerEkle()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Emre\Desktop\json files\imdbFull.json");
            string[] lines2 = System.IO.File.ReadAllLines(@"C:\Users\Emre\Desktop\json files\embed-trailer.txt");
            int i = 0;

            foreach (string line in lines)
            {
                if (line.Contains("\"Response\":\"True\""))
                {
                    string text = line.Replace("\"Response\":\"True\"", lines2[i]);
                    i++;
                    System.IO.File.AppendAllText(@"C:\Users\Emre\Desktop\json files\imdbFull2.json", text+"\n");
                }
            }
        }

        private static void AddDataToDB()
        {

            MRandomatorDataContext context = new MRandomatorDataContext();

            String text = System.IO.File.ReadAllText(@"C:\Users\Emre\Desktop\json files\imdbFull2.json");
            JObject mov = JsonConvert.DeserializeObject<JObject>(text);
            JArray jar = (JArray)mov["movies"];

            for (int i = 0; i < jar.Count; i++)
            {
                Movy movie = new Movy();
                movie.Title = jar[i]["Title"].ToString();
                movie.Year = Int32.Parse(jar[i]["Year"].ToString());
                movie.Rated = jar[i]["Rated"].ToString();
                movie.Released = jar[i]["Released"].ToString();
                movie.Runtime = jar[i]["Runtime"].ToString();
                movie.Genre = jar[i]["Genre"].ToString();
                movie.Director = jar[i]["Director"].ToString();
                movie.Writer = jar[i]["Writer"].ToString();
                movie.Actors = jar[i]["Actors"].ToString();
                movie.Plot = jar[i]["Plot"].ToString();
                movie.Language = jar[i]["Language"].ToString();
                movie.Country = jar[i]["Country"].ToString();
                movie.Awards = jar[i]["Awards"].ToString();
                movie.Poster = jar[i]["Poster"].ToString();
                movie.Metascore = jar[i]["Metascore"].ToString();
                movie.imdbRating = jar[i]["imdbRating"].ToString();
                movie.imdbVotes = jar[i]["imdbVotes"].ToString();
                //movie.Type = jar[i]["Type"].ToString();
                movie.Trailer = jar[i]["Trailer"].ToString();
                context.Movies.InsertOnSubmit(movie);
                //context.SubmitChanges();  Değişiklikleri uygular.
            }
        }

        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
}
