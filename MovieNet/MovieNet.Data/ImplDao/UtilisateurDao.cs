using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNet.Data.IDao;

namespace MovieNet.Data.ImplDao
{
    public class UtilisateurDao : IUtilisateurDao
    {
        private DataModelContainer dataModelContainer;

        public UtilisateurDao(DataModelContainer model)
        {
            this.dataModelContainer = model;
        }

        public Users Authenticate(string email, string password)
        {
            Users users = null;

            if(dataModelContainer.UsersSet.Where(u => u.Login.Equals(email) && u.Password.Equals(password)).Count() > 0)
            {
                users = dataModelContainer.UsersSet.First(u => u.Login.Equals(email) && u.Password.Equals(password));
            }
                
            return users;
        }

        public Users CreateUtilisateur(Users user)
        {
            if (dataModelContainer.UsersSet.Where(u => u.Login.Equals(user.Login) && u.Password.Equals(user.Password)).Count() > 0) return null;

            dataModelContainer.UsersSet.Add(user);
            dataModelContainer.SaveChanges();

            return user;
        }

        public Users UpdateUtilisateur(Users user)
        {
            if (user.Id > 0 && dataModelContainer.UsersSet.Where(u => u.Id.Equals(user.Id)).Count() > 0)
            {
                dataModelContainer.SaveChanges();

                return user;
            }

            return null;
        }

        public bool DeleteUtilisateur(Users user)
        {
            if (user.Id > 0 && dataModelContainer.UsersSet.Where(u => u.Id.Equals(user.Id) && u.Login.Equals(user.Login) && u.Password.Equals(user.Password)).Count() > 0)
            {
                dataModelContainer.UsersSet.Remove(user);
                dataModelContainer.SaveChanges();

                return true;
            }

            return false;
        }

        public List<Users> FindAllUtilisateurs()
        {
            return dataModelContainer.UsersSet.ToList();
        }

        public Users FindUtilisateurById(int idUtilisateur)
        {
            return dataModelContainer.UsersSet.Find(idUtilisateur);
        }

        public List<Users> FindUtilisateurByLogin(string login)
        {
            return dataModelContainer.UsersSet.Where(u => u.Login.Equals(login)).ToList();
        }

        public List<Users> FindUtilisateurByPassword(string password)
        {
            return dataModelContainer.UsersSet.Where(u => u.Password.Equals(password)).ToList();
        }

        public List<Users> FindUtilisateursByNom(string nom)
        {
            return dataModelContainer.UsersSet.Where(u => u.Password.Equals(nom)).ToList();
        }

        public List<Users> FindUtilisateursByPrenom(string prenom)
        {
            return dataModelContainer.UsersSet.Where(u => u.Password.Equals(prenom)).ToList();
        }
    }
}
