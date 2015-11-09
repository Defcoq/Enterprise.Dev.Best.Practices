using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EA.DAL.QueryObject.Infrastructure.Query;
using System.Data.SqlClient;
using EA.DAL.QueryObject.Repository;

namespace EA.DAL.QueryObject.Test
{
    [TestClass]
    public class QueryObjectTest
    {
        [TestMethod]
        public void The_Translator_Should_Produce_Valid_SQL_From_A_Query_Object()
        {
            int customerId = 9;
            string expectedSQL = "SELECT * FROM Orders WHERE CustomerId = @CustomerId ORDER BY CustomerId DESC";

            Query query = new Query();
            query.Add(new Criterion("CustomerId", customerId, CriteriaOperator.Equal));
            query.OrderByProperty = new OrderByClause { PropertyName = "CustomerId", Desc = true };

            SqlCommand command = new SqlCommand();
            query.TranslateInto(command);

            Assert.AreEqual(expectedSQL, command.CommandText);

        }
    }
}
