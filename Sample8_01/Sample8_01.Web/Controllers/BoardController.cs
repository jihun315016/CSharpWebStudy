﻿using Microsoft.AspNetCore.Mvc;
using Sample8_01.Shared.Models;
using System.Diagnostics.Eventing.Reader;

namespace Sample8_01.Web.Controllers
{
    public class BoardController : Controller
    {
        private List<Board> _boards;

        public BoardController()
        {
            _boards = new List<Board>()
            {
                new Board { Id = 1, Title = "첫 번째 글", Author = "홍길동", CreateDate = DateTime.Now.AddDays(-10), Content = "첫 번째 글입니다." },
                new Board { Id = 2, Title = "두 번째 글", Author = "이순신", CreateDate = DateTime.Now.AddDays(-9), Content = "두 번째 글입니다." },
                new Board { Id = 3, Title = "세 번째 글", Author = "장영실", CreateDate = DateTime.Now.AddDays(-8), Content = "세 번째 글입니다." },
                new Board { Id = 4, Title = "네 번째 글", Author = "세종대왕", CreateDate = DateTime.Now.AddDays(-7), Content = "네 번째 글입니다." },
                new Board { Id = 5, Title = "다섯 번째 글", Author = "유관순", CreateDate = DateTime.Now.AddDays(-6), Content = "다섯 번째 글입니다." },
                new Board { Id = 6, Title = "여섯 번째 글", Author = "안중근", CreateDate = DateTime.Now.AddDays(-5), Content = "여섯 번째 글입니다." },
                new Board { Id = 7, Title = "일곱 번째 글", Author = "김구", CreateDate = DateTime.Now.AddDays(-4), Content = "일곱 번째 글입니다." },
                new Board { Id = 8, Title = "여덟 번째 글", Author = "윤봉길", CreateDate = DateTime.Now.AddDays(-3), Content = "여덟 번째 글입니다." },
                new Board { Id = 9, Title = "아홉 번째 글", Author = "강감찬", CreateDate = DateTime.Now.AddDays(-2), Content = "아홉 번째 글입니다." },
                new Board { Id = 10, Title = "열 번째 글", Author = "이봉창", CreateDate = DateTime.Now.AddDays(-1), Content = "열 번째 글입니다." }
            };
        }


        public IActionResult Index(int page = 1, string keyword = "")
        {
            int pageSize = 5;
            var boards = _boards
                .Where(b => b.Title.Contains(keyword))
                .OrderBy(b => b.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            BoardsVM mData = new BoardsVM()
            {
                boards = boards,
                Keyword = keyword,
                Page = new PageInfo()
                {
                    PageSize = pageSize,
                    CurrentPage = page,
                    TotalItems = _boards.Count
                }
            };

            return View(mData);
        }


        //[HttpGet]
        //public IActionResult Detail(int id)
        //{
        //    Board board = _boardsVM.boards.FirstOrDefault(x => x.Id == id);
        //    return Ok(board);
        //}
    }
}