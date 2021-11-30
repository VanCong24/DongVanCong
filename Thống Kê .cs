using System;
using System.Collections.Generic;
using System.Text;

namespace Đồ_Án_1_125201_
{
    class ThongKe
    {
        QLHoaDon h = new QLHoaDon();
        #region Menu Chức Năng Thống Kê
        public void menuThongKe()
        {
            bool stop = false;
            while (!stop)
            {
                h.DocTep();
                Console.Write("\n\n\t\t\t\t\t\t\t ╔══════════════════════════════════════════════════════════╗");
                Console.Write("\n\t\t\t\t\t\t\t ║                      BẢNG THỐNG KÊ                       ║");
                Console.Write("\n\t\t\t\t\t\t\t ╠══════════════════════════════════════════════════════════╣");
                Console.Write("\n\t\t\t\t\t\t\t ║                                                          ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╔═══╤══════════════════════════════╗           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 1 │ Thống kê ngày                ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 2 │ Thống kê tháng               ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 3 │ Thống kê năm                 ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 4 │ Quay lại                     ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 5 │ Thoát                        ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║   │ Chọn chức năng:              ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╚═══╧══════════════════════════════╝           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║                                                          ║");
                Console.Write("\n\t\t\t\t\t\t\t ║                                                          ║");
                Console.Write("\n\t\t\t\t\t\t\t ╚══════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(91, 17);
                string w = Console.ReadLine();
                Console.Clear();
                switch (w)
                {
                    case "1":
                        h.thongKeNgay();
                        break;
                    case "2":
                        h.thongKeThang();
                        break;
                    case "3":
                        h.thongKeNam(); break;
                    case "4":
                        Menu n = new Menu();
                        n.MenuChinh();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default: break;
                }
            }
        }
        #endregion
    }
}
