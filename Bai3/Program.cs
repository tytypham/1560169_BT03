using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    class KhachHang
    {
        public delegate void HangMucHandler();
        public event HangMucHandler DatMucBinhDan;
        public event HangMucHandler DatMucTrungCap;
        public event HangMucHandler DatMucCaoCap;
        static long MucTrungCap = 10000000;
        static long MucCaoCap = 100000000;
        long _TaiKhoan = 0;
        public long TaiKhoan
        {
            get { return _TaiKhoan; }
            set
            {
                _TaiKhoan = value;
                if (_TaiKhoan < MucTrungCap)
                {
                    if (DatMucBinhDan != null)
                    {
                        DatMucBinhDan();
                    }

                }
                else
                {
                    if (_TaiKhoan < MucCaoCap)
                    {
                        if (DatMucTrungCap != null)
                        {
                            DatMucTrungCap();
                        }
                    }
                    else
                    {
                        if (DatMucCaoCap != null)
                        {
                            DatMucCaoCap();
                        }
                    }
                }
            }
        }
        public void ThuNhap(long SoTien)
        {
            TaiKhoan += SoTien;
        }


        class Program
        {
            static void Main(string[] args)
            {
                Random rd = new Random();
                KhachHang kh = new KhachHang();
                kh.DatMucBinhDan += new KhachHang.HangMucHandler(TTBinhDan);
                kh.DatMucTrungCap += TTTrungCap;
                kh.DatMucCaoCap += TTCaoCap;
                char c = 'a';
                while (c != 'q')
                {
                    Console.Write("nhap a de them thu nhap: ");
                    if (Console.ReadKey().Key == ConsoleKey.A)
                    {
                        kh.ThuNhap(rd.Next(1000000, 9000000));
                    }
                    Console.WriteLine();
                    Console.Write("Tiep tuc:");
                    c = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                }
            }
            static void TTBinhDan()
            {
                Console.WriteLine();
                Console.WriteLine("Tiep thi hang binh dan ");
            }
            static void TTTrungCap()
            {
                Console.WriteLine();
                Console.WriteLine("Tiep thi hang trung cap ");
            }
            static void TTCaoCap()
            {
                Console.WriteLine();
                Console.WriteLine("Tiep thi hang cao cap ");
            }
        }
    }
}
