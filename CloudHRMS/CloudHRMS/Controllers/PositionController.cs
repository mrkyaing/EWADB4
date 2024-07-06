using CloudHRMS.DAO;
using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace CloudHRMS.Controllers
{
    public class PositionController : Controller
    {      
        private readonly CloudHRMSApplicationDbContext _dbContext;
        //constcutror injection for ApplicationDbContext
        public PositionController(CloudHRMSApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(PositionViewModel positionViewModel)
        {
            try
            {
                //Data Exchange from view Model to Entity
                PositionEntity positionEntity = new PositionEntity()
                {
                    Id = Guid.NewGuid().ToString(),//new random 36 char string ...
                    Code = positionViewModel.Code,
                    Name = positionViewModel.Name,
                    Level = positionViewModel.Level,
                };
                _dbContext.Positions.Add(positionEntity);//add the entity to the dbContext.
                _dbContext.SaveChanges();//saving the record to the database.
                ViewData["Info"] = "Successfully save the recrod to the system.";
                ViewData["Status"] = true;
            }
            catch (Exception e)
            {
                ViewData["Info"] = "Error occur when the recrod save to the system."+e.Message;
                ViewData["Status"] = false;
            }
            return View();
        }
    }
}
