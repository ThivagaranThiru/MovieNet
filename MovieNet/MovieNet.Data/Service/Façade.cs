using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNet.Data.ImplDao;
using MovieNet.Data.IDao;

namespace MovieNet.Data.Service
{
    public class Façade
    {
        private DataModelContainer dataModelContainer;
        private IUtilisateurDao utilisateurDao;
        private IMovieDao movieDao;
        private ICommentsDao commentsDao;
        private static Façade instance;

        public Façade()
        {
            dataModelContainer = new DataModelContainer();
            utilisateurDao = new UtilisateurDao(dataModelContainer);
            movieDao = new MovieDao(dataModelContainer);
            commentsDao = new CommentsDao(dataModelContainer);
        }

        public static Façade Instance()
        {
            if(instance == null)
            {
                instance = new Façade();
            }

            return instance;
        }

        public Users Connexion(string login, string password)
        {

            return utilisateurDao.Authenticate(login, password);
        }

        public Film AddMovie(Film film)
        {
            return movieDao.CreateMovie(film);
        }

        public Film UpdateMovie(Film film)
        {
            return movieDao.UpdateMovie(film);
        }

        public bool DeleteMovie(Film film)
        {
            if(movieDao.FindMovieById(film.Id) != null)
            {
                List<Commentaire_Note> comment = commentsDao.FindCommentsByMovie(film.Id);

                if (comment != null)
                {
                    foreach (Commentaire_Note delete in comment)
                    {
                        commentsDao.DeleteComments(delete);

                    }
                }

                return movieDao.DeleteMovie(film);
            }

            return false;
        }

        public List<Film> AllMovie()
        {
            return movieDao.FindAllMovie();
        }

        public List<string> AllGenre()
        {
            return movieDao.FindAllGenreMovie();
        }

        public List<Film> ByGenre(string genre)
        {
            return movieDao.FindMovieByGenre(genre);
        }

        public List<Film> ByTitle(string title)
        {
            return movieDao.FindMovieByTitre(title);
        }

        public Film ById(int id)
        {
            return movieDao.FindMovieById(id);
        }

        public Commentaire_Note AddComment(Commentaire_Note comment)
        {
            return commentsDao.CreateComments(comment);
        }

        public List<Commentaire_Note> AllComments (int idMovie)
        {
            return commentsDao.FindCommentsByMovie(idMovie);
        }

        public Users AddUser(Users user)
        {
            return utilisateurDao.CreateUtilisateur(user);
        }

        public Users UpdateUser(Users user)
        {
            return utilisateurDao.UpdateUtilisateur(user);
        }

        public bool DeleteUser(Users user)
        {
            if(utilisateurDao.FindUtilisateurById(user.Id) != null)
            {
                List<Commentaire_Note> comments = commentsDao.FindCommensByUser(user.Id);

                if(comments != null)
                {
                    foreach (Commentaire_Note delete in comments)
                    {
                        commentsDao.DeleteComments(delete);

                    }
                }

                return utilisateurDao.DeleteUtilisateur(user);
            }

            return false;
        }
    }
}
