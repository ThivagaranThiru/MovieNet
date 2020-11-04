using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNet.Data.IDao;

namespace MovieNet.Data.ImplDao
{
    public class CommentsDao : ICommentsDao
    {
       private DataModelContainer dataModelContainer;

        public CommentsDao(DataModelContainer model)
        {
            this.dataModelContainer = model;
        }

        public Commentaire_Note CreateComments(Commentaire_Note comments)
        {
            dataModelContainer.Commentaire_NoteSet.Add(comments);
            dataModelContainer.SaveChanges();

            return comments;
        }

        public bool DeleteComments(Commentaire_Note comments)
        {
            if(comments.Id > 0 && dataModelContainer.Commentaire_NoteSet.Where(c => c.Id.Equals(comments.Id)).Count() > 0)
            {
                dataModelContainer.Commentaire_NoteSet.Remove(comments);
                dataModelContainer.SaveChanges();

                return true;
            }

            return false;
        }

        public Commentaire_Note UpdateComments(Commentaire_Note comments)
        {
            if (comments.Id > 0 && dataModelContainer.Commentaire_NoteSet.Where(c => c.Id.Equals(comments.Id)).Count() > 0)
            {
                dataModelContainer.SaveChanges();

                return comments;
            }

            return null;
        }

        public List<Commentaire_Note> FindAllComments()
        {
            return dataModelContainer.Commentaire_NoteSet.ToList();
        }

        public Commentaire_Note FindCommentsById(int idComments)
        {
            return dataModelContainer.Commentaire_NoteSet.Find(idComments);
        }

        public List<Commentaire_Note> FindCommentsByNote(int note)
        {
            return dataModelContainer.Commentaire_NoteSet.Where(c => c.Notes.Equals(note)).ToList();
        }

        public List<Commentaire_Note> FindCommensByUser(int idUser)
        {
            return dataModelContainer.Commentaire_NoteSet.Where(c => c.Users.Id.Equals(idUser)).ToList();
        }

        public List<Commentaire_Note> FindCommentsByMovie(int idMovie)
        {
            return dataModelContainer.Commentaire_NoteSet.Where(c => c.Film.Id.Equals(idMovie)).ToList();
        }
    }
}
