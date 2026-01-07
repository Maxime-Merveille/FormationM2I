//_______________________________________________________________________________________________________________________________________//
//   Programme développé par                                                                                                             //
//   ___  ___   ___    _   _   _____   ___ ___ _____           ___  ___  _____   _____   _   _   _____   _____   _       _       _____   //
//   |  \/  |  / _ \  | \ / | |_   _| |  \/  | |  ___|         |  \/  | |  ___| | ___ | | | | | |  ___| |_   _| | |     | |     |  ___|  //
//   | .  . | / /_\ \  \ V /    | |   | .  . | | |__           | .  . | | |__   | |_/ / | | | | | |__     | |   | |     | |     | |__    //
//   | |\/| | |  _  |  / _ \    | |   | |\/| | |  __|          | |\/| | |  __|  |    /  | | | | |  __|    | |   | |     | |     |  __|   //
//   | |  | | | | | | / / \ \  _| |_  | |  | | | |___          | |  | | | |___  | |\ \  \ \_/ / | |___   _| |_  | |____ | |____ | |___   //
//   \_|  |_/ \_| |_/ \/   \/ |_____| \_|  |_/ \____/          \_|  |_/ \____/  \_| \_|  \___/  \____/  |_____| \_____/ \_____/ \____/   //
//                                                                                                                                       //
//                                               /\_/\           ___                                                                     //
//                                              = o_o =_______    \ \                                                                    //
//                                               __^      __(  \___) )                                                                   //
//                                           (@)<_____>__(_____)____/                                                                    //
//	 Le 07/01/2026                                                                                                                       //
//_______________________________________________________________________________________________________________________________________//

namespace Fonctions
{
    internal class Program
    {

        public static double CalculerValeurStock(double[] prix, int[] quantites)
        {
            double valeurTotale = 0;
            for(int i = 0; i < quantites.Length; i++)
            {
                valeurTotale = prix[i] * quantites[i];
            }
            return valeurTotale;
        }

        public static double CalculerChiffreAffaires(double[] prix, int[] ventes) 
        {
            double chiffreAffaire = 0;
            for (int i = 0; i < ventes.Length; i++)
            {
                chiffreAffaire += prix[i] * ventes[i];
            }
            return chiffreAffaire;
        }

        public static string TrouverProduitPlusCher(string[] noms, double[] prix)
        {
            int indexPlusCher = prix.IndexOf(prix.Max());
            return noms[indexPlusCher];
        }

        public static string TrouverProduitLePlusVendu(string[] noms, int[] ventes)
        {
            int indexPlusVendu = ventes.IndexOf(ventes.Max());
            return noms[indexPlusVendu];
        }

        public static int CompterProduitsEnRupture(int[] quantites)
        {
            int compteur = 0;
            foreach (int q in quantites)
            {
                if (q <= 0) compteur++;
            }

            return compteur;
        }

        public static int CompterProduitsStockFaible(int[] quantites, int seuil)
        {
            int compteur = 0;
            foreach (int q in quantites)
            { 
                if (q <= seuil && q > 0) compteur++;
            }

            return compteur;
        }

        public static void AfficherFicheProduit(string nom, double prix, int quantite, int ventes)
        {
            string status = "";
            switch (quantite)
            {
                case 0:
                    status = "En rupture";
                    break;
                case < 10:
                    status = "Stock faible";
                    break;
                case > 10:
                    status = "Stock correct";
                    break;
                default:
                    status = "Erreur lecture stock";
                    break;
            }
            Console.WriteLine($"\nNom du produit : {nom}");
            Console.WriteLine($"Prix du produit : {prix}");
            Console.WriteLine($"Quantitee dispo du produit : {quantite}");
            Console.WriteLine($"Nombre de ventes du produit : {ventes}");
            Console.WriteLine($"CA generee par le produit : {prix * ventes}");
            Console.WriteLine($"Status du produit : {status}");
        }

        public static double CalculerMoyenne(double[] valeurs)
        {
            double moyenne = 0;

            foreach(double v in valeurs)
            {
                moyenne += v; 
            }

            return moyenne/valeurs.Length;

        }

