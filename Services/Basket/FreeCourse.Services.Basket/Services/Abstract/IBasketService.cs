using FreeCourse.Services.Basket.Dtos;
using FreeCourse.Shared.Dtos;
using System.Threading.Tasks;

namespace FreeCourse.Services.Basket.Services.Abstract
{
	public interface IBasketService
	{
		Task<Response<BasketDto>> GetBasket(string userId);
		Task<Response<bool>>SaveOrUpdate(BasketDto basket);
		Task<Response<bool>> DeleteBasket(string userId);
	}
}
