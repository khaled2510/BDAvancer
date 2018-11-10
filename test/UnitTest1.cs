using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using BDAvancer;


namespace test
{
    [TestClass]
    public class UnitTest1
    {
        CompanyContext _context;
        [TestMethod]
        [TestInitialize]
        public void TestMethod1()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

            DbContextOptions options = builder.UseSqlServer(@"Data Source=localhost; Initial catalog=Labo6; User Id=user; Password=user;").Options;
            _context = new CompanyContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.Customers.Add(new Customer(){
                    AddressLine1="Rue J. Calozet, 19",
                    PostCode="5000",
                    City="Namur",
                    AccountBalance=12,
                    Name="Doe",
                    Country="Belgique",
                    EMail="info@doe.com",
                    Remark="Client suspect"
            });
            _context.SaveChanges();
        }
    }
}
