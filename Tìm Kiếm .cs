using System;
using System.Collections.Generic;
using System.Text;

namespace Đồ_Án_1_125201_
{
    class TimKiem
    {
        QLGiayTheThao t = new QLGiayTheThao();
        QLKhachHang k = new QLKhachHang();
        QLNhanVien v = new QLNhanVien();
        #region Menu Chức Năng Tìm Kiếm
        public void chon()
        {
            bool stop = false;
            while (!stop)
            {
                Console.Write("\n\n\t\t\t\t\t\t\t ╔═══════════════════════════════════════════════════════════════════╗");
                Console.Write("\n\t\t\t\t\t\t\t ║                          BẢNG TÌM KIẾM                            ║");
                Console.Write("\n\t\t\t\t\t\t\t ╠═══════════════════════════════════════════════════════════════════╣");
                Console.Write("\n\t\t\t\t\t\t\t ║                                                                   ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╔═══╤═══════════════════════════════════════╗           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 1 │ Tìm Kiếm Thông Tin Giày               ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼───────────────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 2 │ Tìm kiếm Thông Tin Nhân Viên          ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼───────────────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 3 │ Tìm Kiếm Thông Tin Khách Hàng         ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼───────────────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 4 │ Quay Lại                              ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼───────────────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 5 │ Thoát                                 ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼───────────────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║   │ Chọn chức năng:                       ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╚═══╧═══════════════════════════════════════╝           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║                                                                   ║");
                Console.Write("\n\t\t\t\t\t\t\t ║                                                                   ║");
                Console.Write("\n\t\t\t\t\t\t\t ╚═══════════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(91, 17);
                string kt = Console.ReadLine();
                Console.Clear();
                switch (kt)
                {
                    case "1": t.timkiem();
                        break;
                    case "2": v.TimKiem(); 
                        break;
                    case "3": k.TimKiem(); 
                        break;
                    case "4":
                        Menu n = new Menu();
                        n.MenuChinh();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default: 
                        break;
                }
            }
        }
        #endregion
    }
}
