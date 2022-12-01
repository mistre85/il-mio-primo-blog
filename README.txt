### comandi per la gestione di identity [authentication,authorization]

#installazione pacchetti

dotnet tool install -g dotnet-aspnet-codegenerator

- se non compatibile installare la versione desiderata con l'opzione --version=x.y


dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version=6.0
dotnet add package Microsoft.AspNetCore.Identity.UI --version=6.0
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version=6.0

#modificare il context
da questa configurazione:	public class BlogDbContext : DbContext
diventa:					public class BlogDbContext : IdentityDbContext<IdentityUser>

#migrazione
dotnet ef migrations add CreateIdentityTables
dotnet ef database update

#scaffolidng dell'auth
dotnet-aspnet-codegenerator identity --dbContext BlogDbContext --files "Account.Login;Account.Logout;Account.Register"

#sistemiamo il context
- copiamo costruttore e metodo OnModelCreating all'interno del dbcontext originale (nostro)
- cancello il Area/Identity/Data
- sistemare gli errori di neamespace e inclusione in program.cs

#controllare la connection string in appsettings.json
- copiare la stringa di connessione (dal server o dal dbcontext)
-incollare la stringa nell'apposita chiave dentro appsettings.json
-possiamo eliminare il metodo OnConfiguring dal dbcontext

#configurazioni in program

// codice da aggiungere dopo app.UseRouting()
app.UseAuthentication();

//prima del MapControllerRoute
app.MapRazorPages();

#modificare i controller che si vogliono autenticare con
[Authorize]

#gestione delle navigaazioni logged/notlogged

- da mettere dentro il vostro "guest layout"
<li class="nav-item">
		  <a class="nav-link" aria-current="page" href="@Url.Action("Index", "Post")">Admin</a>
		</li>
		<!-- code omitted -->

- da mettere dentro il vostro "guest layout" e nel vostro "logged layout"
<partial name="_LoginPartial" />
