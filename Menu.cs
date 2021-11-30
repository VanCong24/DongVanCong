using System;
using System.Collections.Generic;
using System.Text;

namespace Đồ_Án_1_125201_
{
    class Menu
    {
        #region Menu Chính Của Ứng Dụng
        public void MenuChinh()
        {
            bool stop = false;
            while (!stop)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetWindowSize(150, 40);
                Console.Clear();
                Console.Write("\n\n\t\t\t\t\t\t ╔════════════════════════════════════════════════════════════════════════╗");
                Console.Write("\n\t\t\t\t\t\t ║                                                                        ║");
                Console.Write("\n\t\t\t\t\t\t ║        CHƯƠNG TRÌNH QUẢN LÝ BÁN HÀNG CỦA NHÀ HÀNG GIÀY THỂ THAO        ║");
                Console.Write("\n\t\t\t\t\t\t ║                                                                        ║");
                Console.Write("\n\t\t\t\t\t\t ╠════════════════════════════════════════════════════════════════════════╣");
                Console.Write("\n\t\t\t\t\t\t ║                                                                        ║");
                Console.Write("\n\t\t\t\t\t\t ║               ╔═══╤═════════════════════════════════════╗              ║");
                Console.Write("\n\t\t\t\t\t\t ║               ║ 1 │ Quản Lý Giày Thể Thao               ║              ║");
                Console.Write("\n\t\t\t\t\t\t ║               ╟───┼─────────────────────────────────────╢              ║");
                Console.Write("\n\t\t\t\t\t\t ║               ║ 2 │ Quản Lý Hóa Đơn                     ║              ║");
                Console.Write("\n\t\t\t\t\t\t ║               ╟───┼─────────────────────────────────────╢              ║");
                Console.Write("\n\t\t\t\t\t\t ║               ║ 3 │ Quản Lý Khách Hàng                  ║              ║");
                Console.Write("\n\t\t\t\t\t\t ║               ╟───┼─────────────────────────────────────╢              ║");
                Console.Write("\n\t\t\t\t\t\t ║               ║ 4 │ Quản Lý Nhân Viên                   ║              ║");
                Console.Write("\n\t\t\t\t\t\t ║               ╟───┼─────────────────────────────────────╢              ║");
                Console.Write("\n\t\t\t\t\t\t ║               ║ 5 │ Thống Kê                            ║              ║");
                Console.Write("\n\t\t\t\t\t\t ║               ╟───┼─────────────────────────────────────╢              ║");
                Console.Write("\n\t\t\t\t\t\t ║               ║ 6 │ Tìm Kiếm                            ║              ║");
                Console.Write("\n\t\t\t\t\t\t ║               ╟───┼─────────────────────────────────────╢              ║");
                Console.Write("\n\t\t\t\t\t\t ║               ║ 7 │ Thoát                               ║              ║");
                Console.Write("\n\t\t\t\t\t\t ║               ╟───┼─────────────────────────────────────╢              ║");
                Console.Write("\n\t\t\t\t\t\t ║               ║   │ Bạn chọn chức năng:                 ║              ║");
                Console.Write("\n\t\t\t\t\t\t ║               ╚═══╧═════════════════════════════════════╝              ║");
                Console.Write("\n\t\t\t\t\t\t ║                                                                        ║");
                Console.Write("\n\t\t\t\t\t\t ║                                                                        ║");
                Console.Write("\n\t\t\t\t\t\t ╚════════════════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(90, 23);
                Console.Write(" ");
                string q = Console.ReadLine();
                Console.Clear();
                switch (q)
                {
                    case "1":
                        Console.Clear();
                        QLGiayTheThao t = new QLGiayTheThao();
                        t.DocTep();
                        t.menu();
                        break;
                    case "2":
                        Console.Clear();
                        QLHoaDon d = new QLHoaDon();
                        d.DocTep();
                        d.menu();
                        break;
                    case "3":
                        Console.Clear();
                        QLKhachHang k = new QLKhachHang();
                        k.DocTep();
                        k.menu();
                        break;
                    case "4":
                        Console.Clear();
                        QLNhanVien v = new QLNhanVien();
                        v.DocTep();
                        v.menu();
                        break;
                    case "5":
                        Console.Clear();
                        ThongKe e = new ThongKe();
                        e.menuThongKe();
                        break;
                    case "6":
                        Console.Clear();
                        TimKiem m = new TimKiem();
                        m.chon();
                        break;
                    case "7":
                        Console.ReadKey();
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
