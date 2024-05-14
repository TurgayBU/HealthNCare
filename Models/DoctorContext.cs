
using HealthNCare.Models;
using Microsoft.EntityFrameworkCore;
/*
public class DoctorContext : DbContext{
       public DbSet<Doctor> Doctors { get; set; }
        public DoctorContext(DbContextOptions<DoctorContext> options ) : base (options){

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>()
        .HasOne(d => d.Hospital)
        .WithMany(h => h.Departments)
        .HasForeignKey(d => d.HospitalId);
            modelBuilder.Entity<Doctor>()
            .HasData( 
                new Doctor {DoctorId="1",Name="Ali Kemal",Email="alikemal@health.com",Password="123456",DepartmentId="1"},
              new Doctor {DoctorId="61",Name="Ali Kemal",Email="alikemal.neurology@health.com",Password="123456",DepartmentId="3"},
new Doctor {DoctorId="2",Name="Mehmet Aydın",Email="mehmetaydin.cardiology@health.com",Password="654321",DepartmentId="1"},
new Doctor {DoctorId="3",Name="Ayşe Yılmaz",Email="ayseyilmaz.orthopedics@health.com",Password="abcdef",DepartmentId="2"},
new Doctor {DoctorId="4",Name="Fatma Demir",Email="fatmademir.pediatrics@health.com",Password="abcdef",DepartmentId="4"},
new Doctor {DoctorId="5",Name="Ahmet Yıldız",Email="ahmetyildiz.oncology@health.com",Password="abcdef",DepartmentId="5"},
new Doctor {DoctorId="6",Name="Zeynep Kaya",Email="zeynepkaya.gynecology@health.com",Password="abcdef",DepartmentId="6"},
new Doctor {DoctorId="7",Name="Mustafa Güneş",Email="mustafagunes.dermatology@health.com",Password="abcdef",DepartmentId="7"},
new Doctor {DoctorId="8",Name="Selin Tekin",Email="selintekin.ent@health.com",Password="abcdef",DepartmentId="8"},
new Doctor {DoctorId="9",Name="Gözde Yılmaz",Email="gozdeyilmaz.ophthalmology@health.com",Password="abcdef",DepartmentId="9"},
new Doctor {DoctorId="10",Name="Deniz Arslan",Email="denizarslan.urology@health.com",Password="abcdef",DepartmentId="10"},
// Devam edebilir...
new Doctor {DoctorId="11",Name="Emre Taşkın",Email="emretaskin.pulmonology@health.com",Password="abcdef",DepartmentId="11"},
new Doctor {DoctorId="12",Name="Sema Çelik",Email="semacelik.gastroenterology@health.com",Password="abcdef",DepartmentId="12"},
new Doctor {DoctorId="13",Name="Burak Arıkan",Email="burakarikan.hematology@health.com",Password="abcdef",DepartmentId="13"},
new Doctor {DoctorId="14",Name="Nergis Güler",Email="nergisguler.endocrinology@health.com",Password="abcdef",DepartmentId="14"},
new Doctor {DoctorId="15",Name="Yasin Demir",Email="yasindemir.rheumatology@health.com",Password="abcdef",DepartmentId="15"},
new Doctor {DoctorId="16",Name="Elif Şahin",Email="elifsahin.nephrology@health.com",Password="abcdef",DepartmentId="16"},
new Doctor {DoctorId="17",Name="Kadir Aktaş",Email="kadiraktas.psychiatry@health.com",Password="abcdef",DepartmentId="17"},
new Doctor {DoctorId="18",Name="Sevgi Öztürk",Email="sevgiozturk.radiology@health.com",Password="abcdef",DepartmentId="18"},
new Doctor {DoctorId="19",Name="Onur Yıldırım",Email="onuryildirim.pathology@health.com",Password="abcdef",DepartmentId="19"},
new Doctor {DoctorId="20",Name="Gülşah Arslan",Email="gulsaharslan.anesthesiology@health.com",Password="abcdef",DepartmentId="20"},
// Devam edebilir...
new Doctor {DoctorId="21",Name="Ahmet Yılmaz",Email="ahmetyilmaz.emergencymedicine@health.com",Password="abcdef",DepartmentId="21"},
new Doctor {DoctorId="22",Name="Ayşe Demirci",Email="aysedemirci.physicaltherapy@health.com",Password="abcdef",DepartmentId="22"},
new Doctor {DoctorId="23",Name="Mehmet Aksoy",Email="mehmetaksoy.oncologicsurgery@health.com",Password="abcdef",DepartmentId="23"},
new Doctor {DoctorId="24",Name="Fatma Toprak",Email="fatmatoprak.cardiacsurgery@health.com",Password="abcdef",DepartmentId="24"},
new Doctor {DoctorId="25",Name="Hasan Yıldız",Email="hasanyildiz.neurosurgery@health.com",Password="abcdef",DepartmentId="25"},
new Doctor {DoctorId="26",Name="Zeynep Kaya",Email="zeynepkaya.plasticsurgery@health.com",Password="abcdef",DepartmentId="26"},
new Doctor {DoctorId="27",Name="Şevket Erdoğan",Email="sevket.erdogan.generalsurgery@health.com",Password="abcdef",DepartmentId="27"},
new Doctor {DoctorId="28",Name="Selin Durmuş",Email="selindurmus.vascularsurgery@health.com",Password="abcdef",DepartmentId="1"},
new Doctor {DoctorId="29",Name="Canan Yaman",Email="cananyaman.ophthalmicsurgery@health.com",Password="abcdef",DepartmentId="2"},
new Doctor {DoctorId="30",Name="Barış Güneş",Email="barisgunes.orthopedicsurgery@health.com",Password="abcdef",DepartmentId="3"},
new Doctor {DoctorId="31",Name="Deniz Yılmaz",Email="denizyilmaz.emergencymedicine@health.com",Password="abcdef",DepartmentId="4"},
new Doctor {DoctorId="32",Name="Mehmet Özdemir",Email="mehmetozdemir.physicaltherapy@health.com",Password="abcdef",DepartmentId="5"},
new Doctor {DoctorId="33",Name="Ayşe Kaya",Email="aysekaya.oncologicsurgery@health.com",Password="abcdef",DepartmentId="6"},
new Doctor {DoctorId="34",Name="Ahmet Yıldız",Email="ahmetyildiz.cardiacsurgery@health.com",Password="abcdef",DepartmentId="7"},
new Doctor {DoctorId="35",Name="Zeynep Demir",Email="zeynepdemir.neurosurgery@health.com",Password="abcdef",DepartmentId="8"},
new Doctor {DoctorId="36",Name="Murat Topçu",Email="murattopcu.plasticsurgery@health.com",Password="abcdef",DepartmentId="9"},
new Doctor {DoctorId="37",Name="Ebru Aksoy",Email="ebruaksoy.generalsurgery@health.com",Password="abcdef",DepartmentId="10"},
new Doctor {DoctorId="38",Name="Cem Korkmaz",Email="cemkorkmaz.vascularsurgery@health.com",Password="abcdef",DepartmentId="11"},
new Doctor {DoctorId="39",Name="Zehra Yılmaz",Email="zehrayilmaz.ophthalmicsurgery@health.com",Password="abcdef",DepartmentId="12"},
new Doctor {DoctorId="40",Name="Emine Çelik",Email="eminecelik.orthopedicsurgery@health.com",Password="abcdef",DepartmentId="13"},
new Doctor {DoctorId="41",Name="Mehmet Demir",Email="mehmetdemir.thoracicsurgery@health.com",Password="abcdef",DepartmentId="14"},
new Doctor {DoctorId="42",Name="Aylin Kaya",Email="aylinkaya.urologicsurgery@health.com",Password="abcdef",DepartmentId="15"},
new Doctor {DoctorId="43",Name="Serkan Yılmaz",Email="serkanyilmaz.dentalsurgery@health.com",Password="abcdef",DepartmentId="16"},
new Doctor {DoctorId="44",Name="Fatma Akın",Email="fatmaakin.maxillofacialsurgery@health.com",Password="abcdef",DepartmentId="17"},
new Doctor {DoctorId="45",Name="Berkay Öztürk",Email="berkayozturk.otolaryngologicsurgery@health.com",Password="abcdef",DepartmentId="18"},
new Doctor {DoctorId="46",Name="Selin Kocaman",Email="selinkocaman.obstetrics@health.com",Password="abcdef",DepartmentId="19"},
new Doctor {DoctorId="47",Name="Caner Yıldırım",Email="caneryildirim.cardiacrehabilitation@health.com",Password="abcdef",DepartmentId="20"},
new Doctor {DoctorId="48",Name="Nazlı Arıcı",Email="nazliarici.painmanagement@health.com",Password="abcdef",DepartmentId="21"},
new Doctor {DoctorId="49",Name="Tolga Aktaş",Email="tolgaaktas.sleepmedicine@health.com",Password="abcdef",DepartmentId="22"},
new Doctor {DoctorId="50",Name="Elif Özcan",Email="elifozcan.geriatrics@health.com",Password="abcdef",DepartmentId="23"},
new Doctor {DoctorId="51",Name="Mert Kılıç",Email="mertkilic.allergyandimmunology@health.com",Password="abcdef",DepartmentId="24"},
new Doctor {DoctorId="52",Name="Melis Çakır",Email="meliscakir.intensivecare@health.com",Password="abcdef",DepartmentId="25"},
new Doctor {DoctorId="53",Name="Ege Yılmaz",Email="egeyilmaz.infectiousdiseases@health.com",Password="abcdef",DepartmentId="26"},
new Doctor {DoctorId="54",Name="Ezgi Koç",Email="ezgikoc.palliativecare@health.com",Password="abcdef",DepartmentId="27"},
new Doctor {DoctorId="55",Name="Bora Tekin",Email="boratekin.rehabilitation@health.com",Password="abcdef",DepartmentId="2"},
new Doctor {DoctorId="56",Name="Gizem Arslan",Email="gizemarslan.sportsmedicine@health.com",Password="abcdef",DepartmentId="1"},
new Doctor {DoctorId="57",Name="Cihan Demir",Email="cihandemir.nutritionanddietetics@health.com",Password="abcdef",DepartmentId="3"},
new Doctor {DoctorId="58",Name="Yeliz Erdoğan",Email="yelizerdogan.midwifery@health.com",Password="abcdef",DepartmentId="3"},
new Doctor {DoctorId="59",Name="İsmail Kaya",Email="ismailkaya.anesthesia@health.com",Password="abcdef",DepartmentId="4"},
new Doctor {DoctorId="60",Name="Selin Kılıç",Email="selinkilic.radiationoncology@health.com",Password="abcdef",DepartmentId="5"}
// Daha fazla doktor ekleyebilirsiniz...

// Devam edebilir...

            );
        }
    }*/