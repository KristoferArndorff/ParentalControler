using Common.Data;
using Common.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Parent.Areas.Account
{

    [Route("api/[controller]s")]
    public class ParentController : Controller
    {

        private readonly BaseDataContext _dataContext;

        public ParentController(BaseDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [Route("")]
        [HttpGet]
        public async Task<ParentDto> GetParent()
        {

            var parent = _dataContext.Parents.FirstOrDefault();

            if(parent == null)
            {
                return null;
            }

            return new ParentDto
            {
                Name = parent.Name,
                Email = parent.Email,
                Id = parent.Id,
                Created = parent.Created,
                Deleted = parent.Deleted,
                Updated = parent.Updated
            };
        }

        [Route("")]
        [HttpPost]
        public async Task<bool> UpdateParent()
        {
            return true;
        }

        [Route("")]
        [HttpDelete]
        public async Task<bool> DeleteParent()
        {
            return true;
        }
    }
}
