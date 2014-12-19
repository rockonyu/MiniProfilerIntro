using MiniProfilerIntro.Models;
using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProfilerIntro.Controllers {
    public class ProfilerController : Controller {
        private IntroEntities db = new IntroEntities();

        // account: austin@infbeyond.com
        // password: zzzzzz

        //
        // GET: /Profiler/
        public ActionResult Step() {
            var id = 30;
            using (MiniProfiler.Current.Step(String.Format("計算費柏拉係數：{0}", id))) { // and here
                ViewBag.Num = id;
                ViewBag.Fibonacci = Fibonacci(id);
            }
            return View();
        }

        private int Fibonacci(int num) {
            if (num <= 1)
                return (num);
            else
                return Fibonacci(num - 1) + Fibonacci(num - 2);
        }

        public ActionResult Database() {
            var tracks = new List<Track>();

            using (MiniProfiler.Current.Step("依照 ID 查詢前 100 首歌曲")) {
                tracks = db.Track.OrderBy(m => m.Id).Take(100).ToList();
            }

            return View(tracks);
        }

        public ActionResult Duplicate() {
            var tracks = new List<Track>();

            // 會導致重複查詢的 Sql 語句
            tracks = db.Track.OrderBy(m => m.Id).Take(100).ToList();

            // Include Artist 可避免重複查詢
            // tracks = db.Track.Include("Artist").OrderBy(m => m.Id).Take(100).ToList();

            return View(tracks);
        }

        public ActionResult AJAX() {
            return View();
        }
    }
}