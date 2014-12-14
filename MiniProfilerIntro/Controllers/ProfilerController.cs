using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProfilerIntro.Controllers
{
    public class ProfilerController : Controller
    {
        //
        // GET: /Profiler/

        public ActionResult Step(int? id) {
            var profiler = MiniProfiler.Current; // it's ok if this is null

            using (profiler.Step("進入 Step 控制器")) {
                if (id != null) {
                    using (profiler.Step(String.Format("計算費柏拉係數：{0}", id))) { // and here
                        ViewBag.Num = id;
                        ViewBag.Fibonacci = Fibonacci(id.Value);
                    }
                }

                System.Threading.Thread.Sleep(1000);
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
            return View();
        }

        public ActionResult Duplicate() {
            return View();
        }

        public ActionResult AJAX() {
            return View();
        }
	}
}