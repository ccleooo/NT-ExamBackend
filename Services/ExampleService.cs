using CommonFuncs.Utilities;
using NetCore.Models.Api;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;

namespace NetCore.Services
{
    public static class ExampleService
    {
        public static List<Example> GetAll()
        {
            using (SqlConnection sqlCon = new SqlConnection(Global.Connection.NUP.String))
            {
                sqlCon.Open();
                return Db.ReadJson<Example>("SELECT AccountID AS Code, DisplayName AS Name FROM FSe7en_Org_MemberInfo", sqlCon);
            }
        }
        public static Example Get(string code)
        {
            using (SqlConnection sqlCon = new SqlConnection(Global.Connection.NUP.String))
            {
                sqlCon.Open();
                return Db.ReadFirstJson<Example>("SELECT AccountID AS Code, DisplayName AS Name FROM FSe7en_Org_MemberInfo WHERE AccountID = @Code", sqlCon, new JObject {
                    { "@Code",code }
                });
            }
        }
        public static string GetName(string code)
        {
            using (SqlConnection sqlCon = new SqlConnection(Global.Connection.NUP.String))
            {
                sqlCon.Open();
                return Db.ReadFirst("SELECT DisplayName FROM FSe7en_Org_MemberInfo WHERE AccountID = @Code", sqlCon, new JObject {
                    { "@Code",code }
                });
            }
        }
        public static int Add(Example example)
        {
            using (SqlConnection sqlCon = new SqlConnection(Global.Connection.NUP.String))
            {
                sqlCon.Open();
                return Db.Execute("INSERT INTO FSe7en_Org_MemberInfo (AccountID,DisplayName) VALUES (@Code,@Name)", sqlCon, example);
            }
        }
    }
}
