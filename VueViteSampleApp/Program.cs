
using Serilog;
using Serilog.Events;
using Hangfire;
using VueViteSampleApp.Services;
using VueViteSampleApp.Services.Implementation;
using Microsoft.AspNetCore.HttpOverrides;
using Vite.AspNetCore;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    // BEGIN Builder.
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext());
    
    // Transient - created each time it is required. Use on web services, because they will typically serve one action
    // to the controller.
    builder.Services.AddTransient<IReceptionService, ReceptionService>();


    // Routing config - enable lowercase URLs
    builder.Services.AddRouting(options => options.LowercaseUrls = true);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddViteServices();
    

    
    var mvcBuilder = builder.Services.AddRazorPages();

    if (builder.Environment.IsDevelopment())
    {
        mvcBuilder.AddRazorRuntimeCompilation();
    }

    // END builder, create the webapp instance...
    var app = builder.Build();
    

    app.UseStaticFiles();
    app.UseSerilogRequestLogging();
    app.UseRouting();

    if (builder.Environment.IsDevelopment())
    {
        // Use header forwarding to Nginx when in production.
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });
    }

    // Register middleware


    // Configure the HTTP request pipeline.
    // Include mappings to pass all SPA routes to the right endpoints.
    app.MapControllerRoute(name: "MyND", pattern: "{area:exists}/{controller=Reception}/{action=Index}/{id?}");
    app.MapControllerRoute(name: "Client", pattern: "{area:exists}/{controller=Reception}/{action=Index}/{id?}");
    // Rewrite the SPA routes
    app.MapControllerRoute( name: "MyNDSpa", pattern: "/mynd/ui/{*url}", 
        defaults: new {area="MyND", controller = "Ui", action = "Index"} );
    app.MapControllerRoute( name: "ClientSpa", pattern: "/client/ui/{*url}", 
        defaults: new {area="Client", controller = "Ui", action = "Index"} );
    
    app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();
    app.MapControllers(); // will fill in routes as declared in decorators - use these for the API

    /*
    var options = new RewriteOptions()
        .AddRewrite("^/mynd/reception/newui/.*", "/mynd/reception/newui/", skipRemainingRules: true)
        .AddRewrite("^/clinic/newui/.*", "/clinic/newui/", skipRemainingRules: true);
    app.UseRewriter(options);
    */

    if (app.Environment.IsDevelopment()) // configure for dev environment
    {
        // Use dev error screen with a more detailed message.
        app.UseStatusCodePagesWithReExecute("/Home/ErrorDev", "?statusCode={0}");
        // enable all routes listing 
        app.MapGet("/debug/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
            string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)).ToLower());
        
        app.UseViteDevelopmentServer(true);
    }
    else // configure production
    {
        app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
        app.UseHttpsRedirection();
        builder.WebHost.UseUrls("http://*:5000");
    }
    
    Log.Information("startup complete.");

    app.Run();
    

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
