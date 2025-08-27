using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.Concrete;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using CQRS_MediatR_RentACar.BusinessLayer.Services;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.SendMessageHandlers;
using CQRS_MediatR_RentACar.BusinessLayer.Interfaces;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.CreateCarRecommendationAIHandlers;
using CQRS_MediatR_RentACar.UILayer.RapidApiServices.AirportAPI;
using CQRS_MediatR_RentACar.UILayer.RapidApiServices.CityAPI;
using CQRS_MediatR_RentACar.UILayer.RapidApiServices.FuelAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CQRSMediatRDbContext>();

builder.Services.AddScoped<IAboutDal,EfAboutDal>();
builder.Services.AddScoped<IFeatureDal,EfFeatureDal>();
builder.Services.AddScoped<ISliderDal,EfSliderDal>();
builder.Services.AddScoped<IStaffDal,EfStaffDal>();
builder.Services.AddScoped<IServiceDal,EfServiceDal>();
builder.Services.AddScoped<ILocationDal,EfLocationDal>();
builder.Services.AddScoped<ITestimonialDal,EfTestimonialDal>();
builder.Services.AddScoped<ICarDal,EfCarDal>();
builder.Services.AddScoped<IAirportDal,EfAirportDal>();
builder.Services.AddScoped<IBookingDal,EfBookingDal>();
builder.Services.AddScoped<IContactDal,EfContactDal>();
builder.Services.AddScoped<ISendMessageDal,EfSendMessageDal>();
builder.Services.AddScoped<ICarRecommendationAIDal,EfCarRecommendationAIDal>();
builder.Services.AddHttpClient<IOpenAIService, OpenAIService>();
builder.Services.AddHttpClient<AirportRapidApiClient>();
builder.Services.AddHttpClient<LocationRapidApiClient>();
builder.Services.AddHttpClient<FuelRapidApiClient>();
builder.Services.AddScoped<IEmailService,EmailService>();
builder.Services.AddScoped<ICarRecommendationAIService,CarRecommendationAIService>();
builder.Services.AddApplicationService(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
