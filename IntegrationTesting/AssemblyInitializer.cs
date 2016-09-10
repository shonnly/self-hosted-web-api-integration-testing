namespace IntegrationTesting
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WebLayer.Controllers;

    [TestClass]
    public class AssemblyInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // this is a hack to assure the loading of the referenced ApiController assembly
            var dummy = new ValuesController(null);
            dummy.Dispose();
            dummy = null;
        }
    }
}
