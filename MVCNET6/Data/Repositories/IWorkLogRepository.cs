using SigQL.Types.Attributes;

namespace MVCNET6.Data.Repositories
{
    public interface IWorkLogRepository
    {
        IEnumerable<WorkLog.IWorkLogListItem> GetList([Offset] int? offset = 0, [Fetch] int? fetch = 10);
    }
}
