namespace FirstResponsiveWebAppTreu2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.MapStaticAssets();

           //Ch 6 routing patterns addition
            app.MapControllerRoute(
                name: "paging_and_sorting",
                pattern: "{controller}/{action}/{id}/page{num}/sort-by-{sortby}");

            app.MapControllerRoute(
                name: "paging",
                pattern: "{controller}/{action}/{id}/page{num}");

            app.MapAreaControllerRoute(
                name: "admin",
                areaName: "Admin",
                pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
            // end of ch 6 addition
            

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();       


            app.Run();
        }
    }
}
