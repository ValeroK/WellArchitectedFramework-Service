using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WellArchitectedServices.Data;

namespace WellArchitectedServices.MySQL
{
    internal class ServicesQuery
    {

        public readonly AppDb Db;
        public ServicesQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<IEnumerable<Service>> FindAll()
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `services`";
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                var result = await ReadAllAsync(reader);
                return result;
            }
        }

        private async Task<IEnumerable<Service>> ReadAllAsync(DbDataReader reader)
        {
            var services = new List<Service>();
            while (await reader.ReadAsync())
            {
                var service = new Service()
                {
                    Id = await reader.GetFieldValueAsync<int>(0),
                    Name = await reader.GetFieldValueAsync<string>(1),
                    Observable = await GetNullableValue<int>(2, reader),
                    ApiFirst = await GetNullableValue<int>(3, reader),
                    CiCdSupport = await GetNullableValue<int>(4, reader),
                    Tested = await GetNullableValue<int>(5, reader),
                    WellDesignedDeveloped = await GetNullableValue<int>(6, reader),
                    Measured = await GetNullableValue<int>(7, reader),
                    Secured = await GetNullableValue<int>(8, reader),
                    EcoSystemMember = await GetNullableValue<int>(9, reader),
                    MultiTenantSupport = await GetNullableValue<int>(10, reader),
                    Scalable = await GetNullableValue<int>(11, reader),
                    Resilient = await GetNullableValue<int>(12, reader),
                    Knowledge = await GetNullableValue<int>(13, reader),
                    Mastery = await GetNullableValue<int>(14, reader),
                    DevEcoSys = await GetNullableValue<int>(15, reader),
                    WellSeparated = await GetNullableValue<int>(16, reader),
                    Updated = await reader.GetFieldValueAsync<DateTime>(17)
                };
                services.Add(service);
            }
            return services;
        }

        private async Task<T?> GetNullableValue<T>(int ordinal, DbDataReader reader)
            where T : struct
        {
            if (!await reader.IsDBNullAsync(ordinal))
            {
                var result = await reader.GetFieldValueAsync<T>(ordinal);
                return result;
            }
            return null;
        }
    }
}