        public static void AfficherAlerteStock(string[] noms, int[] quantites, int seuil)
        {
            Console.WriteLine("\n=== ALERTES DE STOCK ===\n");
            bool isAlerte = false;

            for (int i = 0; i < quantites.Length; i++) 
            { 
                
                if (quantites[i] <= seuil)
                {
                    isAlerte = true;
                    Console.WriteLine($"Alerte stock pour le produit {noms[i]}");
                }
            }
            if(!isAlerte) Console.WriteLine("Aucune alerte");
            
        }

        public static void TrierParVentes(string[] noms, double[] prix, int[] quantites, int[] ventes)
        {
            // var temporaire
            string tempNom = "";
            double tempPrix = 0.0;
            int tempQuantite = 0;
            int tempVentes = 0;

            // Tri à bulle
            for (int i = 0; i < ventes.Length - 1; i++)
            {
                for (int j = 0; j < ventes.Length - 1 - i; j++)
                {
                    if (ventes[j] < ventes[j + 1])
                    {
                        // Échange de var
                        tempVentes = ventes[j];
                        tempNom = noms[j];
                        tempPrix = prix[j];
                        tempQuantite = quantites[j];

                        ventes[j] = ventes[j + 1];
                        ventes[j + 1] = tempVentes;

                        noms[j] = noms[j + 1];
                        noms[j + 1] = tempNom;

                        prix[j] = prix[j + 1];
                        prix[j + 1] = tempPrix;

                        quantites[j] = quantites[j + 1];
                        quantites[j + 1] = tempQuantite;
                    }
                }
            }
        }

        public static void AfficherTopVentes(string[] noms, int[] ventes, int top)
        {
            //Si le tri se fait a l'avance, ca :

            /*
            Console.WriteLine($"\n ----- Top {top} des ventes ce mois-ci -----\n");
            for(int i = 0; i< top; i++)
            {
                Console.WriteLine($"Top {i+1} des ventes : {noms[i]}");
            }
            */

            // Si il faut faire le tri ici, alors ca :

            string tempNom = "";
            int tempVentes = 0;

             // Tri à bulle
            for (int i = 0; i < ventes.Length - 1; i++)
            {
                for (int j = 0; j < ventes.Length - 1 - i; j++)
                {
                    if (ventes[j] < ventes[j + 1])
                    {
                        // Échange de var
                        tempVentes = ventes[j];
                        tempNom = noms[j];

                        ventes[j] = ventes[j + 1];
                        ventes[j + 1] = tempVentes;

                        noms[j] = noms[j + 1];
                        noms[j + 1] = tempNom;

                    }
                }
            }

            Console.WriteLine($"\n ----- Top {top} des ventes ce mois-ci -----\n");
            for (int i = 0; i < top; i++)
            {
                Console.WriteLine($"Top {i + 1} des ventes : {noms[i]}");
            }
        }

        public static double CalculerTauxRotation(int ventes, int stock)
        {
            double rotation = decimal.ToDouble(ventes) / decimal.ToDouble(stock); // Forcer le resultat en double
            return Math.Round(rotation,3);
        }

        
        public static void ShowAllProduit(string[] noms, double[] prix, int[] quantites, int[] ventes)
        {
            Console.WriteLine("\n===== Listage des fiches produits =====");
            for (int i = 0; i < noms.Length; i++)
            {
                Console.WriteLine($"\n--- Produit {i + 1} ---");
                AfficherFicheProduit(noms[i], prix[i], quantites[i], ventes[i]);
            }
        }

        public static void ShowStatsGlobale(string[] noms, double[] prix, int[] quantites, int[] ventes)
        {
            Console.WriteLine("\n===== Statistiques globales =====\n");

            Console.WriteLine($"Valeur totale du stock : {CalculerValeurStock(prix, quantites)}");

            Console.WriteLine($"Le prix moyen est de {CalculerMoyenne(prix)}");

            Console.WriteLine($"Chiffre d'affaire total du mois : {CalculerChiffreAffaires(prix, ventes)}");

            Console.WriteLine($"Produit le plus cher : {TrouverProduitPlusCher(noms, prix)}");

            Console.WriteLine($"Produit le plus vendu : {TrouverProduitLePlusVendu(noms, ventes)}");

            Console.WriteLine($"Il y a {CompterProduitsEnRupture(quantites)} produits en rupture");

            Console.WriteLine($"Il y a {CompterProduitsStockFaible(quantites, 10)} en stock faible");

        }

