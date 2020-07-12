namespace IConfigurationRootDtoLibraryTest.Models
{
    public class AppSettingsConfig
    {
        public string Option1 { get; set; }

        public int? Option2 { get; set; }

        public AOption A { get; set; }

        public BOption[] B { get; set; }
    }

    public class AOption
    {
        public string A1 { get; set; }
    }

    public class BOption
    {
        public string Name { get; set; }

        public int? Age { get; set; }
    }
}
