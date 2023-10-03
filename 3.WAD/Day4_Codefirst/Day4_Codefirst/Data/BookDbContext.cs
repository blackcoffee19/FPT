using Day4_Codefirst.Models;
using Microsoft.EntityFrameworkCore;

namespace Day4_Codefirst.Data
{
    public class BookDbContext :DbContext
    {
        public BookDbContext() { }
        //Hàm dựng có tham sô,dùng để thiết lập cấu hình kết nối
        public BookDbContext(DbContextOptions options) : base(options) { }
        //Mô tả danh sách row trong db
        public DbSet<Book>? Books { get; set; }
    }
}
