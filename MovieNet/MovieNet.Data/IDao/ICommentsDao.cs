using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNet.Data.IDao
{
    interface ICommentsDao
    {
        List<Commentaire_Note> FindAllComments();
        Commentaire_Note FindCommentsById(int idComments);
        List<Commentaire_Note> FindCommentsByNote(int note);
        List<Commentaire_Note> FindCommensByUser(int idUser);
        List<Commentaire_Note> FindCommentsByMovie(int idMovie);
        Commentaire_Note CreateComments(Commentaire_Note comments);
        Commentaire_Note UpdateComments(Commentaire_Note comments);
        Boolean DeleteComments(Commentaire_Note comments);
    }
}
