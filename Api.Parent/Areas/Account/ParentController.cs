using Common.Data;
using Common.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [Route("{id}")]
        [HttpGet]
        public async Task<ParentDto> GetParent(int id)
        {

            var parent = await _dataContext.Parents.Where(x => !x.Deleted.HasValue).FirstOrDefaultAsync(x => x.Id == id);

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
        [HttpGet]
        public async Task<List<ParentDto>> GetParents()
        {

            return await _dataContext.Parents.Where(x => !x.Deleted.HasValue).Select(parent => new ParentDto
            {
                Name = parent.Name,
                Email = parent.Email,
                Id = parent.Id,
                Created = parent.Created,
                Deleted = parent.Deleted,
                Updated = parent.Updated
            }).ToListAsync();
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
