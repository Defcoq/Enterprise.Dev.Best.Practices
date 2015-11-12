using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.WebApi.Model
{
    public class PagedDataInquiryResponse<T> : IPageLinkContaining
    {
        private List<T> _items;
        private List<Link> _links;
        public List<T> Items
        {
            get { return _items ?? (_items = new List<T>()); }
            set { _items = value; }
        }
        public int PageSize { get; set; }
        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>()); }
            set { _links = value; }
        }
        public void AddLink(Link link)
        {
            Links.Add(link);
        }
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
    }

}

