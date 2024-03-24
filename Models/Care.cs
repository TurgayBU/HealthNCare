namespace HealthNCare.Models
{
    public static class Care
    {
        private static List<Patient> applications = new();
        public static IEnumerable<Patient> Applications => applications;
        public static void Add(Patient patient)
        {
            applications.Add(patient);
        }
    }

}