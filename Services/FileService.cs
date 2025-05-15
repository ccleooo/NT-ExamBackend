using CommonFuncs.Utilities;
using ExamBackend.Models;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;


namespace ExamBackend.Services
{
    public class FileService
    {
        public static void InsertTableF(string source,string target)
        {
            using (SqlConnection sqlCon = new SqlConnection(NetCore.Global.Connection.BPM.String))
            {
                sqlCon.Open();

                TableInfo sourceTableInfo = FlowService.GetTableInfoByRequisitonId(source);
                TableInfo targetTableInfo = FlowService.GetTableInfoByRequisitonId(target);
                ExamBackend.Models.FileInfo sourceFileInfo = FlowService.GetFileInfoByRequisitionId(source);
                string sqlcmd = $@"
                INSERT INTO [dbo].[FM7T_{targetTableInfo.Identify}_F](
                    [AutoCounter],
                    [AccountID],
                    [MemberName],
                    [RequisitionID],
                    [DiagramID],
                    [ProcessID],
                    [ProcessName],
                    [NFileName],
                    [OFileName],
                    [FileSize],
                    [DraftFlag],
                    [Remark]
                ) VALUES (
                    (SELECT ISNULL(MAX(AutoCounter)+1,1) FROM [FM7T_{targetTableInfo.Identify}_F]),
                    @AccountID,
                    @MemberName,
                    @RequisitionID,
                    @DiagramID,
                    @ProcessID,
                    @ProcessName,
                    @NFileName,
                    @OFileName,
                    @FileSize,
                    @DraftFlag,
                    @Remark
                )";

                //////請完成以下部分//////
                JObject keyValuePairs = new JObject()
                {
                    { "@AccountID", sourceFileInfo.AccountID },
                    { "@MemberName", sourceFileInfo.MemberName },
                    { "@NFileName", sourceFileInfo.NFileName },
                    { "@OFileName", sourceFileInfo.OFileName },
                    { "@FileSize", sourceFileInfo.FileSize },
                    { "@DraftFlag", sourceFileInfo.DraftFlag },
                    { "@Remark", sourceFileInfo.Remark },
                    { "@RequisitionID", target },
                    { "@DiagramID", targetTableInfo.DiagramID },
                    { "@ProcessID", "Start01" },
                    { "@ProcessName", "Start" },
                };

                        Db.Execute(sqlcmd, sqlCon, keyValuePairs);
                    }
                }

    }
}
