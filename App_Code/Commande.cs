using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Commande
/// </summary>
public class Commande
{
    public int NumCommande { get; set; }
    public string DateCommande { get; set; }
    public int QteArticle { get; set; }

    public int NumClient { get; set; }

    public int NumArticle { get; set; }
    public float PrixUnitaire { get; set; }
    public string DesignationArticle { get; set; }
    public string PhotoArticle { get; set; }


    public Commande()
    { }

    public float getTotal()
    {
        return PrixUnitaire * QteArticle;
    }

}