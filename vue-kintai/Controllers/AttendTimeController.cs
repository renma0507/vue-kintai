using Microsoft.AspNetCore.Mvc;
using vue_kintai.Data;
using vue_kintai.Models;
using Microsoft.EntityFrameworkCore;

namespace vue_kintai.Controllers
{
    [Route("vue-kintai/[controller]")]
    [ApiController]
    public class AttendTimeController : ControllerBase
    {
        // DB操作用オブジェクトをDI(依存性注入)で取得
        private readonly AppDbContext _context;
        public AttendTimeController(AppDbContext context) => _context = context;

        [HttpGet] // GETリクエスト：出退勤一覧を取得
        public async Task<IEnumerable<AttendTime>> Get()
        {
            // AttendTimeに関連するUserも含めて全件取得
            return await _context.AttendTime.Include(u => u.User).ToListAsync();
        }

        [HttpPost] // POSTリクエスト：出退勤時間登録
        public async Task<IActionResult> Post(AttendTime attendTime)
        {
            _context.AttendTime.Add(attendTime); // 出退勤時間を追加
            await _context.SaveChangesAsync(); // DBに保存
            return Ok(attendTime); // 成功レスポンスを返す
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var attend = await _context.User.FindAsync(id);
            if (attend == null) return NotFound();

            _context.User.Remove(attend);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
