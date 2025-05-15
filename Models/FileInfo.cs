using Newtonsoft.Json;

namespace ExamBackend.Models
{
    public class FileInfo
    {        
        public string AccountID { get; set; }
        public string MemberName { get; set; }
        public string DiagramID { get; set; }
        public string ProcessID { get; set; }
        public string NFileName { get; set; }
        public string OFileName { get; set; }
        public string FileSize { get; set; }
        public string DraftFlag { get; set; }
        public string Remark { get; set; }
    }

}
