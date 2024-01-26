using Microsoft.AspNetCore.Mvc;
using Sample8_1.Shared.Models;

namespace Sample8_1.Web.Controllers
{
    public class BoardController : Controller
    {
        public IActionResult Index()
        {
            // string str = "2024-01-25 18:30:21";
            // Console.WriteLine(Convert.ToDateTime(str));

            List<Board> boards = new List<Board>()
            {
                new Board { Id = 1, Title = "첫 번째 글", Author = "홍길동", CreateDate = DateTime.Now.AddDays(-10), Descript = "첫 번째 글입니다." },
                new Board { Id = 2, Title = "두 번째 글", Author = "이순신", CreateDate = DateTime.Now.AddDays(-9), Descript = "두 번째 글입니다." },
                new Board { Id = 3, Title = "세 번째 글", Author = "장영실", CreateDate = DateTime.Now.AddDays(-8), Descript = "세 번째 글입니다." },
                new Board { Id = 4, Title = "네 번째 글", Author = "세종대왕", CreateDate = DateTime.Now.AddDays(-7), Descript = "네 번째 글입니다." },
                new Board { Id = 5, Title = "다섯 번째 글", Author = "유관순", CreateDate = DateTime.Now.AddDays(-6), Descript = "다섯 번째 글입니다." },
                new Board { Id = 6, Title = "여섯 번째 글", Author = "안중근", CreateDate = DateTime.Now.AddDays(-5), Descript = "여섯 번째 글입니다." },
                new Board { Id = 7, Title = "일곱 번째 글", Author = "김구", CreateDate = DateTime.Now.AddDays(-4), Descript = "일곱 번째 글입니다." },
                new Board { Id = 8, Title = "여덟 번째 글", Author = "윤봉길", CreateDate = DateTime.Now.AddDays(-3), Descript = "여덟 번째 글입니다." },
                new Board { Id = 9, Title = "아홉 번째 글", Author = "강감찬", CreateDate = DateTime.Now.AddDays(-2), Descript = "아홉 번째 글입니다." },
                new Board { Id = 10, Title = "열 번째 글", Author = "이봉창", CreateDate = DateTime.Now.AddDays(-1), Descript = "열 번째 글입니다." }
            };

            return View(boards);
        }
    }
}
