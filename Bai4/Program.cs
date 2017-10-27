using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4
{
    class SinhVien
    {
        int _MSSV;

public int MSSV
{
  get { return _MSSV; }
  set { _MSSV = value; }
}
        string _HoTen, _quequan;

public string Quequan
{
  get { return _quequan; }
  set { _quequan = value; }
}

public string HoTen
{
  get { return _HoTen; }
  set { _HoTen = value; }
}

public override string ToString()
{
    return string.Format("<{0}> -<{1}>-[{2}]",_MSSV,_HoTen,_quequan);
}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            int n = rd.Next(5, 10);
            SinhVien[] DSSV = new SinhVien[n];
            for(int i = 0; i < n;i++)
            {
                DSSV[i] = new SinhVien()
                {
                    MSSV = 1560169 + rd .Next(999),
                    HoTen = string.Format("{0}HT",(char)rd.Next(0x41,0x5A)),
                     Quequan = string.Format("{0}QQ",(char)rd.Next(0x61,0x7A))
                };

            }
            char c = 'a';
            while (c !='q')
            {
                Console.Write("sap xep theo 2 tieu chi (1,2,3): ");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1': 
                        {
                            Array.Sort(DSSV, delegate(SinhVien sv1,SinhVien sv2)
                                {
                                    return sv1.MSSV.CompareTo(sv2.MSSV);
                                });
                            break;
                        }
                    case '2':
                            {
                                Array.Sort(DSSV,delegate(SinhVien sv1,SinhVien sv2)
                                {
                                    return sv1.HoTen.CompareTo(sv2.HoTen);
                                });
                                break;
                            }
                    case '3':
                            {
                                Array.Sort(DSSV, delegate(SinhVien sv1, SinhVien sv2)
                                {
                                    return sv1.Quequan.CompareTo(sv2.Quequan);
                                });
                                break;
                            }
                            Console.WriteLine();
                        foreach(var sv in DSSV)
                        {
                            Console.WriteLine(sv);

                        }
                        Console.Write("tiep tuc");
                        c = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                }
            }
        }
    }
}
