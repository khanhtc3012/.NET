using WEB_API.Models;

namespace WEB_API.Dtos
{
    public class PageResult<T>
    {
        public List<T> Items { get; set; }
        public int Page { get; set; } 
        public int Limit { get; set; }
        public int TotalRow { get; set; }  
    }
}
