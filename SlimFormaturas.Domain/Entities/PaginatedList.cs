using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Entities {
    public class PaginatedList<T> : List<T> {
        public int PageIndex { get; private set; }
        public int TotalPages { get; set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize) {
            PageIndex = pageIndex;
            TotalPages = (int) Math.Ceiling(count / (double) pageSize);
            this.AddRange(items);
        }

        public PaginatedList() {
        }

        public bool PreviousPage => PageIndex > 1;

        public bool NextPage => PageIndex < TotalPages;
    }
}
