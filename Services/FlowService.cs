using CommonFuncs.Utilities;
using ExamBackend.Models;
using NetCore.Global;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;

namespace ExamBackend.Services
{
    public class FlowService
    {
        public static TableInfo GetTableInfoByRequisitonId(string requisitonId)
        {
            using (SqlConnection sqlCon = new SqlConnection(Connection.BPM.String))
            {
                sqlCon.Open();

                return Db.ReadFirstJson<TableInfo>(
                    @"
                    SELECT
                        sd.DiagramID,
                        sd.DisplayName AS DiagramName,
                        sd.Identify,
                        sd.MTable,
                        'FM7T_' + sd.Identify + '_S' AS STable,
                        sd.LTable
                    FROM FSe7en_Sys_Requisition sr
                    LEFT JOIN FSe7en_Sys_DiagramList sd on sr.DiagramID=sd.DiagramID
                    WHERE sr.RequisitionID=@RequisitionID
                    ", sqlCon, new JObject() {
                            { "@RequisitionID",requisitonId }
                    }
                );
            }
        }

        public static ExamBackend.Models.FileInfo GetFileInfoByRequisitionId(string requisitionId)
        {
            using (SqlConnection sqlCon = new SqlConnection(Connection.BPM.String))
            {
                sqlCon.Open();

                var tableInfo = GetTableInfoByRequisitonId(requisitionId);
                if (tableInfo == null || string.IsNullOrEmpty(tableInfo.Identify))
                    return null;

                string tableName = $"FM7T_{tableInfo.Identify}_F";

                return Db.ReadFirstJson<ExamBackend.Models.FileInfo>(
                    $@"
                    SELECT
                        *
                    FROM {tableName}
                    WHERE RequisitionID=@RequisitionID
                    ", sqlCon, new JObject() {
                        { "@RequisitionID", requisitionId }
                    }
                );
            }
        }
    }
}
