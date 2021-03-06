# MVCJWTTokenDemo

MVC JWT Token Demo 

## ASP.NET Core web API documentation with Swagger / OpenAPI

### Configuring and Using Swagger UI in ASP.NET Core Web API

     - Install Swashbuckle.Aspnetcore
            1.Right-click the API project in Solution Explorer and select Manage NuGet Packages
            2.Type Swashbuckle.AspNetCore in the search box
            3.Select Swashbuckle.AspNetCore and click Install

    - Configure Swagger Middleware
        services.AddSwaggerGen();

    - Configure
        // This middleware serves generated Swagger document as a JSON endpoint
        app.UseSwagger();

        // This middleware serves the Swagger documentation UI
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
        });


 URL for document:  https://localhost:44379/swagger/index.html
 
                     https://localhost:44379/swagger/v1/swagger.json


----------------------------------------------------------------------------------------
## Logger in ASP.NET Core 

In Program.cs, we add following code

.ConfigureLogging(logBuilder =>
    {
        logBuilder.ClearProviders(); // removes all providers from LoggerFactory
        logBuilder.AddConsole();  
        logBuilder.AddTraceSource("Information, ActivityTracing"); // Add Trace listener provider
    })

2. add code in startup.cs with methodd Configure 
  
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) 
{
    // other code remove for clarity 
    loggerFactory.AddFile("Logs/mylog-{Date}.txt");
}

3. install package through PackageManager console

Install-Package Serilog.Extensions.Logging.File -Version 2.0.0 


### wwwroot

   - wwwroot folder in the ASP.NET Core project is treated as a web root folder
   - Static files can be stored in any folder under the web root and accessed with a relative path to that root

   #### add bootstrap and jquery  file
    -> wwwroot -> right click -> add file - Client-side Libarary

    -  right click on libman.json file and select "Restore Client-Side Libraries" from the context menu



## JWTToken - https://jwt.io/introduction

    Step 1 :- Generate 
    -   `public string GenerateJSONWebToken()
        {
            // when he is validated AD
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, "sar"),
                new Claim(JwtRegisteredClaimNames.Email, "sarveshmcasoft@gmail.com"),
                new Claim("Role", "Admin"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }`


    Step 2: Attache the middle ware 
                  
           ` services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {

               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Configuration["Jwt:Issuer"],
                   ValidAudience = Configuration["Jwt:Issuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
               };
           });`


    Step 3: Add data in file appsettings.json

       `"Jwt": {
                "Key": "545454568686869898989",
                "Issuer": "sarveshsoft"
            }`


https://localhost:44379/api/login


--------------------

-


            // migration enable in .net core

            `Add-Migration MVCJWTTokenDemo.DAL.DBContext -Context DBContext`

            //update 

            `update-database -Context DBContext`



Error : 

Inner Exception 1:
SqlException: Cannot insert explicit value for identity column in table 'Emp' when IDENTITY_INSERT is set to OFF.



