using SigQL.Types.Attributes;

namespace MVCNET6.Data.Repositories
{
    public interface IWorkLogRepository
    {
        IEnumerable<WorkLog.IWorkLogListItem> GetList([Offset] int? offset = 0, [Fetch] int? fetch = 10);
        
        WorkLog.IDetails GetDetails(int id);

        [Insert(TableName = nameof(WorkLog))]
        WorkLog.IId Insert(WorkLog.Insert item);

        [Delete(TableName = nameof(WorkLog))]
        void Delete(int id);

        IEnumerable<WorkLog.IWorkLogListItem> Search(WorkLog.ISearch filter, [Fetch] int fetch = 10);
    }
}
