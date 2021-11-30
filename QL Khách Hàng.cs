using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;


namespace Đồ_Án_1_125201_
{
    class QLKhachHang
    {
        private StreamReader sr;
        private string fileName = "KhachHang.txt";
        #region Cấu Trúc Khách Hàng
        struct KhachHang
        {
            public string MaKhachHang, TenKhachHang, GioiTinh, SoDienThoai, DiaChi;
        }
        List<KhachHang> khachhang;
        #endregion
        public QLKhachHang() { }
        #region Đọc Tệp
        public void DocTep()
        {
            sr = new StreamReader(fileName);
            KhachHang tg = new KhachHang();
            string r;
            khachhang = new List<KhachHang>();
            while ((r = sr.ReadLine()) != null)
            {
                string[] tmp = r.Split('_');
                tg.MaKhachHang = tmp[0];
                tg.TenKhachHang = tmp[1];
                tg.GioiTinh = tmp[2];
                tg.SoDienThoai = tmp[3];
                tg.DiaChi = tmp[4];
                khachhang.Add(tg);

            }
            sr.Close();
        }
        #endregion
        #region Hiển Thị Thông Tin Khách Hàng
        public void hienThi()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t╔═══════════╦══════════════════════════════════════╦═══════════════╦═════════════════╦═════════════════════════════════╗");
            Console.WriteLine("\t\t\t║ MÃ KHÁCH HÀNG ║           TÊN KHÁCH HÀNG             ║  GIỚI TÍNH    ║  SỐ ĐIỆN THOẠI  ║        ĐỊA CHỈ                  ║");
            Console.WriteLine("\t\t\t╠═══════════════╬══════════════════════════════════════╬═══════════════╬═════════════════╬═════════════════════════════════╣");
            foreach (KhachHang x in khachhang)
            {
                Console.WriteLine("\t\t\t║{0,-15}║{1,-38}║{2,-15}║{3,-17}║{4,-33}║", x.MaKhachHang, x.TenKhachHang, x.GioiTinh, x.SoDienThoai, x.DiaChi);
            }
            Console.WriteLine("\t\t\t╚═══════════════╩══════════════════════════════════════╩═══════════════╩═════════════════╩═════════════════════════════════╝");
        }
        #endregion
        #region So Sánh
        public bool sosanh(string z)
        {
            // sử dụng để tìm kiếm
            bool ok = false;
            foreach (KhachHang x in khachhang)
            {
                if (z == x.MaKhachHang) ok = true;
            }
            return ok;
        }
        #endregion
        #region Thêm Khách Hàng
        public void Them()
        {
            StreamWriter r = File.AppendText("KhachHang.txt");
            KhachHang x = new KhachHang();
            int i = 1;
            foreach (KhachHang khach in khachhang)// mã tự tăng 
            {
                if (i == khachhang.Count())
                {
                    string[] s;
                    s = khach.MaKhachHang.Split('h');
                    x.MaKhachHang = "kh" + (int.Parse(s[1]) + 1);
                }
                i++;
            }
            Console.WriteLine("\n\n\t\t\t\t\t\t\t_________Mời Bạn Nhập Thông Tin Khách Hàng_________");

            Console.Write("\n\t\t\t\t\t\t\tMã Khách Hàng : ");
            x.MaKhachHang = Console.ReadLine();
            Console.Write("\n\t\t\t\t\t\t\tTên Khách Hàng: ");
            x.TenKhachHang = Console.ReadLine();
            Console.Write("\t\t\t\t\t\t\tGiới tính: 1-Nam / 2-Nữ: ");
            char ch = char.Parse(Console.ReadLine());
            switch (ch)
            {
                case '1':
                    x.GioiTinh = "Nam";
                    break;
                case '2':
                    x.GioiTinh = "Nu";
                    break;
            }
            //x.gt = Console.ReadLine();
            Console.Write("\t\t\t\t\t\t\tSố điện thoại: ");
            x.SoDienThoai = Console.ReadLine();
            Console.Write("\t\t\t\t\t\t\tĐịa chỉ: ");
            x.DiaChi = Console.ReadLine();
            r.WriteLine(x.MaKhachHang + "_" + x.TenKhachHang + "_" + x.GioiTinh + "_" + x.SoDienThoai + "_" + x.DiaChi);
            r.Close();
            DocTep();
            Console.Write("\n\t\t\t\t\t\t\tThêm Thành Công! (^_^)\n\t\t\t\t\t\t\tNhấn Phím Bất Kì Để Quay Lại! ");
        }
        #endregion
        #region Xóa Thông Tin Khách Hàng
        public void xoa()
        {
            string x;
            hienThi();
            do
            {
                Console.Write("\t\t\tNhập Mã Khách Hàng Cần Xóa: ");
                x = Console.ReadLine();
                if (x.Trim() == " " || sosanh(x) != true)
                {
                    Console.WriteLine("\t\t\tKhông Tìm Thấy Mã Vừa Nhập!\n");
                }
            } while (x.Trim() == " " || sosanh(x) != true);
            if (sosanh(x) == true)
            {
                Console.Write("\t\t\tBạn Có Chắc Muốn Xóa Không (c/k): ");
                string t = Console.ReadLine();
                if (t == "c" || t == "C")
                {
                    //lấy vị trí item trong list
                    int index = khachhang.FindIndex(delegate (KhachHang tmp)
                    {
                        return tmp.MaKhachHang.Equals(x);
                    });
                    StreamWriter tg = File.AppendText("KhachHang_xoa.txt");// ghi vào tệp xóa (để khôi phục)
                    foreach (KhachHang a in khachhang)
                    {
                        if (a.MaKhachHang == x)
                            tg.WriteLine(a.MaKhachHang + "_" + a.TenKhachHang + "_" + a.GioiTinh + "_" + a.SoDienThoai + "_" + a.DiaChi);
                    }
                    tg.Close();
                    khachhang.RemoveAt(index);// xóa trong list tại vị trí index
                    StreamWriter tg1 = new StreamWriter("KhachHang.txt");// ghi lại vào tệp
                    foreach (KhachHang c in khachhang)
                    {
                        // if (c.maKH == x)
                        tg1.WriteLine(c.MaKhachHang + "_" + c.TenKhachHang + "_" + c.GioiTinh + "_" + c.SoDienThoai + "_" + c.DiaChi);
                    }
                    tg1.Close();
                    DocTep();
                    Console.Write("\n\t\t\tXóa Thành Công! (^_^)\n\t\t\tNhấn Phím Bất Kì Để Quay Lại! ");
                }
                else
                {
                    Console.WriteLine("\t\t\tXóa Không Thành Công!");
                }
            }
        }
        #endregion
        #region Sửa Thông Tin Khách Hàng
        public void sua()
        {
            string x;
            hienThi();
            do
            {
                Console.Write("\t\t\tNhập Mã Khách Hàng Cần Sửa: ");
                x = Console.ReadLine();
                if (x.Trim() == " " || sosanh(x) != true)
                {
                    Console.WriteLine("\t\t\tKhông Tìm Thấy Mã Vừa Nhập!\n");
                }
            } while (x.Trim() == " " || sosanh(x) != true);
            if (sosanh(x) == true)
            {

                //lấy vị trí item trong list
                int index = khachhang.FindIndex(delegate (KhachHang tmp)
                {
                    return tmp.MaKhachHang.Equals(x);
                });
                KhachHang z = new KhachHang();
                z.MaKhachHang = LayMaKH(x);
                khachhang.RemoveAt(index);// xóa

                StreamWriter r = new StreamWriter("KhachHang.txt");

                //Console.Write("Mã khách hàng: ");
                //z.maKH = Console.ReadLine();
                Console.Write("\t\t\tTên Khách Hàng: ");
                z.TenKhachHang = Console.ReadLine();
                //Console.Write("\t\t\tGiới tính: ");
                //z.gt = Console.ReadLine();
                Console.Write("\t\t\tGiới Tính: 1-Nam / 2-Nữ: ");
                char ch = char.Parse(Console.ReadLine());
                switch (ch)
                {
                    case '1': z.GioiTinh = "Nam"; break;
                    case '2': z.GioiTinh = "Nu"; break;
                }
                Console.Write("\t\t\tSố Điện Thoại: ");
                z.SoDienThoai = Console.ReadLine();
                Console.Write("\t\t\tĐịa Chỉ: ");
                z.DiaChi = Console.ReadLine();

                khachhang.Insert(index, z);// chèn vào vị trí index
                foreach (KhachHang c in khachhang)// ghi lại vào tệp
                {
                    r.WriteLine(c.MaKhachHang + "_" + c.TenKhachHang + "_" + c.GioiTinh + "_" + c.SoDienThoai + "_" + c.DiaChi);
                }
                r.Close();
                DocTep();
                Console.Write("\n\t\t\tSửa Thành Công! (^_^)\n\t\t\tNhấn Phím Bất Kì Để Quay Lại! ");
            }
        }
        #endregion
        #region Lấy Mã Khách Hàng
        public string LayMaKH(string makh)
        {
            DocTep();
            string khach = "";
            foreach (KhachHang d in khachhang)
            {
                if (d.MaKhachHang == makh)
                    khach = d.MaKhachHang;
            }
            return khach;
        }
        #endregion
        #region Lấy Tên Khách Hàng
        public string GetName(string ma)
        {
            string khach = "";
            foreach (KhachHang d in khachhang)
            {
                if (d.MaKhachHang == ma)
                    khach = d.TenKhachHang;
            }
            return khach;
        }
        #endregion
        #region Tìm Kiếm Khách Hàng
        public void TimKiem()
        {
            DocTep();
            int kt = 0;
            Console.Write("\n\t\t\tNhập Thông Tin Khách Hàng Muốn Tìm Kiếm: ");
            string s = Console.ReadLine();
            Console.WriteLine("\t\t\t╔═══════════════╦══════════════════════════════════════╦═══════════════╦═════════════════╦═════════════════════════════════╗");
            Console.WriteLine("\t\t\t║ MÃ KHÁCH HÀNG ║           TÊN KHÁCH HÀNG             ║  GIỚI TÍNH    ║  SỐ ĐIỆN THOẠI  ║        ĐỊA CHỈ                  ║");
            Console.WriteLine("\t\t\t╠═══════════════╬══════════════════════════════════════╬═══════════════╬═════════════════╬═════════════════════════════════╣");
            foreach (KhachHang x in khachhang)
            {
                if (s == x.MaKhachHang || s == x.TenKhachHang || s == x.GioiTinh || s == x.SoDienThoai || s == x.DiaChi)
                {
                    kt++;
                    Console.WriteLine("\t\t\t║{0,-15}║{1,-38}║{2,-15}║{3,-17}║{4,-33}║", x.MaKhachHang, x.TenKhachHang, x.GioiTinh, x.SoDienThoai, x.DiaChi);
                }
            }
            Console.WriteLine("\t\t\t╚═══════════════╩══════════════════════════════════════╩═══════════════╩═════════════════╩═════════════════════════════════╝");

            if (kt == 0)
            {
                Console.Clear();
                Console.WriteLine("\t\t\tKhông Tìm Thấy Thông Tin Phù Hợp!");
            }
            Console.Write("\t\t\tBạn Có Muốn Tìm Tiếp Không (c/k): ");
            string m = Console.ReadLine();
            if (m == "c" || m == "C")
                TimKiem();
            else
            {
                Menu khachhang = new Menu();
                khachhang.MenuChinh();
            }
        }
        #endregion
        #region Menu Chức Năng
        public void menu()
        {
            bool stop = false;
            while (!stop)
            {
                Console.Clear();
                Console.Write("\n\n\t\t\t\t\t\t\t ╔══════════════════════════════════════════════════════════╗");
                Console.Write("\n\t\t\t\t\t\t\t ║                   QUẢN LÝ KHÁCH HÀNG                     ║");
                Console.Write("\n\t\t\t\t\t\t\t ╠══════════════════════════════════════════════════════════╣");
                Console.Write("\n\t\t\t\t\t\t\t ║                                                          ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╔═══╤══════════════════════════════╗           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 1 │ Hiển thị danh sách khách hàng║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 2 │ Thêm khách hàng              ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 3 │ Sửa thông tin khách hàng     ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 4 │ Xóa khách hàng               ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 5 │ Quay lại                     ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 6 │ Thoát                        ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║   │ Chọn chức năng:              ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╚═══╧══════════════════════════════╝           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║                                                          ║");
                Console.Write("\n\t\t\t\t\t\t\t ║                                                          ║");
                Console.Write("\n\t\t\t\t\t\t\t ╚══════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(91, 19);
                string s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        Console.Clear();
                        hienThi();
                        Console.Write("\t\t\tNhấn Phím Bất Kỳ Để Quay Lại!");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Them();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear(); sua();
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear(); xoa();
                        Console.ReadKey();
                        break;
                    case "5":
                        Menu menu = new Menu();
                        menu.MenuChinh();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default: break;
                }
            }
        }
        #endregion
    }
}