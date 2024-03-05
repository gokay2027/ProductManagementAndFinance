namespace ProductManagementAndFİnanceTest.CommandTests
{
    public class CommandTest
    {




        [Theory, InlineData(new object[] { "Diş Fırçası"
            , "Dişleri fırçalamak için alet"
            , 22,"USD" })]
        public void AddProductCommandTest(string name,
            string description, float price, string priceCurrency)
        {




        }
    }
}