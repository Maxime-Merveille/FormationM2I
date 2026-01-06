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
                        // Échange
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
            Console.WriteLine($"\n ----- Top {top} des ventes ce mois-ci -----\n");
            for(int i = 0; i< top; i++)
            {
                Console.WriteLine($"Top {i+1} des ventes : {noms[i]}");
            }
        }

        public static double CalculerTauxRotation(int ventes, int stock)
        {
            double rotation = ventes / stock;
            return rotation;
        }

        //TODO
        //public static void

        static void Main(string[] args)
        {
            string[] nomsProduits = { "Peugeot 206" , "Citroen C1", "Renault Scenic", "Porsche 911", "Ferrari Enzo", "Bugatti Veyron", "Le C15 de papi"};
            double[] prixProduits = { 2000.99, 1499.99, 2200.99, 49999.99,150000.00, 300000.00, 20.00};
            int[] stockProduits = { 40, 100, 23, 9, 11, 4, 0};
            int[] nombreVenteProduits = { 45, 60 , 100 ,12, 5 , 6 , 1};

            Console.WriteLine("=== SYSTÈME DE GESTION D'INVENTAIRE ===");
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

            Console.WriteLine("\n===== Listage des fiches produits =====");
            for(int i = 0;i < nomsProduits.Length;i++)
            {
                Console.WriteLine($"\n--- Produit {i+1} ---");
                AfficherFicheProduit(nomsProduits[i], prixProduits[i], stockProduits[i], nombreVenteProduits[i]);
            }

            Console.WriteLine("\n===== Statistiques globales =====\n");

            Console.WriteLine($"Valeur totale du stock : {CalculerValeurStock(prixProduits, stockProduits)}");

            Console.WriteLine($"Le prix moyen est de {CalculerMoyenne(prixProduits)}");

            Console.WriteLine($"Chiffre d'affaire total du mois : {CalculerChiffreAffaires(prixProduits, nombreVenteProduits)}");

            Console.WriteLine($"Produit le plus cher : {TrouverProduitPlusCher(nomsProduits, prixProduits)}");

            Console.WriteLine($"Produit le plus vendu : {TrouverProduitLePlusVendu(nomsProduits, nombreVenteProduits)}");

            Console.WriteLine($"Il y a {CompterProduitsEnRupture(stockProduits)
} produits en rupture");

            Console.WriteLine($"Il y a {CompterProduitsStockFaible(stockProduits,10)} en stock faible");
            AfficherAlerteStock(nomsProduits, stockProduits, 10);

            Console.WriteLine("\n===== EXERCICE 4 =====");

            TrierParVentes(nomsProduits, prixProduits, stockProduits, nombreVenteProduits);

            Console.WriteLine("\n===== Listage des fiches produits =====");
            for (int i = 0; i < nomsProduits.Length; i++)
            {
                Console.WriteLine($"\n--- Produit {i + 1} ---");
                AfficherFicheProduit(nomsProduits[i], prixProduits[i], stockProduits[i], nombreVenteProduits[i]);
            }

            AfficherTopVentes(nomsProduits, nombreVenteProduits, 3);

            Console.WriteLine($"\nLe taux de rotation pour le produit 1 - {nomsProduits[0]} est de {CalculerTauxRotation(nombreVenteProduits[0], stockProduits[0])}");
        }
    }
}
