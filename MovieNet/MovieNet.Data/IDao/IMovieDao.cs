using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNet.Data.IDao
{
    interface IMovieDao
    {
        List<Film> FindAllMovie();
        Film FindMovieById(int idMovie);
        List<Film> FindMovieByTitre(String titre);
        List<Film> FindMovieByGenre(String genre);
        Film CreateMovie(Film film);
        Film UpdateMovie(Film film);
        Boolean DeleteMovie(Film film);
        List<string> FindAllGenreMovie();
    }
}
