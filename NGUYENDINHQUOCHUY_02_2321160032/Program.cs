using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGUYENDINHQUOCHUY_02_2321160032
{
    class Nhanvien
    {
        private string maso;
        private string hoten;
        private int luongcung;
        public Nhanvien()
        {
        }
        public Nhanvien(string maso,string hoten,int luongcung)
        {
            this.maso = maso;
            this.hoten = hoten;
            this.luongcung = luongcung;
        }
        public string Maso
        {
            set { this.maso = value; }
            get { return this.maso; }
        }
        public string MaSo
        {
            set { this.maso = value; }
            get { return this.maso; }
        }
        public string HoTen
        {
            set { this.hoten = value; }
            get { return this.hoten; }
        }

        public int Luongcung
        {
            set { this.luongcung = value; }
            get { return this.luongcung; }
        }
        public virtual void Nhap()
        {
            Console.Write("Nhap Ma So:");
            this.maso = Console.ReadLine();
            Console.Write("Nhap Ho Ten:");
            this.hoten = Console.ReadLine();
            Console.Write("Nhap Luong Cung:");
            this.luongcung = int.Parse(Console.ReadLine());
        }
        public virtual int TinhLuong()
        {
            return 0;
        }
    }
    class NhanVienBC : Nhanvien
    {
        private string mucxeploai;
        public NhanVienBC() : base()
        {
        }
        public NhanVienBC(string maso, string hoten, int luongcung, string mucxeploai) : base(maso, hoten, luongcung)
        {
            this.mucxeploai = mucxeploai;
        }
        public string Mucxeploai
        {
            set { this.mucxeploai = value; }
            get { return this.mucxeploai; }
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap Muc Xep Loai:");
            this.mucxeploai = Console.ReadLine();
        }
        public override int TinhLuong()
        {
            int Luong;
            if (Mucxeploai == "A")
                return Luong = (int)1.5 * Luongcung;
            if (Mucxeploai == "B")
                return Luong = (int)1.0 * Luongcung;
            else return Luong = (int)0.5 * Luongcung;
        }

    }
    class NhanvienHD : Nhanvien
    {
        private double doanhthu;
        public NhanvienHD() : base()
        {
        }
        public NhanvienHD(string maso, string hoten, int luongcung, int doanhthu) : base(maso, hoten, luongcung)
        {
            this.doanhthu = doanhthu;
        }
        public double DoanhThu
        {
            set { doanhthu = value; }
            get { return doanhthu; }
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap Doanh Thu:");
            this.doanhthu = int.Parse(Console.ReadLine());
        }
        public override int TinhLuong()
        {
            double luong = doanhthu * 0.1;
            return (int)luong;
        }
    }
    class QuanLyNV
    {
        private List<Nhanvien> dsNV;
        public QuanLyNV()
        {
            dsNV = new List<Nhanvien>();
        }
        //Nhap Danh Sach
        public void NhapDS()
        {
            string tieptuc = "y";
            int chon;
            Nhanvien NV;
            do
            {
                Console.Write("Chon loai Nhan Vien [1:Bien Che, 2:Hop Dong]:");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        NV = new NhanVienBC(); 
                        NV.Nhap();
                        dsNV.Add(NV);
                        break;
                    case 2:
                        NV = new NhanvienHD();
                        NV.Nhap();
                        dsNV.Add(NV);
                        break;
                    default:
                        Console.WriteLine("Vui long chon 1 hoac 2.");
                        break;
                }

                Console.Write("Ban co muon tiep tuc khong? Y/N:");
                tieptuc = Console.ReadLine();
            } while (tieptuc.ToLower() == "y");
        }
        // Xuat Danh Sach
        public void XuatDS()
        {
            Console.WriteLine($"{"Ma so",-10}  {"Ho Ten",20}  {"Luong Cung",10}  {"Luong",20}");
            foreach (Nhanvien x in dsNV)
            {
                Console.WriteLine($"{x.MaSo,-10}  {x.HoTen,20}  {x.Luongcung,10}  {x.TinhLuong(),20:#,##0 vnd}");
            }
        }
        // Tinh Tong Luong
        public int TinhTongLuong()
        {
            int sum = 0;
            foreach (Nhanvien nv in dsNV)
            {
                sum += nv.TinhLuong();
            }
            return sum;
        }
        // Tinh Luong Trung Binh
        public double TinhTrungBinh()
        {
            int dem = dsNV.Count();
            return TinhTongLuong() / dem;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            menu();
        }
        static void menu()
        {
            QuanLyNV ql = new QuanLyNV();
            int chon = 0;
            do
            {
                //in thuc don ra man hinh
                Console.WriteLine("***CHUONG TRINH QUAN LY NHAN VIEN***");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1.Nhap danh sach nhan vien.");
                Console.WriteLine("2.Xuat thong tin nhan vien.");
                Console.WriteLine("3.Thong ke tong luong phai tra cho giang vien.");
                Console.WriteLine("0.Thoat chuong trinh.");
                Console.WriteLine("--------------------------------");
                Console.Write("Ban chon chuc nang:");
                chon = int.Parse(Console.ReadLine());

                switch (chon)
                {
                    case 1:
                        ql.NhapDS();
                        break;

                    case 2:
                        ql.XuatDS();
                        break;
                    case 3:
                        Console.WriteLine($"Tong tien luong phai tra: {ql.TinhTongLuong():#,##0 vnd}");
                        break;
                    case 0:
                        Console.WriteLine("Chuong Trinh Da Ket Thuc, Tam Biet.");
                        Console.ReadLine();
                        break;
                }

            } while (chon != 0);
        }
    }
}
