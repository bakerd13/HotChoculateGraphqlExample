using HotChoculate.Infrastructure.Core.Domain;
using HotChoculate.Infrastructure.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotChoculate.Infrastructure.Core.Providers
{
    public class DatabaseNameProvider : IDatabaseNameProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DatabaseNameProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetDatabaseName()
        {
            var db = Constants.DefaultDatabase;

            if (_httpContextAccessor.HttpContext.Request.Cookies[Constants.DatabaseKey] != null)
            {
                db = $"{Constants.DefaultDatabase}{_httpContextAccessor.HttpContext.Request.Cookies[Constants.DatabaseKey]}";
            }
            return db;

        }
    }
}