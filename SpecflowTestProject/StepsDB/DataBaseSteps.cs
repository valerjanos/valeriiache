using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecflowTestProject
{
    [Binding]
    public class DataBaseSteps
    {
        private readonly SqlHelper _sqlHelper;
        public DataBaseSteps(SqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        [Given(@"Connection to localDb is opened")]
        public void GivenConnectionToLocalDbIsOpened()
        {
            _sqlHelper.OpenConnection();
        }

        [When(@"I add new row in '(.*)' Database Table")]
        public void WhenIAddNewRowInDatabaseTable(string nameOfTableInDb, Table table)
        {
            var data = table.Header.ToList().ToDictionary(header => header, header => table.Rows[0][header]);
            _sqlHelper.Insert(nameOfTableInDb, data);
        }

        [When(@"I close connection to localDB")]
        public void WhenICloseConnectionToLocalDB()
        {
            _sqlHelper.CloseConnection();
        }

        [Then(@"Row with data is existed in '(.*)' Database Table")]
        public void ThenRowWithDataIsExistedInDatabaseTable(string nameOfTableInDb, Table table)
        {
            var data = table.Header.ToList().ToDictionary(header => header, header => table.Rows[0][header]);
            Assert.True(_sqlHelper.IsRowExistedInTable(nameOfTableInDb, data));
        }
    }
}

