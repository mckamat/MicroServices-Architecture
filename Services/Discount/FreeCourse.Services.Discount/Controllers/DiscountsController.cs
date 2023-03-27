using FreeCourse.Services.Discount.Services.Abstract;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeCourse.Services.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : CustomBaseController
    {
        private readonly IDiscountService _discountService;
        private readonly ISharedIdentityService _sharedIdentity;
        public DiscountsController(IDiscountService discountService, ISharedIdentityService sharedIdentity)
        {
            _discountService = discountService;
            _sharedIdentity = sharedIdentity;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResultInstance(await _discountService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var discount = await _discountService.GetById(id);
            return CreateActionResultInstance(discount);
        }
        [HttpGet]
        [Route("/api/[controller]/GetByCode/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var userId = _sharedIdentity.GetUserId;
            var discount = await _discountService.GetByCodeWithUserId(code, userId);
            return CreateActionResultInstance(discount);
        }
        [HttpPost]
        public async Task<IActionResult> Save(Models.Discount discount)
        {
            return CreateActionResultInstance(await _discountService.Save(discount));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Models.Discount discount)
        {
            return CreateActionResultInstance(await _discountService.Update(discount));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResultInstance(await _discountService.Delete(id));
        }
    }
}
