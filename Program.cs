using HealthNCare.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using HealthNCare.Areas.Identity.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Configure the DbContext with connection strings
builder.Services.AddDbContext<Patients1DbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Patients1DbContextConnection"));
});

builder.Services.AddDbContext<HospitalContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection5"));
});
/*
builder.Services.AddDbContext<DoctorContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection1"));
});

builder.Services.AddDbContext<LocationContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection3"));
});

builder.Services.AddDbContext<DepartmentContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection4"));
});

builder.Services.AddDbContext<AppointmentContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection6"));
});

builder.Services.AddDbContext<TimeContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection7"));
});
*/
builder.Services.AddDefaultIdentity<Patients1>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<Patients1DbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<HospitalContext>();
    context.Database.EnsureCreated();
    SeedDatabase(context); // Call the SeedDatabase method
}
app.Run();
void SeedDatabase(HospitalContext context)
    {
        if (!context.Locations.Any())
        {
            var locations = new List<Location>
            {
                new Location { LocationId = "1", Name = "Adalar" },
                new Location { LocationId = "2", Name = "Arnavutköy" },
                new Location { LocationId = "3", Name = "Ataşehir" },
                new Location { LocationId = "4", Name = "Avcılar" },
                new Location { LocationId = "5", Name = "Bağcılar" },
                new Location { LocationId = "6", Name = "Bahçelievler" },
                new Location { LocationId = "7", Name = "Bakırköy" },
                new Location { LocationId = "8", Name = "Başakşehir" },
                new Location { LocationId = "9", Name = "Bayrampaşa" },
                new Location { LocationId = "10", Name = "Beşiktaş" },
                new Location { LocationId = "11", Name = "Beykoz" },
                new Location { LocationId = "12", Name = "Beylikdüzü" },
                new Location { LocationId = "13", Name = "Beyoğlu" },
                new Location { LocationId = "14", Name = "Büyükçekmece" },
                new Location { LocationId = "15", Name = "Çatalca" },
                new Location { LocationId = "16", Name = "Çekmeköy" },
                new Location { LocationId = "17", Name = "Esenler" },
                new Location { LocationId = "18", Name = "Esenyurt" },
                new Location { LocationId = "19", Name = "Eyüp" },
                new Location { LocationId = "20", Name = "Fatih" },
                new Location { LocationId = "21", Name = "Gaziosmanpaşa" },
                new Location { LocationId = "22", Name = "Güngören" },
                new Location { LocationId = "23", Name = "Kadıköy" },
                new Location { LocationId = "24", Name = "Kağıthane" },
                new Location { LocationId = "25", Name = "Kartal" },
                new Location { LocationId = "26", Name = "Küçükçekmece" },
                new Location { LocationId = "27", Name = "Maltepe" },
                new Location { LocationId = "28", Name = "Pendik" },
                new Location { LocationId = "29", Name = "Sancaktepe" },
                new Location { LocationId = "30", Name = "Sarıyer" },
                new Location { LocationId = "31", Name = "Silivri" },
                new Location { LocationId = "32", Name = "Sultanbeyli" },
                new Location { LocationId = "33", Name = "Sultangazi" },
                new Location { LocationId = "34", Name = "Şile" },
                new Location { LocationId = "35", Name = "Şişli" },
                new Location { LocationId = "36", Name = "Tuzla" },
                new Location { LocationId = "37", Name = "Ümraniye" },
                new Location { LocationId = "38", Name = "Üsküdar" },
                new Location { LocationId = "39", Name = "Zeytinburnu" }
                // Lokasyon bilgileri buraya eklenecek..
            };
            context.Locations.AddRange(locations);

            var hospitals = new List<Hospital>
            {
                // Hastane bilgileri buraya eklenecek. 
                new Hospital { HospitalId = "28", Name = "Kartal Lütfi Kırdar Eğitim ve Araştırma Hastanesi Büyükada Ek Hizmet Binası", LocationId = "1" },
    new Hospital { HospitalId = "1", Name = "Arnavutköy Devlet Hastanesi", LocationId = "2" },
    //new Hospital { HospitalId = "2", Name = "Avcılar Murat Kölük Devlet Hastanesi", LocationId = "2" },
    new Hospital { HospitalId = "26", Name = "S.B.Ü. Metin Sabancı Baltalimanı Kemik Hastalıkları Eğitim ve Araştırma Hastanesi", LocationId = "3" },
    new Hospital { HospitalId = "29", Name = "Haliç Üniversitesi Tıp Fakültesi Hastanesi - Avcılar Hospital", LocationId = "4" },
    new Hospital { HospitalId = "23", Name = "S.B.Ü. Bağcılar Eğitim ve Araştırma Hastanesi", LocationId = "5" },
    new Hospital { HospitalId = "4", Name = "Bahçelievler Devlet Hastanesi", LocationId = "6" },
    new Hospital { HospitalId = "25", Name = "S.B.Ü. Bakırköy Dr. Sadi Konuk Eğitim ve Araştırma Hastanesi", LocationId = "7" },
   // new Hospital { HospitalId = "24", Name = "S.B.Ü. Prof. Dr. Mazhar Osman Ruh ve Sinir Hastalıkları Eğitim ve Araştırma Hastanesi, Bakırköy", LocationId = "7" },
    new Hospital { HospitalId = "3", Name = "Başakşehir Devlet Hastanesi", LocationId = "8" },
    new Hospital { HospitalId = "5", Name = "Bayrampaşa Devlet Hastanesi", LocationId = "9" },
    new Hospital { HospitalId = "6", Name = "Beşiktaş Sait Çiftçi Devlet Hastanesi", LocationId = "10" },
    new Hospital { HospitalId = "7", Name = "Beykoz Devlet Hastanesi", LocationId = "11" },
    new Hospital { HospitalId = "30", Name = "Beylikdüzü Devlet Hastanesi", LocationId = "12" },
    new Hospital { HospitalId = "31", Name = "İSTANBUL BEYOĞLU GÖZ EĞİTİM VE ARAŞTIRMA HASTANESİ", LocationId = "13" },
    new Hospital { HospitalId = "8", Name = "Büyükçekmece Mimar Sinan Devlet Hastanesi", LocationId = "14" },
    new Hospital { HospitalId = "9", Name = "Çatalca İlyas Çokay Devlet Hastanesi", LocationId = "15" },
    new Hospital { HospitalId = "32", Name = "Çekmeköy Devlet Hastanesi", LocationId = "16" },
    new Hospital { HospitalId = "19", Name = "Esenler Kadın Doğum ve Çocuk Hastalıkları Hastanesi", LocationId = "17" },
    new Hospital { HospitalId = "10", Name = "Esenyurt Necmi Kadıoğlu Devlet Hastanesi", LocationId = "18" },
    new Hospital { HospitalId = "11", Name = "Eyüpsultan Devlet Hastanesi", LocationId = "19" },
    new Hospital { HospitalId = "12", Name = "İstinye Devlet Hastanesi", LocationId = "20" },
    new Hospital { HospitalId = "33", Name = "Gaziosmanpaşa Eğitim ve Araştırma Hastanesi", LocationId = "21" },
    new Hospital { HospitalId = "34", Name = "Bağcılar Eğitim Ve Araştırma Hastanesi EK Bina", LocationId = "22" },
    new Hospital { HospitalId = "27", Name = "S.B.Ü. Erenköy Ruh ve Sinir Hastalıkları Eğitim ve Araştırma Hastanesi", LocationId = "23" },
    new Hospital { HospitalId = "13", Name = "Kağıthane Devlet Hastanesi", LocationId = "24" },
    new Hospital { HospitalId = "35", Name = "Kartal Dr. Lütfi Kırdar Şehir Hastanesi", LocationId = "25" },
    new Hospital { HospitalId = "14", Name = "Küçükçekmece Kanuni Sultan Süleyman Hastanesi", LocationId = "26" },
    new Hospital { HospitalId = "15", Name = "Maltepe Devlet Hastanesi", LocationId = "27" },
    new Hospital { HospitalId = "16", Name = "Pendik Devlet Hastanesi", LocationId = "28" },
    new Hospital { HospitalId = "36", Name = "Şehit Prof. Dr. İlhan Varank Sancaktepe Eğitim ve Araştırma Hastanesi", LocationId = "29" },
    new Hospital { HospitalId = "37", Name = "Sarıyer Hamidiye Etfal Eğitim ve Araştırma Hastanesi", LocationId = "30" },
    new Hospital { HospitalId = "18", Name = "Silivri Devlet Hastanesi", LocationId = "31" },
    new Hospital { HospitalId = "20", Name = "Sultanbeyli Devlet Hastanesi", LocationId = "32" },
    new Hospital { HospitalId = "38", Name = "Sultangazi Haseki Egitim ve Araştırma Hastanesi", LocationId = "33" },
    new Hospital { HospitalId = "21", Name = "Şile Devlet Hastanesi", LocationId = "34" },
    new Hospital { HospitalId = "39", Name = "SBÜ Şişli Hamidiye Etfal Eğitim ve Araştırma Hastanesi", LocationId = "35" },
    new Hospital { HospitalId = "17", Name = "Tuzla Devlet Hastanesi", LocationId = "36" },
    new Hospital { HospitalId = "40", Name = "Sağlık Bilimleri Üniversitesi Ümraniye Eğitim ve Araştırma Hastanesi", LocationId = "37" },
    new Hospital { HospitalId = "22", Name = "Üsküdar Devlet Hastanesi", LocationId = "38" },
    new Hospital { HospitalId = "41", Name = "İstanbul Eğitim ve Araştırma Hastanesi Zeytinburnu Polikliniği", LocationId = "39" }
            };
            context.Hospitals.AddRange(hospitals);

            var departments = new List<Department>();
            foreach (var hospital in hospitals)
            {
                var departmentIdCounter = 1;
                var departmentNames = new List<string>
                {
                    // Bölüm isimleri buraya eklenecek.
                     "Cardiology", "Orthopedics", "Neurology", "Pediatrics", "Oncology",
            "Gynecology", "Dermatology", "ENT (Ear, Nose, Throat)", "Ophthalmology",
            "Urology", "Pulmonology", "Gastroenterology", "Hematology", "Endocrinology",
            "Rheumatology", "Nephrology", "Psychiatry", "Radiology", "Pathology",
            "Anesthesiology", "Emergency Medicine", "Physical Therapy", "Oncologic Surgery",
            "Cardiac Surgery", "Neurosurgery", "Plastic Surgery", "General Surgery",
            "Vascular Surgery", "Ophthalmic Surgery", "Orthopedic Surgery", "Thoracic Surgery",
            "Urologic Surgery", "Dental Surgery", "Maxillofacial Surgery", "Otolaryngologic Surgery",
            "Obstetrics", "Cardiac Rehabilitation", "Pain Management", "Sleep Medicine",
            "Geriatrics", "Allergy and Immunology", "Intensive Care", "Infectious Diseases",
            "Palliative Care", "Rehabilitation", "Sports Medicine", "Nutrition and Dietetics",
            "Audiology", "Speech Therapy", "Clinical Psychology", "Medical Genetics",
            "Diagnostic Radiology", "Interventional Radiology", "Nuclear Medicine",
            "Forensic Medicine", "Clinical Microbiology", "Clinical Biochemistry",
            "Histopathology", "Laboratory Medicine", "Clinical Pharmacology",
            "Medical Oncology", "Pediatric Surgery", "Pediatric Neurology", "Pediatric Cardiology",
            "Pediatric Hematology", "Pediatric Endocrinology", "Pediatric Gastroenterology",
            "Pediatric Pulmonology", "Pediatric Infectious Diseases", "Pediatric Nephrology",
            "Pediatric Rheumatology", "Pediatric Allergy and Immunology", "Pediatric Genetics",
            "Pediatric Otolaryngology", "Pediatric Urology", "Pediatric Ophthalmology",
            "Pediatric Orthopedics", "Pediatric Oncology", "Pediatric Dentistry",
            "Pediatric Psychiatry", "Pediatric Dermatology"
                };

                foreach (var departmentName in departmentNames)
                {
                    departments.Add(new Department
                    {
                        DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}",
                        Name = departmentName,
                        HospitalId = hospital.HospitalId
                    });
                }
            }
            context.Departments.AddRange(departments);

            var doctorNames = new List<string>
            {
                // Doktor isimleri buraya eklenecek. // Doktor isimleri buraya eklenecek..d
                 "Ali Kemal",
    "Mehmet Aydın",
    "Ayşe Yılmaz",
    "Fatma Demir",
    "Ahmet Yıldız",
    "Zeynep Kaya",
    "Mustafa Güneş",
    "Selin Tekin",
    "Gözde Yılmaz",
    "Deniz Arslan",
    // Diğer doktor isimleri buraya eklenecek...
    "Sema Çelik",
    "Burak Arıkan",
    "Nergis Güler",
    "Yasin Demir",
    "Elif Şahin",
    "Kadir Aktaş",
    "Sevgi Öztürk",
    "Onur Yıldırım",
    "Gülşah Arslan",
    // Diğer doktor isimleri buraya eklenecek...
    "Ahmet Yılmaz",
    "Ayşe Demirci",
    "Mehmet Aksoy",
    "Fatma Toprak",
    "Hasan Yıldız",
    "Zeynep Kaya",
    "Şevket Erdoğan",
    "Selin Durmuş",
    "Canan Yaman",
    "Barış Güneş",
            };

            foreach (var hospital in hospitals)
{
    foreach (var department in departments.Where(d => d.HospitalId == hospital.HospitalId))
{
    foreach (var doctorName in doctorNames)
    {
        var doctor = new Doctor
        {
            DoctorId = Guid.NewGuid().ToString(), // Generate a unique identifier
            Name = doctorName,
            Email = $"{doctorName.Replace(" ", "").ToLower()}.{department.Name.Replace(" ", "").ToLower()}@health.com",
            Password = "abcdef",
            DepartmentId = department.DepartmentId
        };

        context.Doctors.Add(doctor);

        // Save changes to get the doctor's ID

        // Retrieve the doctor's ID
        var doctorId = doctor.DoctorId;

        // Create an appointment date with a unique identifier
        var appointmentDate = new AppointmentDate
        {
            AppointmentDateId = Guid.NewGuid().ToString(), // Generate a unique identifier
            Date = new DateTime(2024, 5, 20),
            DoctorId = doctorId
        };

        context.AppointmentDates.Add(appointmentDate);

        // Save changes to get the appointment date's ID

        // Retrieve the appointment date's ID
        var appointmentDateId = appointmentDate.AppointmentDateId;

        // Create appointment times
       foreach (var time in new[] { "10:00", "11:00", "12:00", "14:00", "15:00", "16:00" })
{
    var newTime = new AppointmentTime
    {
        AppointmentTimeId = Guid.NewGuid().ToString(), // Generate a unique identifier
        Time = TimeSpan.Parse(time),
        AppointmentDateId = appointmentDateId
    };
    context.AppointmentTimes.Add(newTime);
}


        // Save changes to the context
        
    }}}
    context.SaveChanges();
    }}
