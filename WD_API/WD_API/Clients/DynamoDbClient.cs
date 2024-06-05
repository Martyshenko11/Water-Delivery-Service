using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using WD_API.Extensions;
using WD_API.Model;

namespace WD_API.Clients
{
    public class DynamoDbClient : IDynamoDbClient
    {
        public string _tableName;
        public string _ordertableName;
        public string _temptableName;
        public string _accountingtableName;

        private readonly IAmazonDynamoDB _dynamoDb;

        public DynamoDbClient(IAmazonDynamoDB dynamoDB)
        {
            _dynamoDb = dynamoDB;
            _tableName = Constants.TableName;
            _ordertableName = Constants.Order_TableName;
            _temptableName = Constants.Temp_TableName;
            _accountingtableName = Constants.Accounting_TableName;
        }


        public async Task<bool> PostOrderToDb(OrderDbRepository data)
        {
            var request = new PutItemRequest
            {
                TableName = _ordertableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    {"Order_Id", new AttributeValue { S = data.Order_Id } },
                    {"User_Id", new AttributeValue { S = data.User_Id } },
                    {"Water_Brand", new AttributeValue {S = data.Water_Brand } },
                    {"Volume", new AttributeValue {S = data.Volume } },
                    {"Num_Water", new AttributeValue {S = data.Num_Water } },
                    {"Price", new AttributeValue {S = data.Price } }
                }
            };

            try
            {
                var response = await _dynamoDb.PutItemAsync(request);

                return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                Console.WriteLine("Here is your error \n" + e);
                return false;
            }
        }


