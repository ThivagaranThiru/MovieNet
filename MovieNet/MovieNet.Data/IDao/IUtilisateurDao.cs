using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNet.Data.IDao
{
    interface IUtilisateurDao
    {
        List<Users> FindAllUtilisateurs();
        Users FindUtilisateurById(int idUtilisateur);
        List<Users> FindUtilisateursByPrenom(String prenom);
        List<Users> FindUtilisateursByNom(String nom);
        List<Users> FindUtilisateurByLogin(String login);
        List<Users> FindUtilisateurByPassword(String password);
        Users CreateUtilisateur(Users user);
        Users UpdateUtilisateur(Users user);
        Boolean DeleteUtilisateur(Users user);
        Users Authenticate(String email, String password);
    }
}
