using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Đồ_Án_1_125201_
{
    class QLHoaDon
    {
        QLGiayTheThao t = new QLGiayTheThao();
        QLKhachHang k = new QLKhachHang();
        private StreamReader sr;
        private string hoadonban = "HoaDonBan.txt";  //tệp hóa đơn bán
        private string chitiethdb = "ChiTietHDB.txt"; //tệp chi tiết hóa đơn bán
        #region Cấu Trúc Hóa Đơn
        struct HoaDon
        {
            public string maHoaDon, ttKH;
            public double TongTien;
            public int Ngay, Thang, Nam;
        }
        List<HoaDon> hoadon;
        #endregion
        #region Cấu Trúc Chi Tiết Hóa Đơn
        struct ChitietHD
        {
            public string maHoaDon, GiayTheThao;
            public int Soluong;
            public double ThanhTien;
        }
        List<ChitietHD> cthdthethao;
        #endregion
        #region Đọc Tệp Giày Thể Thao
        public void DocTep()
        {
            sr = new StreamReader(hoadonban);
            HoaDon tg = new HoaDon();
            string r;
            hoadon = new List<HoaDon>();
            while ((r = sr.ReadLine()) != null)
            {
                string[] tmp = r.Split('_');
                tg.maHoaDon = tmp[0];
                tg.ttKH = tmp[1];
                tg.TongTien = double.Parse(tmp[2]);
                tg.Ngay = int.Parse(tmp[3]);
                tg.Thang = int.Parse(tmp[4]);
                tg.Nam = int.Parse(tmp[5]);
                hoadon.Add(tg);
            }
            sr.Close();
        }
        #endregion
        #region Đọc Tệp Chi Tiết Giày
        public void docTepCTGiayTheThao()
        {
            //đọc chi tiết bán Giay the thao
            sr = new StreamReader(chitiethdb);
            ChitietHD tg = new ChitietHD();
            string r;
            cthdthethao = new List<ChitietHD>();
            while ((r = sr.ReadLine()) != null)
            {
                string[] tmp = r.Split('_');
                tg.maHoaDon = tmp[0];
                tg.GiayTheThao = tmp[1];
                tg.Soluong = int.Parse(tmp[2]);
                tg.ThanhTien = double.Parse(tmp[3]);
                cthdthethao.Add(tg);
            }
            sr.Close();
        }
        #endregion
        #region Nhập Hóa Đơn Mới
        public void Nhap()
        {
            //tạo hóa đơn mới
            HoaDon h = new HoaDon();
            ChitietHD c = new ChitietHD();
            t.DocTep();
            int i = 1;
            //double thanhTien = 0;
            c.ThanhTien = 0;
            foreach (HoaDon v in hoadon)
            {
                if (i == hoadon.Count())
                {
                    string[] b;
                    b = v.maHoaDon.Split('b');
                    h.maHoaDon = "hdb" + (int.Parse(b[1]) + 1);
                }
                i++;
            }
            c.maHoaDon = h.maHoaDon;
            Console.WriteLine("\n\n\t\t\t\t\t\t\t_________Mời bạn nhập thông tin hóa đơn :" + h.maHoaDon + "_________");
            Console.Write("\n\t\t\t\t\t\t\tNhập mã khách hàng: ");
            h.ttKH = Console.ReadLine();
            if (k.LayMaKH(h.ttKH) != h.ttKH)
            {
                Console.WriteLine("\t\t\t\t\t\t\tMã khách hàng không tồn tại! Hãy thêm thông tin khách hàng trước!");
                k.Them();
                t.HienThi();
                Console.Write("\n\t\t\t\t\t\t\tNhập mã giày thể thao : ");
                c.GiayTheThao = Console.ReadLine();
                do
                {
                    Console.Write("\t\t\t\t\t\t\tSố lượng: ");
                    c.Soluong = int.Parse(Console.ReadLine());
                    if (c.Soluong <= 0)
                        Console.WriteLine("\t\t\t\t\t\t\tVui lòng nhập lại số lượng!");
                    else
                    {
                        c.ThanhTien = t.TinhTien(c.GiayTheThao, c.Soluong);
                        t.GiamSoLuong(c.GiayTheThao, c.Soluong);
                        h.TongTien = h.TongTien + c.ThanhTien;
                    }
                } while (c.Soluong <= 0);
                StreamWriter s = File.AppendText(chitiethdb);
                s.WriteLine(c.maHoaDon + "_" + c.GiayTheThao + "_" + c.Soluong + "_" + c.ThanhTien);
                s.Close();
                docTepCTGiayTheThao();
                while (true)
                {
                    Console.Write("\t\t\t\t\t\t\tBạn có muốn tiếp tục không (c/k)?: ");
                    string kt = Console.ReadLine();
                    if (kt.ToLower() != "c" && kt.ToLower() != "C")
                        break;
                }
            }
            h.Ngay = DateTime.Now.Day;
            h.Thang = DateTime.Now.Month;
            h.Nam = DateTime.Now.Year;
            StreamWriter r = File.AppendText(hoadonban);
            r.WriteLine(h.maHoaDon + "_" + h.ttKH + "_" + h.TongTien + "_" + h.Ngay + "_" + h.Thang + "_" + h.Nam);
            r.Close();
            DocTep();
        }
        #endregion
        #region Hiển Thị Hóa Đơn
        public void HienThiHoaDon()
        {
            k.DocTep();
            DocTep();
            Console.WriteLine("\n\n\t\t\t\t\t\t\t\t  __________ DANH SÁCH HÓA ĐƠN NHẬP __________");
            Console.WriteLine("\t\t\t\t\t╔════════════╦══════════════════════╦══════════════════════╦════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║ Mã hóa đơn ║    Mã khách hàng     ║    Tổng tiền(VNĐ)    ║          Ngày bán          ║");
            Console.WriteLine("\t\t\t\t\t╠════════════╬══════════════════════╬══════════════════════╬════════════════════════════╣");
            foreach (HoaDon t in hoadon)
            {                                                                             //k.laytenkh chưa được
                Console.WriteLine("\t\t\t\t\t║{0,-12}║ {1,-21}║ {2,-21}║        {3,-20}║",
                    t.maHoaDon, t.ttKH, t.TongTien, t.Ngay + "/" + t.Thang + "/" + t.Nam);
            }
            Console.WriteLine("\t\t\t\t\t╚════════════╩══════════════════════╩══════════════════════╩════════════════════════════╝");

        }
        #endregion
        #region Hiển Hóa Đơn Chi Tiết
        public void hienchitiet()
        {
            docTepCTGiayTheThao();
            string s;
            Console.Write("\t\t\t\t\tBạn có muốn xem chi tiết hóa đơn bán không (c/k): ");
            string ch = Console.ReadLine();
            if (ch == "c" || ch == "C")
            {
                do
                {
                    Console.Write("\t\t\t\t\tNhập mã hóa đơn muốn xem chi tiết: ");
                    s = Console.ReadLine();
                    if (s.Trim() == " " || sosanh(s) != true)
                    {
                        Console.WriteLine("\t\t\t\t\tMã vừa nhập không tồn tại!\n");
                    }
                } while (s.Trim() == " " || sosanh(s) != true);
                if (sosanh(s) == true)
                {
                    Console.WriteLine("\t\t\t\t\t╔════════════════╦══════════════════╦══════════════════════╗");
                    Console.WriteLine("\t\t\t\t\t║        Mã      ║ Số lượng         ║   Thành tiền         ║");
                    Console.WriteLine("\t\t\t\t\t╠════════════════╬══════════════════╬══════════════════════╣");
                    foreach (ChitietHD t in cthdthethao)
                    {
                        if (s == t.maHoaDon)
                        {
                            Console.WriteLine("\t\t\t\t\t║ {0,-15}║ {1,-17}║ {2,-21}║", t.GiayTheThao, t.Soluong, t.ThanhTien);
                        }
                        break;
                    }
                    Console.WriteLine("\t\t\t\t\t╚══════════════╩══════════════════╩══════════════════════╝");
                }
                else
                {
                    QLHoaDon hdb = new QLHoaDon();
                    hdb.menu();
                }
            }
        }
        #endregion
        #region So Sánh
        public bool sosanh(string z)
        {
            // sử dụng để tìm kiếm
            bool ok = false;
            foreach (HoaDon x in hoadon)
            {
                if (z == x.maHoaDon) ok = true;
            }
            return ok;
        }
        #endregion
        #region Chức Năng Xóa Hóa Đơn
        public void xoa()
        {
            HienThiHoaDon();
            string x;
            Console.Write("\t\t\t\t\tNhập mã hóa đơn cần xóa: ");
            x = Console.ReadLine();
            if (sosanh(x) == true)
            {
                Console.Write("\t\t\t\t\tBạn có chắc muốn xóa không (c/k): ");
                string t = Console.ReadLine();
                if (t == "c" || t == "C")
                {
                    //lấy vị trí item trong list
                    DocTep();
                    int index = hoadon.FindIndex(delegate (HoaDon tmp)
                    {
                        return tmp.maHoaDon.Equals(x);
                    });
                    StreamWriter TG = File.AppendText("HoaDonBan_xoa.txt");//ghi vào tệp để khôi phục(hóa đơn)
                    foreach (HoaDon n in hoadon)
                    {
                        if (n.maHoaDon == x)
                            TG.WriteLine(n.maHoaDon + "_" + n.ttKH + "_" + n.TongTien + "_" + n.Ngay + "_" + n.Thang + "_" + n.Nam);
                    }
                    TG.Close();
                    docTepCTGiayTheThao();
                    int index2 = cthdthethao.FindIndex(delegate (ChitietHD tmp)
                    {
                        return tmp.maHoaDon.Equals(x);
                    });

                    StreamWriter TG2 = File.AppendText("chitietHDB_xoa.txt");// ghi vào tệp để khôi phục(chi tiết hd)
                    foreach (ChitietHD n in cthdthethao)
                    {
                        if (n.maHoaDon == x)
                            TG2.WriteLine(n.maHoaDon + "_" + n.GiayTheThao + "_" + n.Soluong + "_" + n.ThanhTien);
                    }
                    TG2.Close();
                    hoadon.RemoveAt(index);    // xóa trong list tại vị trí index
                    cthdthethao.RemoveAt(index2);//xóa trong list chi tiết hóa đơn
                    StreamWriter tg1 = new StreamWriter(hoadonban);// ghi lại vào tệp
                    foreach (HoaDon c in hoadon)
                    {
                        tg1.WriteLine(c.maHoaDon + "_" + c.ttKH + "_" + c.TongTien + "_" + c.Ngay + "_" + c.Thang + "_" + c.Nam);
                    }
                    tg1.Close();
                    DocTep();
                    StreamWriter tg2 = new StreamWriter(chitiethdb);// ghi lại vào tệp
                    foreach (ChitietHD c in cthdthethao)
                    {
                        tg2.WriteLine(c.maHoaDon + "_" + c.GiayTheThao + "_" + c.Soluong + "_" + c.ThanhTien);
                    }
                    tg2.Close();
                    docTepCTGiayTheThao();
                    Console.Write("\n\t\t\t\t\tXóa thành công! (^_^)");
                }
                else
                {
                    Console.WriteLine("\t\t\t\t\tXóa không thành công!\n");
                }
            }
            else Console.WriteLine("\t\t\t\t\tKhông tìm thấy mã hóa đơn vừa nhập!");
            Console.Write("\n\t\t\t\t\tẤn phím bất kỳ để quay lại! ");
        }
        #endregion
        #region Thống Kê Theo Ngày
        public void thongKeNgay()
        {
            DocTep();
            double doanhthu = 0;
            Console.WriteLine("\n\n\t\t\t\t\t\t\tNhập ngày / tháng / năm cần thống kê: ");
            Console.Write("\t\t\t\t\t\t\tNgày: ");
            int s = int.Parse(Console.ReadLine());
            Console.Write("\t\t\t\t\t\t\tTháng: ");
            int r = int.Parse(Console.ReadLine());
            Console.Write("\t\t\t\t\t\t\tNăm: ");
            int t = int.Parse(Console.ReadLine());
            foreach (HoaDon x in hoadon)
            {
                if (s == x.Ngay && r == x.Thang && t == x.Nam)
                    doanhthu = doanhthu + x.TongTien;
            }
            Console.Write("\n\t\t\t\t\t\t\tTổng doanh thu ngày " + s + "/" + r + "/" + t + " là: " + doanhthu + " (VNĐ)");
            Console.Write("\n\n\t\t\t\t\t\t\tẤn phím bất kỳ để quay lại!");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
        #region Thống Kê Theo Tháng
        public void thongKeThang()
        {
            DocTep();
            double doanhthu = 0;
            Console.WriteLine("\n\n\t\t\t\t\t\t\tNhập tháng / năm cần thống kê: ");
            Console.Write("\t\t\t\t\t\t\tTháng: ");
            int r = int.Parse(Console.ReadLine());
            Console.Write("\t\t\t\t\t\t\tNăm: ");
            int t = int.Parse(Console.ReadLine());
            foreach (HoaDon x in hoadon)
            {
                if (r == x.Thang && t == x.Nam)
                    doanhthu = doanhthu + x.TongTien;
            }
            Console.Write("\n\t\t\t\t\t\t\tTổng doanh thu tháng " + r + "/" + t + " là: " + doanhthu + " (VNĐ)");
            Console.Write("\n\n\t\t\t\t\t\t\tẤn phím bất kỳ để quay lại!");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
        #region Thống Kê Theo Năm
        public void thongKeNam()
        {
            DocTep();
            double doanhthu = 0;
            Console.WriteLine("\n\n\t\t\t\t\t\t\tNhập năm cần thống kê: ");
            Console.Write("\t\t\t\t\t\t\tNăm: ");
            int t = int.Parse(Console.ReadLine());
            foreach (HoaDon x in hoadon)
            {
                if (t == x.Nam)
                    doanhthu = doanhthu + x.TongTien;
            }
            Console.Write("\n\t\t\t\t\t\t\tTổng doang thu năm " + t + " là: " + doanhthu + " (VNĐ)");
            Console.Write("\n\n\t\t\t\t\t\t\tẤn phím bất kỳ để quay lại!");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
        #region Menu Hóa Đơn
        public void menu()
        {
            bool stop = false;
            while (!stop)
            {
                Console.Clear();
                Console.Write("\n\n\t\t\t\t\t\t\t ╔══════════════════════════════════════════════════════════╗");
                Console.Write("\n\t\t\t\t\t\t\t ║                       QUẢN LÝ HÓA ĐƠN                    ║");
                Console.Write("\n\t\t\t\t\t\t\t ╠══════════════════════════════════════════════════════════╣");
                Console.Write("\n\t\t\t\t\t\t\t ║                                                          ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╔═══╤══════════════════════════════╗           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 1 │ Hóa đơn mới                  ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 2 │ Xem danh sách hóa đơn        ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 3 │ Xóa hóa đơn                  ║           ║");
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
                string s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        Console.Clear(); Nhap();
                        Console.Write("\n\t\t\t\t\t\t\tẤn phím bất kì để quay lại!");
                        Console.ReadKey(); break;
                    case "2":
                        Console.Clear(); HienThiHoaDon(); hienchitiet();
                        Console.Write("\n\t\t\t\t\t\t\tẤn phím bất kì để quay lại!");
                        Console.ReadKey(); break;
                    case "3": Console.Clear(); xoa(); Console.ReadKey(); break;
                    case "4": Menu menu = new Menu(); menu.MenuChinh(); break;
                    case "5": Environment.Exit(0); break;
                    default: break;
                }
            }
        }
        #endregion
    }
}
