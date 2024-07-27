using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Repositories.Domain;
using CloudHRMS.Services;
using CloudHRMS.UnitOfWorks;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestCloudHRMS.Domain.Position
{
    public class PositionUnitTest
    {
        //creating mock object for unit test of positon services functions
        //step 1: create mock object of service
        public Mock<IPositionService> positionServiceMock = new Mock<IPositionService>();
        //step 2: create mock object of Unit Of Work 
        public Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
        //step 3: create mock object of Repository 
        public Mock<IPositionRepository> positionRepositoryMock = new Mock<IPositionRepository>();

        //Unit Testing for CRUD Process of Position Service 

        [Fact]
        public void CreateUnitTest()
        {
            // 1) Arrange
            string id = "123456";
            var expectedPositionViewModel = new PositionViewModel()
            {
                Id = id,
                Code = "HR",
                Name = "Human Resource MGR"
            };
            var dbPositonEntity = new PositionEntity()
            {
                Id = id,
                Code=expectedPositionViewModel.Code,
                Name=expectedPositionViewModel.Name,
            };
            positionRepositoryMock.Setup(r => r.Create(dbPositonEntity));//mock PositonRepository
            unitOfWorkMock.Setup(u => u.PositionRepository).Returns(positionRepositoryMock.Object);//mock the Unit Of Work
            //2) Act
            var positonservice = new PositionService(unitOfWorkMock.Object);//create  a service object with Unit Of work mock 
            //3) Assert 
            try
            {
                positonservice.Create(expectedPositionViewModel);
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }
        [Fact]
        public void GetAll()
        {
            //arrange
            IEnumerable<PositionViewModel> expectedResults = new List<PositionViewModel>()
            {
                new PositionViewModel{Id="xy1",Code="SE",Name="SE" },
                 new PositionViewModel{Id="xyx1",Code="SE",Name="SE"}
            };
            
            IEnumerable<PositionEntity> positionEntities = new List<PositionEntity>()
            {
                new PositionEntity{Id="xy1",Code="SE",Name="SE"},
                new PositionEntity{Id="xyx1",Code="SE",Name="SE"}
            };
            positionRepositoryMock.Setup(r=>r.GetAll()).Returns(positionEntities);
            unitOfWorkMock.Setup(u=>u.PositionRepository).Returns(() => positionRepositoryMock.Object);
            //act
            var positonService=new PositionService(unitOfWorkMock.Object);
            var actualResult=positonService.GetAll();
            //Assert
            var input=JsonConvert.SerializeObject(expectedResults);
            var output = JsonConvert.SerializeObject(actualResult);
            Assert.Equal(input, output);
        }
    }
}
