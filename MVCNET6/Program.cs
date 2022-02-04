using Microsoft.Data.SqlClient;
using MVCNET6.Data.Repositories;
using SigQL;
using SigQL.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var connectionString = "Server=localhost;Database=SigQL_MVCNET6;Trusted_Connection=True;MultipleActiveResultSets=true";
builder.Services.AddSingleton(s =>
{
    var sqlDatabaseConfiguration = new SqlDatabaseConfiguration(connectionString);
    return sqlDatabaseConfiguration;
});
builder.Services.AddSingleton(s =>
{
    var sqlDatabaseConfiguration = s.GetService(typeof(SqlDatabaseConfiguration)) as SqlDatabaseConfiguration;
    var repositoryBuilder = new RepositoryBuilder(new SqlQueryExecutor(() => new SqlConnection(connectionString)), sqlDatabaseConfiguration);
    return repositoryBuilder;
});
builder.Services.AddSingleton(s =>
{
    var repositoryBuilder = s.GetService(typeof(RepositoryBuilder)) as RepositoryBuilder;
    return repositoryBuilder.Build<IEmployeeRepository>(s.GetService);
});
builder.Services.AddSingleton(s =>
{
    var repositoryBuilder = s.GetService(typeof(RepositoryBuilder)) as RepositoryBuilder;
    return repositoryBuilder.Build<IWorkLogRepository>(s.GetService);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

});

app.Run();