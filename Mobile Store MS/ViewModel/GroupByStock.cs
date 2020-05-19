using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel
{
    public class GroupByStock
    {
        public int store_id { get; set; }
        public string StoreName { get; set; }
        public int RefNo { get; set; }
        public IEnumerable<StockViewModel> Models { get; set; }
    }
}
