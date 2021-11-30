using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Đồ_Án_1_125201_
{
    class QLNhanVien
    {
        private StreamReader sr;
        private string fileName = "NhanVien.txt";
        struct NhanVien
        {
            public string MaNhanVien, TenNhanVien, GioiTinh, SoDienThoai, DiaChi;
            public int  SoGioLam;

        }
        List<NhanVien> nhanvien;
        public QLNhanVien() { }
        #region Đọc Tệp Nhân Viên
        public void DocTep()
        {
            sr = new StreamReader(fileName);
            NhanVien tg = new NhanVien();
            string r;
            nhanvien = new List<NhanVien>();
            while ((r = sr.ReadLine()) != null)
            {
                string[] tmp = r.Split('_');
                tg.MaNhanVien = tmp[0];
                tg.TenNhanVien = tmp[1];
                tg.GioiTinh = tmp[2];
                tg.SoDienThoai = tmp[3];
                tg.DiaChi = tmp[4];
                tg.SoGioLam = int.Parse(tmp[5]);
                nhanvien.Add(tg);

            }
            sr.Close();
        }
        #endregion
        #region Hiển Thị Thông Tin Nhân Viên
        public void hienThi()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t╔═══════════════╦═══════════════════════╦═══════════════╦═════════════════╦══════════════╦═══════════════╗");
            Console.WriteLine("\t\t\t║ MÃ NHÂN VIÊN  ║    TÊN NHÂN VIÊN      ║  GIỚI TÍNH    ║  SỐ ĐIỆN THOẠI  ║  ĐỊA CHỈ     ║ Số Giờ Làm    ║");
            Console.WriteLine("\t\t\t╠═══════════════╬═══════════════════════╬═══════════════╬═════════════════╬══════════════╬═══════════════╣");
            foreach (NhanVien x in nhanvien)
            {
                Console.WriteLine("\t\t\t║{0,-15}║{1,-38}║{2,-15}║{3,-17}║{4,-33}║", x.MaNhanVien, x.TenNhanVien, x.GioiTinh, x.SoDienThoai, x.DiaChi, x.SoGioLam);
            }
            Console.WriteLine("\t\t\t╚═══════════════╩═══════════════════════╩═══════════════╩═════════════════╩══════════════════════════════╝");
        }
        #endregion
        #region So Sánh
        public bool sosanh(string z)
        {
            // sử dụng để tìm kiếm
            bool ok = false;
            foreach (NhanVien x in nhanvien)
            {
                if (z == x.MaNhanVien) ok = true;
            }
            return ok;
        }
        #endregion
        #region Thêm Thông Tin Nhân Viên
        public void Them()
        {
            StreamWriter r = File.AppendText("NhanVien.txt");
            NhanVien x = new NhanVien();
            //int i = 1;
            //foreach (NhanVien vien in nhanvien)// mã tự tăng 
            //{
            //    if (i == nhanvien.Count())
            //    {
            //        string[] s;
            //        s = vien.MaNhanVien.Split('v');
            //        x.MaNhanVien = "nv" + (int.Parse(s[1]) + 1);
            //    }
            //    i++;
            //}
            Console.WriteLine("\n\n\t\t\t\t\t\t\t_________Mời Bạn Nhập Thông Tin Nhân Viên_________");

            Console.Write("\n\t\t\t\t\t\t\tMã Nhân Viên : ");
            x.MaNhanVien = Console.ReadLine();
            Console.Write("\n\t\t\t\t\t\t\tTên Nhân Viên: ");
            x.TenNhanVien = Console.ReadLine();
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
            Console.Write("\t\t\t\t\t\t\tNhập Số Giờ Làm : ");
            x.SoGioLam = int.Parse(Console.ReadLine());
            r.WriteLine(x.MaNhanVien + "_" + x.TenNhanVien + "_" + x.GioiTinh + "_" + x.SoDienThoai + "_" + x.DiaChi + "_" +  x.SoGioLam);
            r.Close();
            DocTep();
            Console.Write("\n\t\t\t\t\t\t\tThêm Thành Công! (^_^)\n\t\t\t\t\t\t\tNhấn Phím Bất Kì Để Quay Lại! ");
        }
        #endregion
        #region Xóa Thông Tin Nhân Viên
        public void xoa()
        {
            string x;
            hienThi();
            do
            {
                Console.Write("\t\t\tNhập mã khách hàng cần xóa: ");
                x = Console.ReadLine();
                if (x.Trim() == " " || sosanh(x) != true)
                {
                    Console.WriteLine("\t\t\tKhông tìm thấy mã vừa nhập!\n");
                }
            } while (x.Trim() == " " || sosanh(x) != true);
            if (sosanh(x) == true)
            {
                Console.Write("\t\t\tBạn có chắc muốn xóa không (c/k): ");
                string t = Console.ReadLine();
                if (t == "c" || t == "C")
                {
                    //lấy vị trí item trong list
                    int index = nhanvien.FindIndex(delegate (NhanVien tmp)
                    {
                        return tmp.MaNhanVien.Equals(x);
                    });
                    StreamWriter tg = File.AppendText("NhanVien_Xoa.txt");// ghi vào tệp xóa (để khôi phục)
                    foreach (NhanVien a in nhanvien)
                    {
                        if (a.MaNhanVien == x)
                            tg.WriteLine(a.MaNhanVien + "_" + a.TenNhanVien + "_" + a.GioiTinh + "_" + a.SoDienThoai + "_" + a.DiaChi + "_" +  a.SoGioLam);
                    }
                    tg.Close();
                    nhanvien.RemoveAt(index);// xóa trong list tại vị trí index
                    StreamWriter tg1 = new StreamWriter("NhanVien.txt");// ghi lại vào tệp
                    foreach (NhanVien c in nhanvien)
                    {
                        // if (c.maKH == x)
                        tg1.WriteLine(c.MaNhanVien + "_" + c.TenNhanVien + "_" + c.GioiTinh + "_" + c.SoDienThoai + "_" + c.DiaChi + "_" +  c.SoGioLam);
                    }
                    tg1.Close();
                    DocTep();
                    Console.Write("\n\t\t\tXóa thành công! (^_^)\n\t\t\tNhấn phím bất kì để quay lại! ");
                }
                else
                {
                    Console.WriteLine("\t\t\tXóa không thành công!");
                }
            }
        }
        #endregion
        #region Sửa Thông Tin Nhân Viên
        public void sua()
        {
            string x;
            hienThi();
            do
            {
                Console.Write("\t\t\tNhập mã khách hàng cần sửa: ");
                x = Console.ReadLine();
                if (x.Trim() == " " || sosanh(x) != true)
                {
                    Console.WriteLine("\t\t\tKhông tìm thấy mã vừa nhập!\n");
                }
            } while (x.Trim() == " " || sosanh(x) != true);
            if (sosanh(x) == true)
            {

                //lấy vị trí item trong list
                int index = nhanvien.FindIndex(delegate (NhanVien tmp)
                {
                    return tmp.MaNhanVien.Equals(x);
                });
                NhanVien z = new NhanVien();
                z.MaNhanVien = LayMaNV(x);
                nhanvien.RemoveAt(index);// xóa

                StreamWriter r = new StreamWriter("KhachHang.txt");

                //Console.Write("Mã khách hàng: ");
                //z.maKH = Console.ReadLine();
                Console.Write("\t\t\tTên khách hàng: ");
                z.TenNhanVien = Console.ReadLine();
                //Console.Write("\t\t\tGiới tính: ");
                //z.gt = Console.ReadLine();
                Console.Write("\t\t\tGiới tính: 1-Nam / 2-Nữ: ");
                char ch = char.Parse(Console.ReadLine());
                switch (ch)
                {
                    case '1': z.GioiTinh = "Nam"; break;
                    case '2': z.GioiTinh = "Nu"; break;
                }
                Console.Write("\t\t\tSố điện thoại: ");
                z.SoDienThoai = Console.ReadLine();
                Console.Write("\t\t\tĐịa chỉ: ");
                z.DiaChi = Console.ReadLine();
                Console.Write("\t\t\tNhập Số Giờ Làm : ");
                z.SoGioLam = int.Parse(Console.ReadLine());

                nhanvien.Insert(index, z);// chèn vào vị trí index
                foreach (NhanVien c in nhanvien)// ghi lại vào tệp
                {
                    r.WriteLine(c.MaNhanVien + "_" + c.TenNhanVien + "_" + c.GioiTinh + "_" + c.SoDienThoai + "_" + c.DiaChi + "_" +  c.SoGioLam);
                }
                r.Close();
                DocTep();
                Console.Write("\n\t\t\tSửa thành công! (^_^)\n\t\t\tNhấn phím bất kì để quay lại! ");
            }
        }
        #endregion
        #region Lấy Mã Nhân Viên
        public string LayMaNV(string manv)
        {
            DocTep();
            string khach = "";
            foreach (NhanVien d in nhanvien)
            {
                if (d.MaNhanVien == manv)
                    khach = d.MaNhanVien;
            }
            return khach;
        }
        #endregion
        #region Lấy Tên Nhân Viên
        public string GetName(string ma)
        {
            string khach = "";
            foreach (NhanVien d in nhanvien)
            {
                if (d.MaNhanVien == ma)
                    khach = d.TenNhanVien;
            }
            return khach;
        }
        #endregion
        #region Tính Lương Nhân Viên
        public void TinhLuong()
        {
            DocTep();
            int LuongThoiVu = 25000;
            Console.Write("\n\n\t\t\t\t\t\t\tNhập Số Giờ Đã Làm : ");
            int s = int.Parse(Console.ReadLine());
            Console.Write("\n\t\t\t\t\t\t\tTổng Số Lương Đã Làm  " + s + " là: " + LuongThoiVu * s + " (VNĐ)");
            Console.Write("\n\n\t\t\t\t\t\t\tẤn phím bất kỳ để quay lại!");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
        #region Tìm Kiếm Nhân Viên
        public void TimKiem()
        {
            DocTep();
            int kt = 0;
            Console.Write("\n\t\t\tNhập Thông Tin Nhân Viên Muốn Tìm Kiếm: ");
            string s = Console.ReadLine();
            Console.WriteLine("\t\t\t╔═══════════════╦══════════════════════════════════════╦═══════════════╦═════════════════╦═════════════════════════════════╗");
            Console.WriteLine("\t\t\t║ MÃ KHÁCH HÀNG ║           TÊN KHÁCH HÀNG             ║  GIỚI TÍNH    ║  SỐ ĐIỆN THOẠI  ║        ĐỊA CHỈ                  ║");
            Console.WriteLine("\t\t\t╠═══════════════╬══════════════════════════════════════╬═══════════════╬═════════════════╬═════════════════════════════════╣");
            foreach (NhanVien x in nhanvien)
            {
                if (s == x.MaNhanVien || s == x.TenNhanVien || s == x.GioiTinh || s == x.SoDienThoai || s == x.DiaChi )
                {
                    kt++;
                    Console.WriteLine("\t\t\t║{0,-15}║{1,-38}║{2,-15}║{3,-17}║{4,-33}║", x.MaNhanVien, x.TenNhanVien, x.GioiTinh, x.SoDienThoai, x.DiaChi);
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
                Console.Write("\n\t\t\t\t\t\t\t ║                   QUẢN LÝ NHÂN VIÊN                      ║");
                Console.Write("\n\t\t\t\t\t\t\t ╠══════════════════════════════════════════════════════════╣");
                Console.Write("\n\t\t\t\t\t\t\t ║                                                          ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╔═══╤══════════════════════════════╗           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 1 │ Hiển Thị Thông Tin Nhân Viên ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 2 │ Thêm Nhân Viên               ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 3 │ Sửa Thông Tin Nhân Viên      ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 4 │ Xóa Nhân Viên                ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 5 │ Tính Lương                   ║           ║");
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
                        Console.Write("\t\t\tNhấn phím bất kỳ để quay lại!");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Them();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear(); 
                        sua();
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear(); 
                        xoa();
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        TinhLuong();
                        Console.ReadKey();
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
