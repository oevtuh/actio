﻿using System;
using System.Collections.Generic;
using System.Text;
using Actio.Common.RabbitMq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using RawRabbit;
using RawRabbit.Instantiation;

namespace Actio.Common.Mongo
{
    public static class Extensions
    {
        public static void AddMongoDB(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<MongoOptions>(configuration.GetSection("mongo"));
            service.AddSingleton<MongoClient>(c =>
            {
                var options = c.GetService<IOptions<MongoOptions>>();

                return new MongoClient(options.Value.ConnectionString);
            });

            service.AddScoped<IMongoDatabase>(c =>
            {
                var options = c.GetService<IOptions<MongoOptions>>();
                var client = c.GetService<MongoClient>();

                return client.GetDatabase(options.Value.Database);
            });

            service.AddScoped<IDatabaseInitializer, MongoInitializer>();
            service.AddScoped<IDatabaseSeeder, MongoSeeder>();
        }
    }
}
