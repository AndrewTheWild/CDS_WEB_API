using CDS.DynamicAPI.Mockup;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http; 

namespace CDS.DynamicAPI
{
    public class DynamicService
    {
        private string _token;
        private string _serviceRootApi;
        public DynamicService(string token, string rootApi)
        {
            _token = token;
            _serviceRootApi = rootApi;
        }

        public string GetPluralNameEntity(string entityName)
        {
            var api = _serviceRootApi + $"EntityDefinitions(LogicalName='{entityName}')/EntitySetName";
            var json=DynamicAPI.CallApi(_token, api, string.Empty, HttpMethod.Get).Result;
            var jObject = JObject.Parse(json);
            return jObject.GetValue("value").ToString();
        }
        public string GetColumnsForRetrieve(ColumnSet columnSet)
        {
            var columns =string.Empty;
            if (!columnSet.AllColumns)
            {
                columns+= "?$select=";
                columns+= columnSet.Columns.Aggregate((concat, str) =>$"{concat},{str}");
            }
            return columns;
        }

        public void Delete(string entityName,Guid id)
        {
            var name = GetPluralNameEntity(entityName);
            var api = _serviceRootApi + $"{name}({id})";
            var buf=DynamicAPI.CallApi(_token, api,string.Empty, HttpMethod.Delete).Result;
        }

        public void Update(string entityName,Guid id, JObject body)
        {
            var name = GetPluralNameEntity(entityName);
            var api = _serviceRootApi + $"{name}({id})";
            var buf = DynamicAPI.CallApi(_token, api, body.ToString(), HttpMethod.Patch).Result; 
        }

        public Guid Create(string entityName,JObject body)
        {
            var name = GetPluralNameEntity(entityName);
            var api = _serviceRootApi + $"{name}";
            var idEntity = DynamicAPI.CallApi(_token, api, body.ToString(), HttpMethod.Post).Result;
            return new Guid(idEntity);
        }

        public string Retrieve(string entityName, Guid id, ColumnSet columnSet)
        {
            var name = GetPluralNameEntity(entityName);
            var api = _serviceRootApi + $"{name}({id}){GetColumnsForRetrieve(columnSet)}"; 
            return DynamicAPI.CallApi(_token, api, string.Empty, HttpMethod.Get).Result;
        }

        public string RetrieveAll(string entityName)
        {
            var name = GetPluralNameEntity(entityName);
            var api = _serviceRootApi + $"{name}";
            return DynamicAPI.CallApi(_token, api, string.Empty, HttpMethod.Get).Result;
        }
    }
}
