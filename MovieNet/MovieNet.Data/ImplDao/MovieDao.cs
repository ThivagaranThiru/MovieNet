using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNet.Data.IDao;

namespace MovieNet.Data.ImplDao
{
    public class MovieDao : IMovieDao
    {
        private DataModelContainer dataModelContainer;

        public MovieDao(DataModelContainer model)
        {
            this.dataModelContainer = model;
        }

        public Film CreateMovie(Film film)
        {
            dataModelContainer.FilmSet.Add(film);
            dataModelContainer.SaveChanges();

            return film;
        }

        public bool DeleteMovie(Film film)
        {
            if (film.Id > 0 && dataModelContainer.FilmSet.Where(f => f.Id.Equals(film.Id) && f.Titre.Equals(film.Titre) && f.Genre.Equals(f.Genre) && f.Resume.Equals(film.Resume)).Count() > 0)
            {
                dataModelContainer.FilmSet.Remove(film);
                dataModelContainer.SaveChanges();

                return true;
            }

            return false;
        }

        public Film UpdateMovie(Film film)
        {
           if(film.Id > 0 && dataModelContainer.FilmSet.Where(f => f.Id.Equals(film.Id)).Count() > 0)
           {
                dataModelContainer.SaveChanges();

                return film;
           }

            return null;
        }

        public List<Film> FindAllMovie()
        {
            return dataModelContainer.FilmSet.ToList();
        }

        public Film FindMovieById(int idMovie)
        {
            return dataModelContainer.FilmSet.Find(idMovie);
        }

        public List<Film> FindMovieByGenre(string genre)
        {
            return dataModelContainer.FilmSet.Where(f => f.Genre.Equals(genre)).ToList();
        }

        public List<Film> FindMovieByTitre(string titre)
        {
            return dataModelContainer.FilmSet.Where(f => f.Titre.Contains(titre)).ToList();
        }

        public List<string> FindAllGenreMovie()
        {
            return dataModelContainer.FilmSet.Select(f => f.Genre).Distinct().ToList();
        }
    }
}
