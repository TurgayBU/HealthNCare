/*using HealthNCare.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
namespace HealthNCare.Models{
    public class LocationContext : DbContext{
         public DbSet<Location> Locations { get; set; }
         public DbSet<Hospital> Hospitals{get;set;}
        public DbSet<Department> Departments { get; set; }

     public LocationContext(DbContextOptions<LocationContext>options):
     base (options){

     }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Location>()
        .HasKey(l=>l.LocationId);
        modelBuilder.Entity<Location>()
        .Property(l=>l.Name)
        .IsRequired();

        modelBuilder.Entity<Location>()
            .HasData(
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
            );
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hospital>()
            .HasOne(h=>h.Location)
            .WithMany(k=>k.Hospitals)
            .HasForeignKey(h=>h.LocationId);
            modelBuilder.Entity<Hospital>()
            .HasKey(l=>l.HospitalId);
           modelBuilder.Entity<Hospital>().HasData(
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

    // Diğer hastaneler buraya eklenecek...
    
   
);
base .OnModelCreating(modelBuilder);
          modelBuilder.Entity<Department>()
          .HasKey(k=>k.DepartmentId);
          modelBuilder.Entity<Department>()
        .HasOne(d => d.Hospital)
        .WithMany(h => h.Departments)
        .HasForeignKey(d => d.HospitalId);
     int departmentIdCounter = 1;
foreach (var hospital in Hospitals)
{
    for (int i = 1; i <= 82; i++)
    {
        modelBuilder.Entity<Department>().HasData(
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Cardiology", NameTurkish = "Kardiyoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Orthopedics", NameTurkish = "Ortopedi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Neurology", NameTurkish = "Nöroloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatrics", NameTurkish = "Pediatri", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Oncology", NameTurkish = "Onkoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Gynecology", NameTurkish = "Jinekoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Dermatology", NameTurkish = "Dermatoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "ENT (Ear, Nose, Throat)", NameTurkish = "Kulak Burun Boğaz", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Ophthalmology", NameTurkish = "Göz Hastalıkları", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Urology", NameTurkish = "Üroloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pulmonology", NameTurkish = "Göğüs Hastalıkları", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Gastroenterology", NameTurkish = "Gastroenteroloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Hematology", NameTurkish = "Hematoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Endocrinology", NameTurkish = "Endokrinoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Rheumatology", NameTurkish = "Romatoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Nephrology", NameTurkish = "Nefroloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Psychiatry", NameTurkish = "Psikiyatri", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Radiology", NameTurkish = "Radyoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pathology", NameTurkish = "Patoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Anesthesiology", NameTurkish = "Anesteziyoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Emergency Medicine", NameTurkish = "Acil Tıp", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Physical Therapy", NameTurkish = "Fizik Tedavi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Oncologic Surgery", NameTurkish = "Onkolojik Cerrahi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Cardiac Surgery", NameTurkish = "Kalp Cerrahisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Neurosurgery", NameTurkish = "Nöroşirürji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Plastic Surgery", NameTurkish = "Plastik Cerrahi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "General Surgery", NameTurkish = "Genel Cerrahi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Vascular Surgery", NameTurkish = "Damar Cerrahisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Ophthalmic Surgery", NameTurkish = "Göz Cerrahisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Orthopedic Surgery", NameTurkish = "Ortopedik Cerrahi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Thoracic Surgery", NameTurkish = "Torasik Cerrahi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Urologic Surgery", NameTurkish = "Ürolojik Cerrahi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Dental Surgery", NameTurkish = "Diş Cerrahisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Maxillofacial Surgery", NameTurkish = "Yüz Cerrahisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Otolaryngologic Surgery", NameTurkish = "Kulak Burun Boğaz Cerrahisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Obstetrics", NameTurkish = "Obstetrik", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Cardiac Rehabilitation", NameTurkish = "Kalp Rehabilitasyonu", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pain Management", NameTurkish = "Ağrı Yönetimi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Sleep Medicine", NameTurkish = "Uyku Tıbbı", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Geriatrics", NameTurkish = "Geriyatri", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Allergy and Immunology", NameTurkish = "Alerji ve İmmünoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Intensive Care", NameTurkish = "Yoğun Bakım", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Infectious Diseases", NameTurkish = "Enfeksiyon Hastalıkları", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Palliative Care", NameTurkish = "Palyatif Bakım", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Rehabilitation", NameTurkish = "Rehabilitasyon", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Sports Medicine", NameTurkish = "Spor Hekimliği", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Nutrition and Dietetics", NameTurkish = "Beslenme ve Diyetetik", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Audiology", NameTurkish = "Audiyoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Speech Therapy", NameTurkish = "Konuşma Terapisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Clinical Psychology", NameTurkish = "Klinik Psikoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Medical Genetics", NameTurkish = "Tıbbi Genetik", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Diagnostic Radiology", NameTurkish = "Tanısal Radyoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Interventional Radiology", NameTurkish = "Girişimsel Radyoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Nuclear Medicine", NameTurkish = "Nükleer Tıp", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Forensic Medicine", NameTurkish = "Adli Tıp", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Clinical Microbiology", NameTurkish = "Klinik Mikrobiyoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Clinical Biochemistry", NameTurkish = "Klinik Biyokimya", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Histopathology", NameTurkish = "Histopatoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Laboratory Medicine", NameTurkish = "Laboratuvar Tıbbı", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Clinical Pharmacology", NameTurkish = "Klinik Farmakoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Medical Oncology", NameTurkish = "Tıbbi Onkoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Surgery", NameTurkish = "Çocuk Cerrahisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Neurology", NameTurkish = "Çocuk Nörolojisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Cardiology", NameTurkish = "Çocuk Kardiyolojisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Hematology", NameTurkish = "Çocuk Hematolojisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Endocrinology", NameTurkish = "Çocuk Endokrinolojisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Gastroenterology", NameTurkish = "Çocuk Gastroenterolojisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Pulmonology", NameTurkish = "Çocuk Göğüs Hastalıkları", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Infectious Diseases", NameTurkish = "Çocuk Enfeksiyon Hastalıkları", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Nephrology", NameTurkish = "Çocuk Nefrolojisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Rheumatology", NameTurkish = "Çocuk Romatolojisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Allergy and Immunology", NameTurkish = "Çocuk Alerji ve İmmünoloji", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Genetics", NameTurkish = "Çocuk Genetik", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Otolaryngology", NameTurkish = "Çocuk Kulak Burun Boğaz Hastalıkları", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Urology", NameTurkish = "Çocuk Ürolojisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Ophthalmology", NameTurkish = "Çocuk Göz Hastalıkları", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Orthopedics", NameTurkish = "Çocuk Ortopedisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Oncology", NameTurkish = "Çocuk Onkolojisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Dentistry", NameTurkish = "Çocuk Diş Hekimliği", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Psychiatry", NameTurkish = "Çocuk Psikiyatrisi", HospitalId = hospital.HospitalId },
            new Department { DepartmentId = $"{hospital.HospitalId}-{departmentIdCounter++}", NameEnglish = "Pediatric Dermatology", NameTurkish = "Çocuk Dermatolojisi", HospitalId = hospital.HospitalId }
            // Diğer departmanlar buraya eklenecek...
        );
    }
}
    }}}
public class Generator{
    
}*/