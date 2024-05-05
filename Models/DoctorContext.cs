using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
namespace HealthNCare.Models{
    public class LocationContext : DbContext{
         public DbSet<Location> Locations { get; set; }

     public LocationContext(DbContextOptions<LocationContext>options):
     base (options){

     }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Location>()
            .HasData(
            new Location { LocationId = 1, Name = "Adalar" },
new Location { LocationId = 2, Name = "Arnavutköy" },
new Location { LocationId = 3, Name = "Ataşehir" },
new Location { LocationId = 4, Name = "Avcılar" },
new Location { LocationId = 5, Name = "Bağcılar" },
new Location { LocationId = 6, Name = "Bahçelievler" },
new Location { LocationId = 7, Name = "Bakırköy" },
new Location { LocationId = 8, Name = "Başakşehir" },
new Location { LocationId = 9, Name = "Bayrampaşa" },
new Location { LocationId = 10, Name = "Beşiktaş" },
new Location { LocationId = 11, Name = "Beykoz" },
new Location { LocationId = 12, Name = "Beylikdüzü" },
new Location { LocationId = 13, Name = "Beyoğlu" },
new Location { LocationId = 14, Name = "Büyükçekmece" },
new Location { LocationId = 15, Name = "Çatalca" },
new Location { LocationId = 16, Name = "Çekmeköy" },
new Location { LocationId = 17, Name = "Esenler" },
new Location { LocationId = 18, Name = "Esenyurt" },
new Location { LocationId = 19, Name = "Eyüp" },
new Location { LocationId = 20, Name = "Fatih" },
new Location { LocationId = 21, Name = "Gaziosmanpaşa" },
new Location { LocationId = 22, Name = "Güngören" },
new Location { LocationId = 23, Name = "Kadıköy" },
new Location { LocationId = 24, Name = "Kağıthane" },
new Location { LocationId = 25, Name = "Kartal" },
new Location { LocationId = 26, Name = "Küçükçekmece" },
new Location { LocationId = 27, Name = "Maltepe" },
new Location { LocationId = 28, Name = "Pendik" },
new Location { LocationId = 29, Name = "Sancaktepe" },
new Location { LocationId = 30, Name = "Sarıyer" },
new Location { LocationId = 31, Name = "Silivri" },
new Location { LocationId = 32, Name = "Sultanbeyli" },
new Location { LocationId = 33, Name = "Sultangazi" },
new Location { LocationId = 34, Name = "Şile" },
new Location { LocationId = 35, Name = "Şişli" },
new Location { LocationId = 36, Name = "Tuzla" },
new Location { LocationId = 37, Name = "Ümraniye" },
new Location { LocationId = 38, Name = "Üsküdar" },
new Location { LocationId = 39, Name = "Zeytinburnu" }

            );

        }

    }
     public class HospitalContext : DbContext{

         public DbSet<Hospital> Hospitals { get; set; }
         public HospitalContext(DbContextOptions<HospitalContext>options):base
         (options){
  

         }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hospital>().HasData(
               new Hospital
{
    HospitalId = 1,
    Name = "Arnavutköy Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 2, Name = "Arnavutköy" } }
},
new Hospital
{
    HospitalId = 2,
    Name = "Avcılar Murat Kölük Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 4, Name = "Avcılar" } }
},
new Hospital
{
    HospitalId = 3,
    Name = "Başakşehir Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 8, Name = "Başakşehir" } }
},
new Hospital
{
    HospitalId = 4,
    Name = "Bahçelievler Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 6, Name = "Bahçelievler" } }
},
new Hospital
{
    HospitalId = 5,
    Name = "Bayrampaşa Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 9, Name = "Bayrampaşa" } }
},
new Hospital
{
    HospitalId = 6,
    Name = "Beşiktaş Sait Çiftçi Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 10, Name = "Beşiktaş" } }
},
new Hospital
{
    HospitalId = 7,
    Name = "Beykoz Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 11, Name = "Beykoz" } }
},
new Hospital
{
    HospitalId = 8,
    Name = "Büyükçekmece Mimar Sinan Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 14, Name = "Büyükçekmece" } }
},
new Hospital
{
    HospitalId = 9,
    Name = "Çatalca İlyas Çokay Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 15, Name = "Çatalca" } }
},
new Hospital
{
    HospitalId = 10,
    Name = "Esenyurt Necmi Kadıoğlu Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 18, Name = "Esenyurt" } }
},
new Hospital
{
    HospitalId = 11,
    Name = "Eyüpsultan Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 19, Name = "Eyüp" } }
},
new Hospital
{
    HospitalId = 12,
    Name = "İstinye Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 20, Name = "Fatih" } }
},
new Hospital
{
    HospitalId = 13,
    Name = "Kağıthane Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 24, Name = "Kağıthane" } }
},
new Hospital
{
    HospitalId = 14,
    Name = "Küçükçekmece Kanuni Sultan Süleyman Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 26, Name = "Küçükçekmece" } }
},
new Hospital
{
    HospitalId = 15,
    Name = "Maltepe Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 27, Name = "Maltepe" } }
},
new Hospital
{
    HospitalId = 16,
    Name = "Pendik Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 28, Name = "Pendik" } }
},
new Hospital
{
    HospitalId = 17,
    Name = "Tuzla Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 36, Name = "Tuzla" } }
},
new Hospital
{
    HospitalId = 18,
    Name = "Silivri Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 31, Name = "Silivri" } }
},
new Hospital
{
    HospitalId = 19,
    Name = "Esenler Kadın Doğum ve Çocuk Hastalıkları Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 17, Name = "Esenler" } }
},
new Hospital
{
    HospitalId = 20,
    Name = "Sultanbeyli Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 32, Name = "Sultanbeyli" } }
},
new Hospital
{
    HospitalId = 21,
    Name = "Şile Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 34, Name = "Şile" } }
},
new Hospital
{
    HospitalId = 22,
    Name = "Üsküdar Devlet Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 38, Name = "Üsküdar" } }
},
new Hospital
{
    HospitalId = 23,
    Name = "S.B.Ü. Bağcılar Eğitim ve Araştırma Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 5, Name = "Bağcılar" } }
},
new Hospital
{
    HospitalId = 24,
    Name = "S.B.Ü. Prof. Dr. Mazhar Osman Ruh ve Sinir Hastalıkları Eğitim ve Araştırma Hastanesi, Bakırköy",
    Locations = new List<Location> { new Location { LocationId = 7, Name = "Bakırköy" } }
},
new Hospital
{
    HospitalId = 25,
    Name = "S.B.Ü. Bakırköy Dr. Sadi Konuk Eğitim ve Araştırma Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 7, Name = "Bakırköy" } }
},
new Hospital
{
    HospitalId = 26,
    Name = "S.B.Ü. Metin Sabancı Baltalimanı Kemik Hastalıkları Eğitim ve Araştırma Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 3, Name = "Baltalimanı" } }
},
new Hospital
{
    HospitalId = 27,
    Name = "S.B.Ü. Erenköy Ruh ve Sinir Hastalıkları Eğitim ve Araştırma Hastanesi",
    Locations = new List<Location> { new Location { LocationId = 23, Name = "Erenköy" } }
}



            );
        }
    }
    public class DepartmentContext : DbContext{
         public DbSet<Department> Departments { get; set; }
         public DepartmentContext(DbContextOptions<DepartmentContext>options):
         base(options){

         }
         protected override void OnModelCreating(ModelBuilder modelBuilder){
          base .OnModelCreating(modelBuilder);
          modelBuilder.Entity<Department>().HasData(

            new Department { DepartmentId = 1, NameEnglish = "Cardiology", NameTurkish = "Kardiyoloji" },
            new Department { DepartmentId = 2, NameEnglish = "Orthopedics", NameTurkish = "Ortopedi" },
            new Department { DepartmentId = 3, NameEnglish = "Neurology", NameTurkish = "Nöroloji" },
            new Department { DepartmentId = 4, NameEnglish = "Pediatrics", NameTurkish = "Pediatri" },
            new Department { DepartmentId = 5, NameEnglish = "Oncology", NameTurkish = "Onkoloji" },
            new Department { DepartmentId = 6, NameEnglish = "Gynecology", NameTurkish = "Jinekoloji" },
            new Department { DepartmentId = 7, NameEnglish = "Dermatology", NameTurkish = "Dermatoloji" },
            new Department { DepartmentId = 8, NameEnglish = "ENT (Ear, Nose, Throat)", NameTurkish = "Kulak Burun Boğaz" },
            new Department { DepartmentId = 9, NameEnglish = "Ophthalmology", NameTurkish = "Göz Hastalıkları" },
            new Department { DepartmentId = 10, NameEnglish = "Urology", NameTurkish = "Üroloji" },
            new Department { DepartmentId = 11, NameEnglish = "Pulmonology", NameTurkish = "Göğüs Hastalıkları" },
            new Department { DepartmentId = 12, NameEnglish = "Gastroenterology", NameTurkish = "Gastroenteroloji" },
            new Department { DepartmentId = 13, NameEnglish = "Hematology", NameTurkish = "Hematoloji" },
            new Department { DepartmentId = 14, NameEnglish = "Endocrinology", NameTurkish = "Endokrinoloji" },
            new Department { DepartmentId = 15, NameEnglish = "Rheumatology", NameTurkish = "Romatoloji" },
            new Department { DepartmentId = 16, NameEnglish = "Nephrology", NameTurkish = "Nefroloji" },
            new Department { DepartmentId = 17, NameEnglish = "Psychiatry", NameTurkish = "Psikiyatri" },
            new Department { DepartmentId = 18, NameEnglish = "Radiology", NameTurkish = "Radyoloji" },
            new Department { DepartmentId = 19, NameEnglish = "Pathology", NameTurkish = "Patoloji" },
            new Department { DepartmentId = 20, NameEnglish = "Anesthesiology", NameTurkish = "Anesteziyoloji" },
            new Department { DepartmentId = 21, NameEnglish = "Emergency Medicine", NameTurkish = "Acil Tıp" },
            new Department { DepartmentId = 22, NameEnglish = "Physical Therapy", NameTurkish = "Fizik Tedavi" },
            new Department { DepartmentId = 23, NameEnglish = "Oncologic Surgery", NameTurkish = "Onkolojik Cerrahi" },
            new Department { DepartmentId = 24, NameEnglish = "Cardiac Surgery", NameTurkish = "Kalp Cerrahisi" },
            new Department { DepartmentId = 25, NameEnglish = "Neurosurgery", NameTurkish = "Nöroşirürji" },
            new Department { DepartmentId = 26, NameEnglish = "Plastic Surgery", NameTurkish = "Plastik Cerrahi" },
            new Department { DepartmentId = 27, NameEnglish = "General Surgery", NameTurkish = "Genel Cerrahi" },
            new Department { DepartmentId = 28, NameEnglish = "Vascular Surgery", NameTurkish = "Damar Cerrahisi" },
            new Department { DepartmentId = 29, NameEnglish = "Ophthalmic Surgery", NameTurkish = "Göz Cerrahisi" },
            new Department { DepartmentId = 30, NameEnglish = "Orthopedic Surgery", NameTurkish = "Ortopedik Cerrahi" },
            new Department { DepartmentId = 31, NameEnglish = "Thoracic Surgery", NameTurkish = "Torasik Cerrahi" },
            new Department { DepartmentId = 32, NameEnglish = "Urologic Surgery", NameTurkish = "Ürolojik Cerrahi" },
            new Department { DepartmentId = 33, NameEnglish = "Dental Surgery", NameTurkish = "Diş Cerrahisi" },
            new Department { DepartmentId = 34, NameEnglish = "Maxillofacial Surgery", NameTurkish = "Yüz Cerrahisi" },
            new Department { DepartmentId = 35, NameEnglish = "Otolaryngologic Surgery", NameTurkish = "Kulak Burun Boğaz Cerrahisi" },
            new Department { DepartmentId = 36, NameEnglish = "Obstetrics", NameTurkish = "Obstetrik" },
            new Department { DepartmentId = 37, NameEnglish = "Cardiac Rehabilitation", NameTurkish = "Kalp Rehabilitasyonu" },
            new Department { DepartmentId = 38, NameEnglish = "Pain Management", NameTurkish = "Ağrı Yönetimi" },
            new Department { DepartmentId = 39, NameEnglish = "Sleep Medicine", NameTurkish = "Uyku Tıbbı" },
            new Department { DepartmentId = 40, NameEnglish = "Geriatrics", NameTurkish = "Geriyatri" },
            new Department { DepartmentId = 41, NameEnglish = "Allergy and Immunology", NameTurkish = "Alerji ve İmmünoloji" },
            new Department { DepartmentId = 42, NameEnglish = "Intensive Care", NameTurkish = "Yoğun Bakım" },
            new Department { DepartmentId = 43, NameEnglish = "Infectious Diseases", NameTurkish = "Enfeksiyon Hastalıkları" },
            new Department { DepartmentId = 44, NameEnglish = "Palliative Care", NameTurkish = "Palyatif Bakım" },
            new Department { DepartmentId = 45, NameEnglish = "Rehabilitation", NameTurkish = "Rehabilitasyon" },
            new Department { DepartmentId = 46, NameEnglish = "Sports Medicine", NameTurkish = "Spor Hekimliği" },
            new Department { DepartmentId = 47, NameEnglish = "Nutrition and Dietetics", NameTurkish = "Beslenme ve Diyetetik" },
            new Department { DepartmentId = 48, NameEnglish = "Audiology", NameTurkish = "Audiyoloji" },
            new Department { DepartmentId = 49, NameEnglish = "Speech Therapy", NameTurkish = "Konuşma Terapisi" },
            new Department { DepartmentId = 50, NameEnglish = "Clinical Psychology", NameTurkish = "Klinik Psikoloji" },
            new Department { DepartmentId = 51, NameEnglish = "Medical Genetics", NameTurkish = "Tıbbi Genetik" },
            new Department { DepartmentId = 52, NameEnglish = "Diagnostic Radiology", NameTurkish = "Tanısal Radyoloji" },
            new Department { DepartmentId = 53, NameEnglish = "Interventional Radiology", NameTurkish = "Girişimsel Radyoloji" },
            new Department { DepartmentId = 54, NameEnglish = "Nuclear Medicine", NameTurkish = "Nükleer Tıp" },
            new Department { DepartmentId = 55, NameEnglish = "Forensic Medicine", NameTurkish = "Adli Tıp" },
            new Department { DepartmentId = 56, NameEnglish = "Clinical Microbiology", NameTurkish = "Klinik Mikrobiyoloji" },
            new Department { DepartmentId = 57, NameEnglish = "Clinical Biochemistry", NameTurkish = "Klinik Biyokimya" },
            new Department { DepartmentId = 58, NameEnglish = "Histopathology", NameTurkish = "Histopatoloji" },
            new Department { DepartmentId = 59, NameEnglish = "Laboratory Medicine", NameTurkish = "Laboratuvar Tıbbı" },
            new Department { DepartmentId = 60, NameEnglish = "Clinical Pharmacology", NameTurkish = "Klinik Farmakoloji" },
            new Department { DepartmentId = 61, NameEnglish = "Medical Oncology", NameTurkish = "Tıbbi Onkoloji" },
            new Department { DepartmentId = 62, NameEnglish = "Pediatric Surgery", NameTurkish = "Çocuk Cerrahisi" },
            new Department { DepartmentId = 63, NameEnglish = "Pediatric Neurology", NameTurkish = "Çocuk Nörolojisi" },
            new Department { DepartmentId = 64, NameEnglish = "Pediatric Cardiology", NameTurkish = "Çocuk Kardiyolojisi" },
            new Department { DepartmentId = 65, NameEnglish = "Pediatric Hematology", NameTurkish = "Çocuk Hematolojisi" },
            new Department { DepartmentId = 66, NameEnglish = "Pediatric Endocrinology", NameTurkish = "Çocuk Endokrinolojisi" },
            new Department { DepartmentId = 67, NameEnglish = "Pediatric Gastroenterology", NameTurkish = "Çocuk Gastroenterolojisi" },
            new Department { DepartmentId = 68, NameEnglish = "Pediatric Pulmonology", NameTurkish = "Çocuk Göğüs Hastalıkları" },
            new Department { DepartmentId = 69, NameEnglish = "Pediatric Infectious Diseases", NameTurkish = "Çocuk Enfeksiyon Hastalıkları" },
            new Department { DepartmentId = 70, NameEnglish = "Pediatric Nephrology", NameTurkish = "Çocuk Nefrolojisi" },
            new Department { DepartmentId = 71, NameEnglish = "Pediatric Rheumatology", NameTurkish = "Çocuk Romatolojisi" },
            new Department { DepartmentId = 72, NameEnglish = "Pediatric Allergy and Immunology", NameTurkish = "Çocuk Alerji ve İmmünoloji" },
            new Department { DepartmentId = 73, NameEnglish = "Pediatric Genetics", NameTurkish = "Çocuk Genetik" },
            new Department { DepartmentId = 74, NameEnglish = "Pediatric Otolaryngology", NameTurkish = "Çocuk Kulak Burun Boğaz Hastalıkları" },
            new Department { DepartmentId = 75, NameEnglish = "Pediatric Urology", NameTurkish = "Çocuk Ürolojisi" },
            new Department { DepartmentId = 76, NameEnglish = "Pediatric Ophthalmology", NameTurkish = "Çocuk Göz Hastalıkları" },
            new Department { DepartmentId = 77, NameEnglish = "Pediatric Orthopedics", NameTurkish = "Çocuk Ortopedisi" },
            new Department { DepartmentId = 78, NameEnglish = "Pediatric Oncology", NameTurkish = "Çocuk Onkolojisi" },
            new Department { DepartmentId = 79, NameEnglish = "Pediatric Dentistry", NameTurkish = "Çocuk Diş Hekimliği" },
            new Department { DepartmentId = 80, NameEnglish = "Pediatric Psychiatry", NameTurkish = "Çocuk Psikiyatrisi" },
            new Department { DepartmentId = 81, NameEnglish = "Pediatric Dermatology", NameTurkish = "Çocuk Dermatolojisi" }

          );

         }

    }
       
   
    public class DoctorContext : DbContext{
       public DbSet<Doctor> Doctors { get; set; }
        public DoctorContext(DbContextOptions<DoctorContext> options ) : base (options){

        }
       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>()
            .HasData( 
                
            );
        }*/
    }
    public class AppointmentContext : DbContext{

         public DbSet<Appointment> Appointments { get; set; }
         public AppointmentContext(DbContextOptions<AppointmentContext>options): base (options){
          
         }
    }
       
       
}