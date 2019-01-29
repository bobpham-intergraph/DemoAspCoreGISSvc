using System;
using System.Collections.Generic;
using System.Text;

namespace MongodbConnect.Repository
{
    public class PagingResult<T> where T : IMongoEntity
    {
        public int TotalCount { get; set; }
        public int NumberofRecordsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public ICollection<T> CurrentData { get; set; }
    }
}
