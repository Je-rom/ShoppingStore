using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCartApi.Data;
using ShoppingCartApi.Models;
using ShoppingCartApi.Models.Dto;
using ShoppingCartApi.Models.DTO;

namespace ShoppingCartApi.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class ShoppingCartApiController : ControllerBase
    {
        private IMapper _mapper;
        private ResponseDto _response;
        private readonly AppDbContext _db;

        public ShoppingCartApiController(IMapper mapper, AppDbContext db)
        {
            _mapper = mapper;
            this._response = new ResponseDto();
            _db = db;
        }

        public async Task<ResponseDto> Upsert(CartDto cartDto)
        {
            try
            {
                var cartHeaderFromDb = await _db.CartHeaders.FirstOrDefaultAsync(u=>u.UserId == cartDto.CartHeader.UserId );
                if (cartHeaderFromDb == null)
                {
                    //create cart header and details 
                }
                else
                {
                    // if header is not null
                    // check if details has same product

                    var cartDetailsFromDb = await _db.CartDetails.FirstOrDefaultAsync(u => u.ProductId == cartDto.CartDetails.First().ProductId && u.CartHeaderId == cartHeaderFromDb.CartHeaderId);
                    if(cartDetailsFromDb == null)
                    {
                        //create cartdetails
                    }
                    else
                    {
                        // update count in the cart details
                    }
                }

            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }

        }
    }
}
