using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WD_API.Clients;
using WD_API.Extensions;
using WD_API.Model;

namespace WD_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IDynamoDbClient _dynamoDbClient;

        public AdminController(ILogger<AdminController> logger, IAmazonDynamoDB dynamoDb, IDynamoDbClient dynamoDbClient)
        {
            _logger = logger;
            _dynamoDbClient = dynamoDbClient;
        }

        [HttpGet("get/allordersbydate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllOrdersInfoByDate(string Date_Acco)
        {
            var result = await _dynamoDbClient.GetAllOrdersByDate(Date_Acco);

            if (result == null)
                return NotFound("Record doesn't exist in database");

            return Ok(result);
        }

        [HttpGet("get/ordersbyperiod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDataForAccounting(string startDate, string endDate)
        {
            var result = await _dynamoDbClient.GetDataForAccounting(startDate, endDate);

            if (result == null || result.Count == 0)
                return NotFound("No records found in the specified period");

            return Ok(result);
        }

        [HttpGet("get/infobyorderid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInfoByOrderId([FromQuery] string Order_Id)
        {
            var result = await _dynamoDbClient.GetInfoByOrderId(Order_Id);

            if (result == null)
                return NotFound("Record doesn't exist in database");

            var orderInfoResponse = new AccountingDbRepository
            {
                Order_Id = result.Order_Id,
                Summary = result.Summary,
                Price = result.Price,
                Date_Acco = result.Date_Acco,
                Time_Acco = result.Time_Acco,
                Address = result.Address,
                City = result.City, 
                Phone = result.Phone,   
                User_Id = result.User_Id
            };

            return Ok(orderInfoResponse);
        }

        [HttpGet("get/userinfobyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(string User_Id)
        {
            var result = await _dynamoDbClient.GetUserInfoById(User_Id);

            if (result == null)
                return NotFound("Record doesn't exist in database");

            var orderInfoResponse = new UserDbRepository
            {
                Phone = result.Phone, 
                City = result.City,
                Address = result.Address,
                Checker = result.Checker
            };

            return Ok(orderInfoResponse);
        }


        [HttpGet("get/userinfobyphone")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByPhone(string Phone)
        {
            var result = await _dynamoDbClient.GetUserInfoByPhone(Phone);

            if (result == null)
                return NotFound("Record doesn't exist in database");

            return Ok(result);
        }


        [HttpDelete("delete/orderinfo")]
        public async Task<IActionResult> Delete([FromQuery] string Order_Id)
        {
            var result = await _dynamoDbClient.GetInfoByOrderId(Order_Id);
            if (result == null)
                return NotFound("Record doesn't exist in database");
            await _dynamoDbClient.DeleteTrashOrder(Order_Id);

            return Ok();
        }


        [HttpPatch("update/checker")]
        public async Task<IActionResult> AddToDelivery([FromBody] UserStatusResponse mainOrder)
        {
            var data = new UserDbRepository
            {
                User_Id = mainOrder.User_Id,
                Checker = mainOrder.Checker
            };

            await _dynamoDbClient.UpdateDeliveryToDb(data);

            return Ok();
        }


        [HttpPatch("update/accounting")]
        public async Task<IActionResult> UpdateTotalOrderForAccounting([FromBody] AccountingDbRepository accountingOrder)
        {
            var data = new AccountingDbRepository
            {
                Order_Id = accountingOrder.Order_Id,
                Summary = accountingOrder.Summary,
                Price = accountingOrder.Price,
                Date_Acco = accountingOrder.Date_Acco,
                Time_Acco = accountingOrder.Time_Acco,
                Address = accountingOrder.Address,
                City = accountingOrder.City,
                Phone = accountingOrder.Phone,
                User_Id = accountingOrder.User_Id
            };

            await _dynamoDbClient.UpdateTotalOrderForAccounting(data);

            return Ok();
        }
    }
}
