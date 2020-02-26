using System.Collections.Generic;
using System.Linq;
using MovieApp.Models;

namespace MovieApp.Data {
    public static class MovieRepository {
        private static List<Movie> _movies = null;
        static MovieRepository () {
            _movies = new List<Movie> () {
                new Movie() {Id=1,Name="Super Mario",ShortDescription="Super Mario",Description="<p>Bir cücenin prensesi kurtarmak için uğraşları</p><p>Bu uğraşlar sonucu başına bela almaya başlamıştır ve dev kaplumbağalar ile ejderhalar bu cücenin peşine düşmüştür</p>",ImageUrl="resim1.jpg",CategoryId=1},
                new Movie() {Id=2,Name="Super Astro",ShortDescription="Super Astro",Description="<p>Uzay Dünyası'nı kurtarmak için savaşa başlayan bir çocuk</p><p>İlerde yeryüzü dünyası'nı da kurtaracaktır fakat kendisinin farkında değildir...</p>",ImageUrl="resim2.jpg",CategoryId=2},
                new Movie() {Id=3,Name="Bored Cat",ShortDescription="Bored Cat",Description="<p>Garfield ile birlikte savaşmaya and içmiş Bored Cat! Kedilerin babası, garfield'ın azılı en acımasız düşmanı.<p>Bütün köpeklerin korkulu rüyası Bored Cat'i hâlâ izlemediyseniz çok şey kaçırmışsınızdır!</p></p>",ImageUrl="resim3.jpg",CategoryId=2},
                new Movie() {Id=4,Name="Super Tom",ShortDescription="Super Tom",Description="<p>Super Tom ise farelerin korkulu rüyası</p><p>Peynir çalan bu yaratıklara karşı savaşmaya and içmiş süper Tom dünyada en son fare kalmayıncaya kadar savaşmaya and içmiştir</p>",ImageUrl="resim4.jpg",CategoryId=3},
                new Movie() {Id=5,Name="Jelly Man",ShortDescription="Jelly Man",Description="<p>Jelly Man! Adı Jelly Bean'in Kardeşi Jelly Augusto Jellé Bon Ponaparti De Las Ul Kulgissimith vel Jeliboun'den gelen Jelly Man...</p>",ImageUrl="resim5.jpg",CategoryId=3}
                
            };
        }
        public static List<Movie> Movies {
            get {
                return _movies;
            }
        }
        public static void AddMovie (Movie entity) {
            _movies.Add (entity);
        }
        public static Movie GetById (int id) {
            return _movies.FirstOrDefault (i => i.Id == id);
        }
    }
}