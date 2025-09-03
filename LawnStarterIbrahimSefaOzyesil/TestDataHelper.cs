
namespace LawnStarterIbrahimSefaOzyesil.Helpers
{
    public static class TestDataHelper
    {
        private static readonly Bogus.Faker faker = new Bogus.Faker();
        public static string FullName => faker.Name.FullName();
        public static string FirstName => faker.Name.FirstName();
        public static string LastName => faker.Name.LastName();
        public static string Email => faker.Internet.Email();
        public static string RandomFullName() => faker.Name.FullName();
        public static string RandomLastName() => faker.Name.LastName();
        public static string RandomEmail() => faker.Internet.Email();
        public static string CardNumber => "4111111111111111";
        public static string Expiry => DateTime.Now.AddYears(1).ToString("MM/yy");
        public static string CVV => new Random().Next(100, 999).ToString();
        public static DateTime FutureDate(int monthsAhead)
        {
            return DateTime.Today.AddMonths(monthsAhead);
        }       
    }
}