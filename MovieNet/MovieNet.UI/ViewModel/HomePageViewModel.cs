using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MovieNet.Data;
using MovieNet.Data.Service;

namespace MovieNet.UI
{
    public class HomePageViewModel : ViewModelBase
    {
        private Façade facade;
        private List<Film> movies;
        private List<Commentaire_Note> allComment;
        private Film movieSelected;
        private string search;
        private string genre;
        private Users user;
        private Commentaire_Note comment;
        private List<string> genreMovie;

        private AddMovieWindow addMovieWindow;
        private CommentMovieWindow commentMovieWindows;
        private AllCommentMovieWindow allCommentMovieWindow;
        public List<string> NameCollection { get; set; }
        public RelayCommand MyButtonAddMovieCommand { get; }
        public RelayCommand MyDeleteMovieCommand { get; }
        public RelayCommand MySearchCommand { get;  }
        public RelayCommand MyAddMovieCommand { get; }
        public RelayCommand MyButtonCommentMovieCommand { get; }
        public RelayCommand MyCommentMovieCommand { get; }
        public  RelayCommand MyButtonAllCommentCommand { get; }

        public HomePageViewModel()
        {
            facade = Façade.Instance();
            Movies = facade.AllMovie();
            GenreMovie = facade.AllGenre();
            Comment = new Commentaire_Note();
            MovieSelected = null;
            Search = "";
            Genre = "";

            NameCollection = new List<string>
            {
                "Action",
                "Comédie",
                "Horreur"
            };

            MyButtonAddMovieCommand = new RelayCommand(MyButtonAddMovieCommandExecute, MyButtonAddMovieCanExecute);
            MyAddMovieCommand = new RelayCommand(MyAddMovieCommandExecute, MyAddMovieCanExecute);
            MyDeleteMovieCommand = new RelayCommand(MyDeleteMovieCommandExecute, MyDeleteMovieCanExecute);
            MySearchCommand = new RelayCommand(MySearchCommandExecute, MySearchCanExecute);
            MyButtonCommentMovieCommand = new RelayCommand(MyButtonCommentMovieCommandExecute, MyButtonCommentMovieCanExecute);
            MyCommentMovieCommand = new RelayCommand(MyCommentMovieCommandExecute, MyCommentMovieCanExecute);
            MyButtonAllCommentCommand = new RelayCommand(MyButtonAllCommentMovieCommandExecute, MyButtonAllCommentMovieCanExecute);
        }

        public Users User
        {
            get { return user; }
            set
            {
                user = value;
                RaisePropertyChanged("User");
            }
        }

        public Commentaire_Note Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                RaisePropertyChanged("Comment");
            }
        }


        public List<Film> Movies
        {
            get { return movies; }
            set
            {
                movies = value;
                RaisePropertyChanged("Movies");
            }
        }

        public List<Commentaire_Note> AllComment
        {
            get { return allComment; }
            set
            {
                allComment = value;
                RaisePropertyChanged("AllComment");
            }
        }


        public Film MovieSelected
        {
            get { return movieSelected; }
            set
            {
                movieSelected = value;
                RaisePropertyChanged("MovieSelected");
            }
        }

        public string Search
        {
            get { return search; }
            set
            {
                search = value;
                RaisePropertyChanged("Search");
            }
        }

        public string Genre
        {
            get { return genre; }
            set
            {
                genre = value;

                if(genre != "")
                {
                    Movies = facade.ByGenre(genre);
                    genre = "";
                }

                RaisePropertyChanged("Genre");
            }
        }

        public List<string> GenreMovie
        {
            get { return genreMovie; }
            set
            {
                genreMovie= value;

                RaisePropertyChanged("GenreMovie");
            }
        }

        public void MyButtonAddMovieCommandExecute()
        {
            if(MovieSelected == null) MovieSelected = new Film();
            addMovieWindow = new AddMovieWindow();
            addMovieWindow.ShowDialog();
        }

        public bool MyButtonAddMovieCanExecute()
        {
            return true;
        }

        public void MyAddMovieCommandExecute()
        {
            if(MovieSelected.Titre != null && MovieSelected.Genre != null && MovieSelected.Resume != null)
            {
                if(movieSelected.Id > 0 && facade.ById(movieSelected.Id) != null)
                {
                    facade.UpdateMovie(movieSelected);

                } else facade.AddMovie(MovieSelected);

                MovieSelected = null;
                Movies = facade.AllMovie();
                GenreMovie = facade.AllGenre();
                addMovieWindow.Close();
            }    
        }

        public bool MyAddMovieCanExecute()
        {
            return true;
        }

        public void MySearchCommandExecute()
        {
            if(Search != "")
            {
                Movies = facade.ByTitle(Search);
                Search = "";
            }else
            {
                Movies = facade.AllMovie();
            }
        }

        public bool MySearchCanExecute()
        {
            return true;
        }

        public void MyDeleteMovieCommandExecute()
        {
          if(MovieSelected != null)
          {
                if (facade.DeleteMovie(MovieSelected))
                {
                    MovieSelected = null;
                    Movies = facade.AllMovie();
                    GenreMovie = facade.AllGenre();
                };
          }
        }

        public bool MyDeleteMovieCanExecute()
        {
            return true;
        }

        public void MyButtonCommentMovieCommandExecute()
        {

            if(MovieSelected != null)
            {
                commentMovieWindows = new CommentMovieWindow();
                commentMovieWindows.ShowDialog();
            }
        }

        public bool MyButtonCommentMovieCanExecute()
        {
            return true;
        }

        public void MyCommentMovieCommandExecute()
        {
           if(Comment.Commentaires != null &&  Comment.Notes <= 10 && MovieSelected != null && User != null)
           {
                Comment.Film = MovieSelected;
                Comment.Users = User;

                if(facade.AddComment(Comment) != null)
                {
                    MovieSelected = null;
                    commentMovieWindows.Close();
                }
           }
        }

        public bool MyCommentMovieCanExecute()
        {
            return true;
        }

        public void MyButtonAllCommentMovieCommandExecute()
        {

            if (MovieSelected != null)
            {
                allCommentMovieWindow = new AllCommentMovieWindow();
                AllComment = facade.AllComments(MovieSelected.Id);
                allCommentMovieWindow.ShowDialog();
            }
        }

        public bool MyButtonAllCommentMovieCanExecute()
        {
            return true;
        }

    }
}
