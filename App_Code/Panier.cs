using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Panier
/// </summary>
public class Panier
{
    public int IdPanier { get; set; }
    public int UserId { get; set; }
    public List<Commande> ListeCommandes { get; set; }

    public Panier()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public float getTotale()
    {
        float somme = 0;
        foreach(Commande c in ListeCommandes)
        {
            somme += c.getTotal();
        }

        return somme;
    }
}