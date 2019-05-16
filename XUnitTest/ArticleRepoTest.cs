
using NewsApp.Persistence;
using NewsApp.ReposInterfaces;
using NewsApp.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xunit;

/*Moq integration

PM> Install-Package EntityFrameworkCoreMock.Moq

*/
namespace UnitTest.XUnitTest
{
    public class ArticleRepoTest
    {


        string startupPath = Environment.CurrentDirectory;
        private readonly NewsAppDbContext dbContext;
        private readonly IArticleRepository repo;

        public ArticleRepoTest()
        {
            dbContext = new NewsAppDbContext();
            repo = new ArticleRepository(dbContext);
        }



        [Fact]
        public void FindArtistIdShouldReturnCorrect()
        {
            // Arrange
            var article = dbContext.Articles;

            // Act
            var actual = repo.GetAll();

            // Assert
            Assert.Equal(10, actual.Count());
        }
  


    }
}
