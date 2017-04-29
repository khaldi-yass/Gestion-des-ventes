using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MaSession
/// </summary>
public class MaSession
{
    public string SessionId { get; set; }
    public string Login { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public Panier Panier { get; set; }
    public string Error { get; set; }
    public string Success { get; set; }
    
    public MaSession(string login, string nom, string prenom)
    {
        SessionId = Guid.NewGuid().ToString();
        Login = login;
        Nom = nom;
        Prenom = prenom;
        Panier = new Panier();
    }

}