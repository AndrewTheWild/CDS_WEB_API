//using Microsoft.PowerPlatform.Cds.Client;
//using System;
//using System.Collections.Generic;

//namespace Test.NET_Core_Console_.Model
//{
//    public class AccountService
//    {
//        private Credentials ApiCredentials;
//        private IOrganizationService _orgService;
//        public string ErrorMessage { get; }
//        public List<string> ToJson(List<Entity> entities)
//        {
//            List<string> accountsJson = new List<string>();
//            foreach (var entity in entities)
//            {
//                var json = "{";
//                foreach (var att in entity.Attributes)
//                {
//                    json += $"\"{att.Key}\":\"{att.Value}\",";

//                }
//                json = json.Substring(0, json.Length - 1);
//                json += "}";
//                accountsJson.Add(json);
//            }
//            return accountsJson;
//        }
//        public AccountService(Credentials credentials)
//        {
//            try
//            {
//                ApiCredentials = credentials;
//                var conn = new CdsServiceClient(credentials.GetConnectionString());
//                _orgService = conn.OrganizationWebProxyClient ?? (IOrganizationService)conn.OrganizationServiceProxy;

//            }
//            catch (Exception ex)
//            {
//                ErrorMessage = ex.Message;
//            }
//        }
//        //public List<Account> GetModifiedAccounts(DateTime modifiedOn)
//        //{
//        //    var accountQuery = new QueryExpression
//        //    {
//        //        EntityName = "account",
//        //        ColumnSet = new ColumnSet("name", "telephone1", "websiteurl", "address1_line1",
//        //                                         "address1_line2", "address1_city", "address1_postalcode",
//        //                                         "address1_stateorprovince"),
//        //        Criteria = new FilterExpression
//        //        {
//        //            Conditions =
//        //                {
//        //                    new ConditionExpression
//        //                    {
//        //                        AttributeName = "modifiedon",
//        //                        Operator = ConditionOperator.GreaterEqual,
//        //                        Values = { modifiedOn}
//        //                    }
//        //                }
//        //        }
//        //    };
//        //    List<Account> listAccount=new List<Account>();
//        //    foreach (var json in ToJson(_orgService.RetrieveMultiple(accountQuery).Entities.ToList()))
//        //    {
//        //        listAccount.Add(JsonConvert.DeserializeObject<Account>(json));
//        //    }
//        //    //
//        //   return listAccount;
//        //}
//        //public Account GetAccountDetails(Guid accountId)
//        //{
//        //    var account=_orgService.Retrieve("account", accountId, new ColumnSet("name", "telephone1", "websiteurl", "address1_line1",
//        //                                         "address1_line2", "address1_city", "address1_postalcode",
//        //                                         "address1_stateorprovince"));
//        //    QueryExpression query = new QueryExpression("contact");
//        //    query.ColumnSet = new ColumnSet(new string[] { "fullname", "telephone1", "mobilephone", "address1_composite", 
//        //                                                    "emailaddress1"});
//        //    query.Criteria.AddCondition(new ConditionExpression("parentcustomerid", ConditionOperator.Equal, accountId));
//        //    //
//        //    var listContacts = _orgService.RetrieveMultiple(query).Entities.ToList();
//        //    var jsonAccount = ToJson(new List<Entity>() {account});
//        //    var accountInf = jsonAccount.First();
//        //    var jsonContacts= ToJson(listContacts);
//        //    var buf="";
//        //    foreach (var entity in jsonContacts)
//        //    {
//        //        buf += entity+",";
//        //    }
//        //    buf = buf.Substring(0, buf.Length - 1);
//        //    accountInf = accountInf.Insert(accountInf.Length - 1,","+$"\"Contacts\":[{buf}]");
//        //    return JsonConvert.DeserializeObject<Account>(accountInf); ;
//        //}

//    }
//}
