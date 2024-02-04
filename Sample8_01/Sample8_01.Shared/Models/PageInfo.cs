using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample8_01.Shared.Models
{
    public class PageInfo
    {
        // 페이지당 데이터 수
        public int PageSize { get; set; }

        // 현재 페이지 번호
        public int CurrentPage { get; set; }

        // 전체 데이터 수, 전체 페이지 수를 구하기 위해 필요
        public int TotalItems { get; set; }

        // 전체 페이지 수
        public int TotalPages 
        { 
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }        
    }
}