        public static void GetProduitByName(string[] noms, double[] prix, int[] quantites, int[] ventes, string recherche)
        {
            int index = noms.IndexOf(recherche);
            if( index == -1)
            {
                Console.WriteLine("Erreur, produit introuvable");
            }
            else
            {
                Console.WriteLine($"Produit {recherche}");
                Console.WriteLine($"Prix unitaire : {prix[index]}");
                Console.WriteLine($"Quantité en stock : {quantites[index]}");
                Console.WriteLine($"Ventes du mois : {ventes[index]}");
            }
                
        }

        static void Main(string[] args)
        {
            string[] nomsProduits = { "Peugeot 206" , "Citroen C1", "Renault Scenic", "Porsche 911", "Ferrari Enzo", "Bugatti Veyron", "Le C15 de papi"};
            double[] prixProduits = { 2000.99, 1499.99, 2200.99, 49999.99,150000.00, 300000.00, 20.00};
            int[] stockProduits = { 40, 100, 23, 9, 11, 4, 0};
            int[] nombreVenteProduits = { 45, 60 , 100 ,12, 5 , 6 , 1};

            Console.WriteLine("=== SYSTÈME DE GESTION D'INVENTAIRE ===\n");
            #region Region UI
            /*
            Console.WriteLine("Entrez le nombre de produit dans l'inventaire (entre 5 et 20):");
            
            int nombreProduit = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < nombreProduit; i++)
            {
                Console.WriteLine($"Entrez le nom du produit n°{i+1} :");
                nomsProduits[i] = Console.ReadLine();

                //TODO faire verif entree
                Console.WriteLine($"Entrez le prix du produit n°{i + 1} (entre 0.01 et 10000:");
                prixProduits[i] = Double.Parse(Console.ReadLine());

                //TODO faire verif entree
                Console.WriteLine($"Entrez le stock du produit n°{i + 1} : (entre 0 et 1000");
                stockProduits[i] = Int32.Parse(Console.ReadLine());

                //TODO faire verif entree
                Console.WriteLine($"Entrez le nombre de vente du produit n°{i + 1} ce mois-ci : (entre 0 et 1000");
                stockProduits[i] = Int32.Parse(Console.ReadLine());
            }
            */
            #endregion

            bool continuer = true;

            while (continuer)
            {
                Console.WriteLine("\n===== MENU =====\n");

                Console.WriteLine("1 - Afficher tout les produits\n2 - Afficher les stats globales\n3 - Afficher alertes stock\n4 - Recherche produit par noms\n5 - Afficher top 5 ventes\n6 - Trier tableau\n7 - Afficher taux de rotation\nAutres touches pour quitter");

                string choixMenu = Console.ReadLine();

                switch (choixMenu)
                {
                    case "1":
                        ShowAllProduit(nomsProduits, prixProduits, stockProduits, nombreVenteProduits);
                        break;

                    case "2":
                        ShowStatsGlobale(nomsProduits, prixProduits, stockProduits, nombreVenteProduits);
                        break;

                    case "3":
                        Console.WriteLine("Quel est le seuil d'alerte de stock ?");
                        int seuil = Int32.Parse(Console.ReadLine());
                        AfficherAlerteStock(nomsProduits, stockProduits, seuil);
                        break;

                    case "4":
                        Console.WriteLine("Quel produits cherchez vous ?");
                        string recherche = Console.ReadLine();
                        GetProduitByName(nomsProduits, prixProduits, stockProduits, nombreVenteProduits, recherche);
                        break;

                    case "5":
                        AfficherTopVentes(nomsProduits, nombreVenteProduits, 5);
                        break;

                    case "6":
                        TrierParVentes(nomsProduits, prixProduits, stockProduits, nombreVenteProduits);
                        ShowAllProduit(nomsProduits, prixProduits, stockProduits, nombreVenteProduits);
                        break;

                    case "7":
                        Console.WriteLine("Quel n° de produits cherchez vous ?");
                        int choix = Int32.Parse(Console.ReadLine());
                        Console.WriteLine($"Taux de rotation de {nomsProduits[choix]} : {CalculerTauxRotation(nombreVenteProduits[choix], stockProduits[choix])}");
                        break;

                    default:
                        continuer = false;
                        break;


                }
            }
            
        }
    }
}
