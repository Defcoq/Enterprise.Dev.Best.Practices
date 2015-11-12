using EA.WebApi.Data.Entities;
using EA.WebApi.Data.QueryProcessors;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EA.WebApi.Data.SqlServer.QueryProcessors
{
    public class AllTasksQueryProcessor : IAllTasksQueryProcessor
    {
        private readonly ISession _session;
        public AllTasksQueryProcessor(ISession session)
        {
            _session = session;
        }
        public QueryResult<Task> GetTasks(PagedDataRequest requestInfo)
        {
            var query = _session.QueryOver<Task>();
            var totalItemCount = query.ToRowCountQuery().RowCount();
            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber,
            requestInfo.PageSize);
            var tasks = query.Skip(startIndex).Take(requestInfo.PageSize).List();
            var queryResult = new QueryResult<Task>(tasks, totalItemCount, requestInfo.PageSize);
            return queryResult;
        }

    }
}
