using System.Collections.Generic;

namespace Application.Common.Results
{
    public class ListDetailModel<T>
    {
        public List<T> Items { get; set; }
        public int Total { get; set; }
    }
}