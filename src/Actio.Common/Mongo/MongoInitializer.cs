﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Actio.Common.Mongo
{
    public class MongoInitializer : IDatabaseInitializer
    {
        private bool _initialized;
        private readonly bool _seed;
        private readonly IMongoDatabase _database;

        public MongoInitializer(IMongoDatabase database, IOptions<MongoOptions> options)
        {
            _database = database;
            _seed = options.Value.Seed;
        }
        public async Task InitializeAsync()
        {
            if (_initialized)
            {
                return;
            }

            RegisterConventions();
            _initialized = true;
            if (!_seed)
            {
                return;
            }
        }

        private void RegisterConventions()
        {
            ConventionRegistry.Register("ActionCoventions", new MongoConvention(), x => true);
        }

        private class MongoConvention : IConventionPack
        {
            public IEnumerable<IConvention> Conventions => new List<IConvention>
            {
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(BsonType.String),
                new CamelCaseElementNameConvention()
            };
        }
    }
}
