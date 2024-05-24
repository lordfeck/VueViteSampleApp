Vue Vite Sample App in ASP.NET
========================

# The Aims
- Application is divided into two 'sections', /client and /mynd.
- Login is handled by ASP.NET identity (stripped from this minimal reproduction repo)
- Clients and mynd users login and get their respective UI, the working one is mounted under `/Areas/MyND/Views/UI/Index.cshtml`
- When deploying to production, we will have frontend assets hosted by Nginx but login still processed by Asp.net (this is because its Identity system is featureful and we wish to keep it), i.e. we aren't running the app from Vite's index.html and having ASP.NET handle only API calls. (NB - I may revisit this idea if it is infeasible, we could probably still do ASP.NET identity and role auth using just APIs.)

# Starting this
For the frontend, just cd to JsAppRoot and run `npm run dev`. Start the backend code using dotnet or your IDE as usual. To see the problem, click on 'MyND Login' and then click 'Launch New UI' to open the Vue frontend.

# The problem description
The vue plugin works very well for ASP.NET. Also I have routing configured as I like it, ASP.NET handles API calls, Vue routing handles pages, all pages under the new UI path are passed to the Vue router.

However the problem is that 404 pages are not served by ASP.NET, rather they are passed to Vite which serves Vite's index.html.
Errors should show the ASP.Net ErrorDev page as defined in `Program.cs`, but it shows the Vite index.html instead.

I believe this is because the Vite middleware is slurping everything that isn't an explicit route and trying to serve it as a Vite asset.

The evidence for this belief is that when I change `app.UseViteDevelopmentServer(true);` to be `app.UseViteDevelopmentServer(false);` and visit a bad URL, the 404 pages display as expected but a consequence is that Vite assets are no longer served.

Ideally, we'd configure Vite to serve static assets under a subdirectory rather than root, which would make it clear when something should be passed to vite and when not. Or, instead of proxying requests through the listening ASP.NET kestrel server (https://localhost:7251), load the assets directly from the vite dev server (http://localhost:5173).

There is an ['assetsDir'](https://vitejs.dev/config/build-options.html#build-assetsdir) config value for Vite which could help, because assets would be served under a known path rather than just root. But it appears that Vite [only uses 'assetDir' for production builds](https://vitejs.dev/guide/assets.html#the-public-directory) which is frustrating as it is baffling.
