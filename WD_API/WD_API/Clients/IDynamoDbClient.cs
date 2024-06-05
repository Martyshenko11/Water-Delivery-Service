using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WD_API.Model;

namespace WD_API.Clients
{
    public interface IDynamoDbClient
    {
        
        public Task<bool> PostOrderToDb(OrderDbRepository data);

        public Task UpdatePhoneToDb(UserDbRepository data);

        public Task UpdateDeliveryToDb(UserDbRepository data);

        public Task UpdateDataIntoDb(UserDbRepository data);

        public Task UpdateAddressIntoDb(UserDbRepository data);

        public Task UpdateBrandToDb(TempDbRepository data);

        public Task UpdateVolumeToDb(TempDbRepository data);

        public Task UpdateNumberToDb(TempDbRepository data);

        public Task UpdateDateIntoOrder(OrderDbRepository data);

        public Task UpdateTimeIntoOrder(OrderDbRepository data);

        public Task UpdateTotalOrderForAccounting(AccountingDbRepository data);

        public Task DeleteTrashOrder(string Order_Id);

        public Task DeleteFromTrashOrder(string User_Id);

        public Task<List<OrderTrashResponse>> GetOrderInfoByUser(string User_Id);

        public Task<TempDbRepository> GetTempInfoByUser(string User_Id);

        public Task<List<OrderTrashResponse>> GetCheckIsOrderInfoByUser(string User_Id, string Water_Brand, string Volume);

        public Task<AccountingDbRepository> GetInfoByOrderId(string Order_Id);

        public Task<UserDbRepository> GetVerifyInfoByUser(string User_Id);

        public Task<UserDbRepository> GetStatusInfoByUser(string User_Id);
        
        public Task<List<AccountingDbRepository>> GetAllOrdersByDate(string Date_Acco);
        
        public Task<List<AccountingDbRepository>> GetDataForAccounting(string startDate, string endDate);

        public Task<List<AccountingDbRepository>> GetOrderByDate(string Date_Acco, string User_Id);

        public Task<UserAddressResponse> GetAddress(string User_Id);

        public Task<UserCityResponse> GetCityAddress(string User_Id);

        public Task<UserDbRepository> GetUserInfoById(string User_Id);

        public Task<List<UserDbRepository>> GetUserInfoByPhone(string Order_Date);

    }
}
