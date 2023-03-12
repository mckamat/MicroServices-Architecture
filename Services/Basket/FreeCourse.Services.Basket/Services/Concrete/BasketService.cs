using FreeCourse.Services.Basket.Dtos;
using FreeCourse.Services.Basket.Services.Abstract;
using FreeCourse.Shared.Dtos;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreeCourse.Services.Basket.Services.Concrete
{
	public class BasketService : IBasketService
	{
		private readonly RedisService _redisService;
		public BasketService(RedisService redisService)
		{
			_redisService = redisService;
		}

		public async Task<Response<bool>> DeleteBasket(string userId)
		{
			var status = await _redisService.GetDb().KeyDeleteAsync(userId);
			return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket not found", 404);
		}

		public async Task<Response<BasketDto>> GetBasket(string userId)
		{
			var existBasket = await _redisService.GetDb().StringGetAsync(userId);
			if (string.IsNullOrEmpty(existBasket))
			{
				return Response<BasketDto>.Fail("Basket not found", 404);
			}
			return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), 200);
		}

		public async Task<Response<bool>> SaveOrUpdate(BasketDto basket)
		{
			var status = await _redisService.GetDb().StringSetAsync(basket.UserId, JsonSerializer.Serialize(basket));
			return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket could not update or save", 500);
		}
	}
}
