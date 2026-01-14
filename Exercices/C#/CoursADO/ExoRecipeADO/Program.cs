using ExoRecipeADO.Query;

namespace ExoRecipeADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CategorieQuery.Add();
            //CategorieQuery.GetAll();
            //CategorieQuery.Update(1);
            //CategorieQuery.GetById(1);
            //CategorieQuery.Delete(2);
            //CategorieQuery.GetAll();

            //IngredientQuery.Add();
            //IngredientQuery.Add();
            //IngredientQuery.GetAll();
            //IngredientQuery.Update(1);
            //IngredientQuery.GetById(1);
            //IngredientQuery.Delete(2);
            //IngredientQuery.GetAll();

            //EtapeQuery.Add();
            //EtapeQuery.Add();
            //EtapeQuery.GetAll();
            //EtapeQuery.Update(1);
            //EtapeQuery.Delete(2);
            //EtapeQuery.GetAll();

            //CommentaireQuery.Add();
            //CommentaireQuery.Add();
            //CommentaireQuery.GetAll();
            //CommentaireQuery.Update(1);
            //CommentaireQuery.Delete(2);
            //CommentaireQuery.GetAll();

            RecetteQuery.Add();
            RecetteQuery.Add();
            RecetteQuery.GetAll();
            RecetteQuery.Update(1);
            RecetteQuery.Delete(2);
            RecetteQuery.GetAll();
        }
    }
}
