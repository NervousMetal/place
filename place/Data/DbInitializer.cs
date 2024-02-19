using place.Models;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;



namespace place.Data

{
    public class DbInitializer
    {
        public static void Initialize(PlaceContext context)
        {
            context.Database.EnsureCreated();

            // Look for any publication.
            if (context.Publications.Any())
            {
                return;   // DB has been seeded
            }

            var utilisateurs = new Utilisateur[]
            {
            new Utilisateur{Email="caro@gmail.com",Password="Pas123Word!",LastName="Steele", FirstName="Caro", Role="Admin"},
            new Utilisateur{Email="diana@gmail.com",Password="Pas123Word!",LastName="Farhat",FirstName="Diana",Role="Admin"},
            new Utilisateur{Email="toto@gmail.com",Password="Pas123Word!",LastName="Roro",FirstName="Toto",Role="Citoyen"},
            new Utilisateur{Email="titi@gmail.com",Password = "Pas123Word!", LastName="Riri",FirstName="Titi",Role="Citoyen"},
            new Utilisateur{Email="tutu@gmail.com",Password = "Pas123Word!", LastName="Ruru",FirstName="Tutu",Role="Citoyen" },

            };
            foreach (Utilisateur u in utilisateurs)
            {
                context.Utilisateurs.Add(u);
            }
            context.SaveChanges();

            var categories = new Categorie[]
            {
            new Categorie{CatId=1,CatName="Faits Historiques"},
            new Categorie{CatId=2,CatName="Souvenirs"},
            new Categorie{CatId=3,CatName="Anecdotes"},
            };
            foreach (Categorie c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();



            var publications = new Publication[]
            {
            new Publication
            {
                PublicationTitle="Le bain Morgan",
                PublicationDescription="Texte descriptif LONG",
                PublicationImage="images/publications/Bain_Morgan.jpg",
                PublicationDate=DateTime.Parse("2024-01-02", CultureInfo.InvariantCulture),
              CatId = 1,
              UserId = utilisateurs[0].UserId,

             },

            new Publication
            {
                PublicationTitle="Le moulin de Pointe-aux-Trembles",
                PublicationDescription="Texte descriptif LONG",
                PublicationImage="images/publications/Moulin_PAT.jpg",
                PublicationDate=DateTime.Parse("2024-01-05", CultureInfo.InvariantCulture),
                    CatId = 2,
              UserId = utilisateurs[0].UserId,
             },


            };
            foreach (Publication p in publications)
            {
                context.Publications.Add(p);
            }
            context.SaveChanges();
        }

    }
}