        public async Task UpdatePhoneToDb(UserDbRepository data)
        {
            var request = new UpdateItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    {"User_Id", new AttributeValue { S = data.User_Id } } 
                },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                {
                    {":newphone", new AttributeValue { S = data.Phone } }
                },
                UpdateExpression = "SET Phone = :newphone",
                ReturnValues = "ALL_NEW"
            };
            var response = await _dynamoDb.UpdateItemAsync(request);
        }


        public async Task UpdateDeliveryToDb(UserDbRepository data)
        {
            var request = new UpdateItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                 {
            { "User_Id", new AttributeValue { S = data.User_Id } }
          },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
          {
            { ":newchecker", new AttributeValue { S = data.Checker } }

          },
                UpdateExpression = "SET Checker = :newchecker",
                ReturnValues = "ALL_NEW"
            };

            var response = await _dynamoDb.UpdateItemAsync(request);
        }


        public async Task UpdateDataIntoDb(UserDbRepository data)
        {
            var request = new UpdateItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
          {
            { "User_Id", new AttributeValue { S = data.User_Id } }
          },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
          {
            { ":newcity", new AttributeValue { S = data.City } }

          },
                UpdateExpression = "SET City = :newcity",
                ReturnValues = "ALL_NEW"
            };

            var response = await _dynamoDb.UpdateItemAsync(request);
        }


        public async Task UpdateAddressIntoDb(UserDbRepository data)
        {
            var request = new UpdateItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
          {
            { "User_Id", new AttributeValue { S = data.User_Id } }
          },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
          {
            { ":newaddress", new AttributeValue { S = data.Address } }

          },
                UpdateExpression = "SET Address = :newaddress",
                ReturnValues = "ALL_NEW"
            };

            var response = await _dynamoDb.UpdateItemAsync(request);
        }


        public async Task UpdateBrandToDb(TempDbRepository data)
        {
            var request = new UpdateItemRequest
            {
                TableName = _temptableName,
                Key = new Dictionary<string, AttributeValue>
          {
            { "User_Id", new AttributeValue { S = data.User_Id } }
          },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
          {
            { ":newwaterbrand", new AttributeValue { S = data.Water_Brand } }

          },
                UpdateExpression = "SET Water_Brand = :newwaterbrand",
                ReturnValues = "ALL_NEW"
            };

            var response = await _dynamoDb.UpdateItemAsync(request);
        }


        public async Task UpdateVolumeToDb(TempDbRepository data)
        {
            var request = new UpdateItemRequest
            {
                TableName = _temptableName,
                Key = new Dictionary<string, AttributeValue>
          {
            { "User_Id", new AttributeValue { S = data.User_Id } }
          },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
          {
            { ":newvolume", new AttributeValue { S = data.Volume } }

          },
                UpdateExpression = "SET Volume = :newvolume",
                ReturnValues = "ALL_NEW"
            };

            var response = await _dynamoDb.UpdateItemAsync(request);
        }


        public async Task UpdateNumberToDb(TempDbRepository data)
        {
            var request = new UpdateItemRequest
            {
                TableName = _temptableName,
                Key = new Dictionary<string, AttributeValue>
          {
            { "User_Id", new AttributeValue { S = data.User_Id } }
          },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
          {
            { ":newnum_water", new AttributeValue { S = data.Num_Water } }
          },
                UpdateExpression = "SET Num_Water = :newnum_water",
                ReturnValues = "ALL_NEW"
            };

            var response = await _dynamoDb.UpdateItemAsync(request);
        }


        public async Task UpdateDateIntoOrder(OrderDbRepository data)
        {
            var request = new UpdateItemRequest
            {
                TableName = _ordertableName,
                Key = new Dictionary<string, AttributeValue>
          {
            { "Order_Id", new AttributeValue { S = data.Order_Id } }
          },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
          {
            { ":neworderdate", new AttributeValue { S = data.Order_Date } }

          },
                UpdateExpression = "SET Order_Date = :neworderdate",
                ReturnValues = "ALL_NEW"
            };

            var response = await _dynamoDb.UpdateItemAsync(request);
        }


        public async Task UpdateTimeIntoOrder(OrderDbRepository data)
        {
            var request = new UpdateItemRequest
            {
                TableName = _ordertableName,
                Key = new Dictionary<string, AttributeValue>
          {
            { "Order_Id", new AttributeValue { S = data.Order_Id } }
          },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
          {
            { ":newordertime", new AttributeValue { S = data.Order_Time } }

          },
                UpdateExpression = "SET Order_Time = :newordertime",
                ReturnValues = "ALL_NEW"
            };

            var response = await _dynamoDb.UpdateItemAsync(request);
        }

        public async Task UpdateTotalOrderForAccounting(AccountingDbRepository data)
        {
            var request = new UpdateItemRequest
            {
                TableName = _accountingtableName,
                Key = new Dictionary<string, AttributeValue>
          {
            { "Order_Id", new AttributeValue { S = data.Order_Id } }
          },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
          {
            { ":newsummary", new AttributeValue { S = data.Summary } },
            { ":newprice", new AttributeValue { S = data.Price } },
            { ":newdateacco", new AttributeValue { S = data.Date_Acco } },
            { ":newtimeacco", new AttributeValue { S = data.Time_Acco } },
            { ":newaddress", new AttributeValue { S = data.Address } },
            { ":newcityaddress", new AttributeValue { S = data.City } },
            { ":newphone", new AttributeValue { S = data.Phone } },
            { ":newuserid", new AttributeValue { S = data.User_Id } }

          },
                UpdateExpression = "SET Summary = :newsummary, Price = :newprice, Date_Acco = :newdateacco, Time_Acco = :newtimeacco, Address = :newaddress, " +
                "City = :newcityaddress, Phone = :newphone, User_Id = :newuserid",
                ReturnValues = "ALL_NEW"
            };

            var response = await _dynamoDb.UpdateItemAsync(request);
        }


        public async Task DeleteTrashOrder(string Order_Id)
        {
            var request = new DeleteItemRequest
            {
                TableName = _accountingtableName,

                Key = new Dictionary<string, AttributeValue>
                {
                     {"Order_Id", new AttributeValue { S = Order_Id }}
                }
                //ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                //{
                //  { ":userid", new AttributeValue { S = User_Id } }
                //},
                //ConditionExpression = "User_Id = :userid"

            };
            var response = await _dynamoDb.DeleteItemAsync(request);
            
        }


        public async Task DeleteFromTrashOrder(string Order_Id)
        {
            var request = new DeleteItemRequest
            {
                TableName = _ordertableName,

                Key = new Dictionary<string, AttributeValue>
                {
                     {"Order_Id", new AttributeValue { S = Order_Id }}
                }
                //ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                //{
                //  { ":userid", new AttributeValue { S = User_Id } }
                //},
                //ConditionExpression = "User_Id = :userid"

            };
            var response = await _dynamoDb.DeleteItemAsync(request);

        }

        public async Task<List<OrderTrashResponse>> GetOrderInfoByUser(string User_Id)
        {
            var request = new ScanRequest
            {
                TableName = _ordertableName,
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                {":userid", new AttributeValue { S = User_Id }}
   },
                FilterExpression = "User_Id = :userid"
            };

            var response = await _dynamoDb.ScanAsync(request);
            var db_items = response.Items;
            var result = new List<OrderTrashResponse>();

            foreach (var item in db_items)
            {
                var record = item.ToClass<OrderTrashResponse>();
                result.Add(record);
            }
            //if (response.Item == null || !response.IsItemSet)
            //    return null;

            //var result = response.Item.ToClass<OrderDbRepository>();

            return result;
        }


        public async Task<TempDbRepository> GetTempInfoByUser(string User_Id)
        {

            var item = new GetItemRequest
            {
                TableName = _temptableName,
                Key = new Dictionary<string, AttributeValue>
                    {
                        {"User_Id", new AttributeValue{S = User_Id} }
                    }
            };

            var response = await _dynamoDb.GetItemAsync(item);

            if (response.Item == null || !response.IsItemSet)
                return null;

            var result = response.Item.ToClass<TempDbRepository>();

            return result;
        }


        public async Task<List<OrderTrashResponse>> GetCheckIsOrderInfoByUser(string User_Id, string Water_Brand, string Volume)
        {
            var request = new ScanRequest
            {
                TableName = _ordertableName,
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                {":userid", new AttributeValue { S = User_Id } },
                {":waterbrand", new AttributeValue { S = Water_Brand } },
                {":volume", new AttributeValue { S = Volume } }
   },
                
                FilterExpression = "User_Id = :userid AND Water_Brand = :waterbrand AND Volume = :volume"
            };

            var response = await _dynamoDb.ScanAsync(request);
            var db_items = response.Items;
            var result = new List<OrderTrashResponse>();

            foreach (var item in db_items)
            {
                var record = item.ToClass<OrderTrashResponse>();
                result.Add(record);
            }
            //if (response.Item == null || !response.IsItemSet)
            //    return null;

            //var result = response.Item.ToClass<OrderDbRepository>();

            return result;
        }


        public async Task<List<AccountingDbRepository>> GetOrderByDate(string Date_Acco, string User_Id)
        {
            var request = new ScanRequest
            {
                TableName = _accountingtableName,
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                {":dateacco", new AttributeValue { S = Date_Acco } },
                {":newuserid", new AttributeValue { S = User_Id } }

   },
                FilterExpression = "Date_Acco = :dateacco AND User_Id = :newuserid"
            };

            var response = await _dynamoDb.ScanAsync(request);
            var db_items = response.Items;
            var result = new List<AccountingDbRepository>();

            foreach (var item in db_items)
            {
                var record = item.ToClass<AccountingDbRepository>();
                result.Add(record);
            }
            //if (response.Item == null || !response.IsItemSet)
            //    return null;

            //var result = response.Item.ToClass<OrderDbRepository>();

            return result;
        }

        public async Task<UserAddressResponse> GetAddress(string User_Id)
        {

            var item = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                    {
                        {"User_Id", new AttributeValue{S = User_Id} }
                    }
            };

            var response = await _dynamoDb.GetItemAsync(item);

            if (response.Item == null || !response.IsItemSet)
                return null;

            var result = response.Item.ToClass<UserAddressResponse>();

            return result;
        }

        public async Task<UserCityResponse> GetCityAddress(string User_Id)
        {

            var item = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                    {
                        {"User_Id", new AttributeValue{S = User_Id} }
                    }
            };

            var response = await _dynamoDb.GetItemAsync(item);

            if (response.Item == null || !response.IsItemSet)
                return null;

            var result = response.Item.ToClass<UserCityResponse>();

            return result;
        }

        public async Task<AccountingDbRepository> GetInfoByOrderId(string Order_Id)
        {

            var item = new GetItemRequest
            {
                TableName = _accountingtableName,
                Key = new Dictionary<string, AttributeValue>
                    {
                        {"Order_Id", new AttributeValue{S = Order_Id} }
                    }
            };

            var response = await _dynamoDb.GetItemAsync(item);

            if (response.Item == null || !response.IsItemSet)
                return null;

            var result = response.Item.ToClass<AccountingDbRepository>();

            return result;
        }


        public async Task<UserDbRepository> GetVerifyInfoByUser(string User_Id)
        {

            var item = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                    {
                        {"User_Id", new AttributeValue{S = User_Id} }
                    }
            };

            var response = await _dynamoDb.GetItemAsync(item);

            if (response.Item == null || !response.IsItemSet)
                return null;

            var result = response.Item.ToClass<UserDbRepository>();

            return result;
        }


        public async Task<UserDbRepository> GetStatusInfoByUser(string User_Id)
        {

            var item = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                    {
                        {"User_Id", new AttributeValue{S = User_Id} }
                    }
            };

            var response = await _dynamoDb.GetItemAsync(item);

            if (response.Item == null || !response.IsItemSet)
                return null;

            var result = response.Item.ToClass<UserDbRepository>();

            return result;
        }


        public async Task<List<AccountingDbRepository>> GetAllOrdersByDate(string Date_Acco)
        {
            var request = new ScanRequest
            {
                TableName = _accountingtableName,
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                {":dateacco", new AttributeValue { S = Date_Acco }}
   },
                FilterExpression = "Date_Acco = :dateacco"
            };

            var response = await _dynamoDb.ScanAsync(request);
            var db_items = response.Items;
            var result = new List<AccountingDbRepository>();

            foreach (var item in db_items)
            {
                var record = item.ToClass<AccountingDbRepository>();
                result.Add(record);
            }
            //if (response.Item == null || !response.IsItemSet)
            //    return null;

            //var result = response.Item.ToClass<OrderDbRepository>();

            return result;
        }


        public async Task<List<AccountingDbRepository>> GetDataForAccounting(string startDate, string endDate)
        {
            var request = new ScanRequest
            {
                TableName = _accountingtableName,
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                {":startDate", new AttributeValue { S = startDate }},
                {":endDate", new AttributeValue { S = endDate }}
        },
                FilterExpression = "Date_Acco BETWEEN :startDate AND :endDate"
            };

            var response = await _dynamoDb.ScanAsync(request);
            var db_items = response.Items;
            var result = new List<AccountingDbRepository>();

            foreach (var item in db_items)
            {
                var record = item.ToClass<AccountingDbRepository>();
                result.Add(record);
            }
            //if (response.Item == null || !response.IsItemSet)
            //    return null;

            //var result = response.Item.ToClass<OrderDbRepository>();

            return result;
        }

        public async Task<UserDbRepository> GetUserInfoById(string User_Id)
        {

            var item = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                    {
                        {"User_Id", new AttributeValue{S = User_Id} }
                    }
            };

            var response = await _dynamoDb.GetItemAsync(item);

            if (response.Item == null || !response.IsItemSet)
                return null;

            var result = response.Item.ToClass<UserDbRepository>();

            return result;
        }


        public async Task<List<UserDbRepository>> GetUserInfoByPhone(string Phone)
        {
            var request = new ScanRequest
            {
                TableName = _tableName,
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                {":phone", new AttributeValue { S = Phone }}
   },
                FilterExpression = "Phone = :phone"
            };

            var response = await _dynamoDb.ScanAsync(request);
            var db_items = response.Items;
            var result = new List<UserDbRepository>();

            foreach (var item in db_items)
            {
                var record = item.ToClass<UserDbRepository>();
                result.Add(record);
            }
            //if (response.Item == null || !response.IsItemSet)
            //    return null;

            //var result = response.Item.ToClass<OrderDbRepository>();

            return result;
        }



    }
}
