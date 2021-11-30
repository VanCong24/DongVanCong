using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Đồ_Án_1_125201_
{
    class QLGiayTheThao
    {
        private StreamReader sr;
        private string fileName = "TheThao.txt";
        #region Cấu Trúc Giày Thể Thao
        struct GiayTheThao
        {
            public string MaGiay;
            public string TenGiay;
            public string MauSac;
            public int Size;
            public double DonGia;
            public int SoLuong;
        }
        #endregion
        List<GiayTheThao> TheThao;
        public QLGiayTheThao() { }
        #region Đọc Tệp Thông Tin Giày
        public void DocTep()
        {
            sr = new StreamReader(fileName);
            GiayTheThao tg = new GiayTheThao();
            string r;
            TheThao = new List<GiayTheThao>();
            while ((r = sr.ReadLine()) != null)
            {
                string[] tmp = r.Split('_');// tách thông tin từng dòng
                tg.MaGiay = tmp[0];
                tg.TenGiay = tmp[1];
                tg.MauSac = tmp[2];
                tg.Size = int.Parse(tmp[4]);
                tg.DonGia = double.Parse(tmp[5]);
                tg.SoLuong = int.Parse(tmp[6]);
                TheThao.Add(tg);//đẩy vào list
            }
            sr.Close();
        }
        #endregion
        #region Hiển Thị Thông Tin Giày
        public void HienThi()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\t                           __________ DANH SÁCH GIÀY THỂ THAO __________");
            Console.WriteLine("\t\t\t╔════════════════╦══════════════════╦══════════════╦════════════╦══════════════╦═════════════╗");
            Console.WriteLine("\t\t\t║ MÃ ĐÔI GIÀY    ║ TÊN HIỆU GIÀY    ║  MÀU SẮC     ║  KÍCH CỠ   ║  ĐƠN GIÁ     ║ SỐ LƯỢNG    ║");
            Console.WriteLine("\t\t\t╠════════════════║══════════════════╬══════════════╬════════════╬══════════════╬═════════════╣");
            foreach (GiayTheThao t in TheThao)
            {
                Console.WriteLine("\t\t\t║{0,-16}║{1,20}║{2,-16}║{3,-17}║{4,-14}║{5,-16}║{6,-15}║", t.MaGiay, t.TenGiay, t.MauSac, t.Size, t.DonGia, t.SoLuong);
            }
            Console.WriteLine("\t\t\t╚════════════════╩══════════════════╩══════════════╩════════════╩══════════════╩═════════════╝");
        }
        #endregion
        #region Thêm Thông Tin Giày
        public void Them()
        {
            StreamWriter r = File.AppendText(fileName);
            GiayTheThao t = new GiayTheThao();
            //int i = 1;
            //foreach (GiayTheThao thethao in TheThao)
            //{
            //    if (i == TheThao.Count())
            //    {
            //        string[] s;
            //        s = thethao.TenGiay.Split('t');// tach den het ki tu t
            //        t.MaGiay = "tt" + (int.Parse(s[1]) + 1);// ma tu tang
            //    }
            //    i++;
            //}
            Console.WriteLine("\n\n\t\t\t\t\t__________ Mời Bạn Nhập Thông Tin Giày __________");
            Console.Write("\n\n\t\t\t\tNhập Mã Giày : ");
            t.MaGiay = Console.ReadLine();
            Console.Write("\n\n\t\t\t\tNhập Tên Hiệu Giày : ");
            t.TenGiay = Console.ReadLine();
            Console.Write("\n\n\t\t\t\tNhập Màu Sắc Giày : ");
            t.MauSac = Console.ReadLine();
            do
            {
                Console.Write("\n\n\t\t\t\tNhập Kích Cỡ Giày : ");
                t.Size = int.Parse(Console.ReadLine());
                if (t.Size <= 0)
                    Console.WriteLine("\t\t\t\t\t\t\t\tBạn nhập sai! Hãy nhập lại!");
            } while (t.Size <= 0);
            do
            {
                Console.Write("\n\n\t\t\t\tNhập Đơn Giá : ");
                t.DonGia = double.Parse(Console.ReadLine());
                if (t.DonGia <= 0)
                    Console.WriteLine("\t\t\t\t\t\t\t\tBạn nhập sai! Hãy nhập lại!");
            } while (t.DonGia <= 0);
            do
            {

                Console.Write("\t\t\t\tNhập số lượng: ");
                t.SoLuong = int.Parse(Console.ReadLine());
                if (t.SoLuong <= 0)
                    Console.WriteLine("\t\t\t\t\t\t\tBạn nhập sai! Hãy nhập lại!");
            } while (t.SoLuong <= 0);
            r.WriteLine(t.MaGiay + "_" + t.TenGiay + "_" + t.MauSac + "_" + t.Size + "_" + t.DonGia + "_" + t.SoLuong);
            r.Close();
            DocTep();
            Console.Write("\n\t\t\t\t\t\tThêm thành công! (^_^)\n\t\t\t\t\t\tNhấn phím bất kì để quay lại!");
        }
        #endregion
        #region So Sánh Thông Tin Giày
        public bool SoSanh(string z)
        {
            // Su dung de tim kiem
            bool ok = false;
            foreach (GiayTheThao t in TheThao)
            {
                if (z == t.MaGiay) ok = true;
            }
            return ok;
        }
        #endregion
        #region Xóa Thông Tin Giày
        public void Xoa()
        {
            string t;
            HienThi();
            do
            {
                Console.Write("\n\n\t\t\t\tNhập Mã Đôi Giày Cần Xóa : ");
                t = Console.ReadLine();
                if (t.Trim() == " " || SoSanh(t) != true)
                {
                    Console.WriteLine("\t\t\t\t\t\t\tKhông tìm thấy mã vừa nhập!\n");
                }
            } while (t.Trim() == " " || SoSanh(t) != true);
            if (SoSanh(t) == true)
            {
                Console.Write("\t\t\t\t\t\t\tBạn có chắc muốn xóa không (c/k): ");
                string e = Console.ReadLine();
                if (e == "c" || e == "C")
                {
                    //lấy vị trí item trong list
                    int index = TheThao.FindIndex(delegate (GiayTheThao tmp)
                    {
                        return tmp.MaGiay.Equals(t);
                    });
                    StreamWriter tg = File.AppendText("TheThao_Xoa.txt");// ghi vào tệp xóa (để khôi phục)
                    foreach (GiayTheThao g in TheThao)
                    {
                        if (g.MaGiay == t)
                            tg.WriteLine(g.MaGiay + "_" + g.TenGiay + "_" + g.MauSac + "_" + g.Size + "_" + g.DonGia + "_" + g.SoLuong);
                    }
                    tg.Close();
                    TheThao.RemoveAt(index);// xóa trong list tại vị trí index
                    StreamWriter tg1 = new StreamWriter("TheThao.txt");// ghi lại vào tệp
                    foreach (GiayTheThao c in TheThao)
                    {
                        // if (c.maDoAn == a)
                        tg1.WriteLine(c.MaGiay + "_" + c.TenGiay + "_" + c.MauSac +  "_" + c.Size + "_" + c.DonGia + "_", c.SoLuong);
                    }
                    tg1.Close();
                    DocTep();
                    Console.Write("\n\t\t\t\t\t\t\tXóa thành công! (^_^)\n\t\t\t\t\t\t\tNhấn phím bất kì để quay lại!");
                }
                else
                {
                    Console.WriteLine("\t\t\t\t\t\t\tXóa không thành công!");
                }
            }
        }
        #endregion
        #region Sửa Thông Tin Giày
        public void Sua()
        {
            string t;
            HienThi();
            do
            {
                Console.Write("\t\t\t\t\tNhập mã giày thể thao cần sửa: ");
                t = Console.ReadLine();
                if (t.Trim() == " " || SoSanh(t) != true)
                {
                    Console.WriteLine("\t\t\t\t\tKhông tìm thấy mã vừa nhập!\n");
                }
            } while (t.Trim() == " " || SoSanh(t) != true);
            if (SoSanh(t) == true)
            {
                //lấy vị trí item trong list
                int index = TheThao.FindIndex(delegate (GiayTheThao tmp)
                {
                    return tmp.MaGiay.Equals(t);
                });
                GiayTheThao z = new GiayTheThao();
                z.MaGiay = layMaGiay(t);// không cho phép sửa mã> lấy luôn mã ban đầu
                z.SoLuong = LaySoLuong(t);
                TheThao.RemoveAt(index);// xóa
                StreamWriter r = new StreamWriter(fileName);
                Console.Write("\t\t\t\t\tNhập Tên Giày Thể Thao : ");
                z.TenGiay = Console.ReadLine();
                do
                {
                    Console.Write("\t\t\t\t\tNhập Đơn Giá: ");
                    z.DonGia = double.Parse(Console.ReadLine());
                    if (z.DonGia <= 0)
                        Console.WriteLine("\t\t\t\t\tBạn nhập sai! Hãy nhập lại!");
                } while (z.DonGia <= 0);
                do
                {
                    Console.Write("\t\t\t\t\tNhập số lượng: ");
                    z.SoLuong = int.Parse(Console.ReadLine());
                    if (z.SoLuong <= 0)
                        Console.WriteLine("\t\t\t\t\tBạn nhập sai! Hãy nhập lại!");
                } while (z.SoLuong <= 0);
                TheThao.Insert(index, z);// chèn vào vị trí index
                foreach (GiayTheThao c in TheThao) // ghi lại vào tệp
                {
                    r.WriteLine(c.MaGiay + "_" + c.TenGiay + "_" + c.DonGia + "_" + c.SoLuong);
                }
                r.Close();
                DocTep();
                Console.Write("\n\t\t\t\t\tSửa thành công! (^_^)\n\t\t\t\t\tNhấn phím bất kì để quay lại!");
            }
        }
        #endregion
        #region Giảm Số Lượng 
        public void GiamSoLuong(string MaGiay, int soluong)
        {
            for (int i = 0; i < TheThao.Count; i++)
            {
                GiayTheThao t = TheThao[i];
                if (t.MaGiay == MaGiay)
                {
                    GiayTheThao thethao = new GiayTheThao();
                    thethao.MaGiay = t.MaGiay;
                    thethao.TenGiay = t.TenGiay;
                    thethao.DonGia = t.DonGia;
                    do
                    {
                        thethao.SoLuong = t.SoLuong - soluong;
                        if (thethao.SoLuong < 0)
                        {
                            thethao.SoLuong = t.SoLuong;
                            Console.WriteLine("Đồ uống này hiện hết hàng!");
                        }
                        //else uong.sl = u.sl - sl;
                    } while (thethao.SoLuong < 0);
                    //lấy vị trí item trong list
                    int index = TheThao.FindIndex(delegate (GiayTheThao tmp)
                    {
                        return tmp.MaGiay.Equals(MaGiay);
                    });
                    TheThao.RemoveAt(index);// xóa
                    TheThao.Insert(index, thethao);//chèn lại vào vị trí index
                }
            }
            StreamWriter r = new StreamWriter(fileName);
            foreach (GiayTheThao c in TheThao) // ghi lại vào tệp
            {
                r.WriteLine(c.MaGiay + "_" + c.TenGiay + "_" + c.DonGia + "_" + c.SoLuong);

            }
            r.Close();
            DocTep();
        }
        #endregion
        #region Lấy Mã Giày
        public string layMaGiay(string s)
        {
            string c = "";
            foreach (GiayTheThao a in TheThao)
            {
                if (s == a.MaGiay)
                    return c = a.MaGiay;
            }
            return c;
        }
        #endregion
        #region Lấy Số Lượng
        public int LaySoLuong(string s)
        {
            int c = 0;
            foreach (GiayTheThao a in TheThao)
            {
                if (s == a.MaGiay)
                    return c = a.SoLuong;
            }
            return c;
        }
        #endregion
        #region Tìm Kiếm Thông Tin Giày 
        public void timkiem()
        {
            DocTep();
            int kt = 0;
            Console.Write("\n\t\t\t\t\tNhập Thông Tin Giày THể Thao Muốn Tìm Kiếm: ");
            string s = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\t╔════════════════════╦═══════════════════════╦═══════════════╦");
            Console.WriteLine("\t\t\t\t\t║ MÃ GIÀY THỂ THAO   ║  TÊN GIÀY             ║    ĐƠN GIÁ    ║");
            Console.WriteLine("\t\t\t\t\t╠════════════════════╬═══════════════════════╬═══════════════╬");
            foreach (GiayTheThao t in TheThao)
            {
                if (s == t.MaGiay || s == t.TenGiay)
                {
                    kt++;
                    Console.WriteLine("\t\t\t\t\t║{0,-16}║{1,-28}║{2,-15}║{3,-10}║", t.MaGiay, t.TenGiay, t.DonGia);
                }
            }
            Console.WriteLine("\t\t\t\t\t╚════════════════════╩═══════════════════════╩═══════════════╝");
            if (kt == 0)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\tKhông Tìm Thấy Thông Tin Phù Hợp.");
            }
            Console.Write("\t\t\t\t\tBạn có muốn tìm tiếp không (c/k): ");
            string m = Console.ReadLine();
            if (m == "c" || m == "C")
                timkiem();
            else
            {
                Menu thethao = new Menu();
                thethao.MenuChinh();
            }
        }
        #endregion
        #region Tính Tiền
        public double TinhTien(string ma, int soluong)
        {
            DocTep();
            double tien = 0;
            foreach (GiayTheThao t in TheThao)
            {
                if (t.MaGiay == ma)
                {
                    if (t.SoLuong > soluong)
                    {
                        tien = soluong * t.DonGia;// tính tiền                               
                    }
                    else
                        Console.WriteLine("Số Lượng Yêu Cầu Quá Lớn! Giày Thể Thao Chỉ Còn Số Lượng Là: {0}", t.SoLuong);
                }
            }
            return tien;
        }
        #endregion
        #region Menu Giày Thể Thao
        public void menu()
        {
            bool stop = false;
            while (!stop)
            {
                Console.Clear();
                Console.Write("\n\n\t\t\t\t\t\t\t ╔══════════════════════════════════════════════════════════╗");
                Console.Write("\n\t\t\t\t\t\t\t ║                     QUẢN LÝ GIÀY THỂ THAO                ║");
                Console.Write("\n\t\t\t\t\t\t\t ╠══════════════════════════════════════════════════════════╣");
                Console.Write("\n\t\t\t\t\t\t\t ║                                                          ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╔═══╤══════════════════════════════╗           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 1 │ Hiển Thị Danh Sách Giày      ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 2 │ Thêm Giày Thể Thao           ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 3 │ Sửa Thông Tin Giày           ║           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ╟───┼──────────────────────────────╢           ║");
                Console.Write("\n\t\t\t\t\t\t\t ║           ║ 4 │ Xóa Giày Thể Thao            ║           ║");
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
                        HienThi();
                        Console.Write("\n\t\t\t\t\tẤn phím bất kì để quay lại!");
                        Console.ReadKey(); 
                        break;
                    case "2": 
                        Console.Clear(); Them(); Console.ReadKey();
                        break;
                    case "3": 
                        Console.Clear(); Sua(); Console.ReadKey(); 
                        break;
                    case "4": 
                        Console.Clear(); Xoa(); Console.ReadKey(); 
                        break;
                    case "5": 
                        Menu menu = new Menu(); menu.MenuChinh(); 
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
