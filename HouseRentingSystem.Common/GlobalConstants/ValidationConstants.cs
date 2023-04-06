namespace HouseRentingSystem.Common.GlobalConstants
{
    public static class ValidationConstants
    {
        public static class Agent
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }

        public static class Category
        {
            public const int NameMaxLength = 50;
        }

        public static class House
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int AddressMinLength = 15;
            public const int AddressMaxLength = 150;

            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;

            public const string PriceMinLength = "0.00";
            public const string PriceMaxLength = "2000.00";
        }

        public static class User
        {

        }
    }
}
