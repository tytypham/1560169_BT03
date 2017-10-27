using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai02_event
{
    class HocSinh
    {
        public delegate void HangMucXepLoai();
        //khai bao sự kiên event
        public event HangMucXepLoai DatMucYeu;
        public event HangMucXepLoai DatMucTrungBinh;
        public event HangMucXepLoai DatMucKha;
        public event HangMucXepLoai DatMucGioi;
        static float MucTrungBinh = 5;
        static float MucKha = 7;
        static float MucGioi = 8;
        float _DTB = 0;

        public float DTB
        {
            get { return _DTB; }
            set
            {
                _DTB = value;
                if (_DTB < MucTrungBinh)
                {
                    if (DatMucYeu != null)
                    {
                        DatMucYeu();
                    }

                }
                else
                {
                    if (_DTB < MucKha)
                    {
                        if (DatMucTrungBinh != null)
                        {
                            DatMucTrungBinh();
                        }
                    }
                    else
                    {
                        if (_DTB < MucGioi)
                        {
                            if (DatMucKha != null)
                            {
                                DatMucKha();
                            }
                        }
                        else
                        {
                            if (DatMucGioi != null)
                            {
                                DatMucGioi();
                            }
                        }
                    }

                }
            }
        }
            public void ThemDiemTrungBinh(float SoDiem)
            {
                DTB += SoDiem;           
            }
        }

    
    class Program
    {
                    static void Main(string[] args)
            {
                Random rd = new Random();
                HocSinh  hs = new HocSinh();
                hs.DatMucYeu += new HocSinh.HangMucXepLoai(XepLoaiYeu);
                hs.DatMucTrungBinh += XepLoaiTrungBinh;
                hs.DatMucKha += XeploaiKha;
                hs.DatMucGioi += XepLoaiGioi;
                char c = 'a';
                while (c != 'q')
                {
                    Console.Write("nhap a de them diem: ");
                    if (Console.ReadKey().Key == ConsoleKey.A)
                    {
                        hs.ThemDiemTrungBinh(rd.Next(0, 10));
                    }
                    Console.WriteLine();
                    Console.Write("Tiep tuc:");
                    c = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                }
            }
            static void XepLoaiYeu()
            {
                Console.WriteLine();
                Console.WriteLine("Xep loai yeu ");
            }
            static void XepLoaiTrungBinh()
            {
                Console.WriteLine();
                Console.WriteLine("Xep loai hoc sinh trung binh ");
            }
            static void XeploaiKha()
            {
                Console.WriteLine();
                Console.WriteLine("Xep loai hoc sinh kha");
            }
            static void XepLoaiGioi()
            {
                Console.WriteLine();
                Console.WriteLine("Xep loai hoc sing gioi");
            }
        }
    }
    

