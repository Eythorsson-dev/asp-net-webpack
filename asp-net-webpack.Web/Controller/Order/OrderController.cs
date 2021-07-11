using asp_net_webpack.Controller;
using asp_net_webpack.Core.Request.Order;
using asp_net_webpack.Core.Service.Order;
using asp_net_webpack.Domain.Model.Order;
using asp_net_webpack.Web.Config.Mapper;
using asp_net_webpack.Web.Dto.Order;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_webpack.Web.Controller.Account.Order
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : BaseController
    {
        private OrderService OrderService => Services.OrderService;

        [HttpGet("")]
        public IActionResult GetPagedList([FromQuery] OrderFilterRequest request)
        {
            if (request == null) return BadRequest();

            var pagedItems = OrderService.GetPagedList(request);
            var dto = Mapper.MapPagedList<OrderDto>(pagedItems);

            return Ok(dto);
        }

        [HttpPost("{orderId}")]
        public IActionResult GetById([FromRoute] long orderId)
        {
            if (orderId < 1) return BadRequest();

            var request = new OrderFilterRequest { OrderId = orderId };
            var model = OrderService.FirstOrDefault(request);
            var dto = Mapper.Map<OrderDto>(model);

            return Ok(dto);
        }

        [HttpPost("")]
        public IActionResult Insert([FromBody] OrderDto dto)
        {
            var model = new OrderModel(dto.OrderNo, dto.ProductNo, dto.Quantity, dto.PriceExVat, dto.VatTotal,
                                        createdByUserId: CurrentUser.UserId);
            OrderService.Insert(model);

            return Ok();
        }

        //[HttpPost("{orderId}")]
        //public IActionResult Update([FromRoute] long orderId, [FromBody] OrderDto dto)
        //{
        //    if (orderId != dto.OrderId) return BadRequest();

        //    var model = OrderService.FirstOrDefault(new OrderFilterRequest { OrderId = dto.OrderId });
        //    model.PriceExVat = dto.PriceExVat;
        //    model.VatTotal = dto.VatTotal;

        //    OrderService.Update(model);

        //    return Ok(dto);
        //}
    }
}
