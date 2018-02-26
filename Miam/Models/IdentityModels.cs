using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Miam.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<IngredientIndex> IngredientIndex { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<IngredientRecipe> IngredientRecipe { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Miam.ViewModels.RecipeFormViewModel> RecipeFormViewModels { get; set; }

        public System.Data.Entity.DbSet<Miam.ViewModels.IngredientRecipeFormViewModel> IngredientRecipeFormViewModels { get; set; }

        public System.Data.Entity.DbSet<Miam.ViewModels.MealFormViewModel> MealFormViewModels { get; set; }
    }
}