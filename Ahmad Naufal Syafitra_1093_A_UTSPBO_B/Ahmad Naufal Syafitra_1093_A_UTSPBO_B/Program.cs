using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using UTS_PBO;

namespace UTS_PBO
{
    public abstract class PesananKopi
    {
        private string namaPelanggan { get; set; }
        private string nomorAntrian { get; set; }
        private string menuKopi { get; set; }

        public PesananKopi(string namaPelanggan, string nomorAntrian, string menuKopi)
        {
            this.namaPelanggan = namaPelanggan;
            this.nomorAntrian = nomorAntrian;
            this.menuKopi = menuKopi;
        }

        public void tampilInfo()
        {
            Console.WriteLine($"Nama: {namaPelanggan} | No: {nomorAntrian} | Menu: {menuKopi}");
        }
        public abstract double hitungTotalBayar(double jumlahCup);

    }

    class PesananDineIn : PesananKopi
    {
        public double hargaPerCup;

        public PesananDineIn(string namaPelanggan, string nomorAntrian, string menuKopi, double hargaPerCup) : base(namaPelanggan, nomorAntrian, menuKopi)
        {
            this.hargaPerCup = hargaPerCup;
        }
        public override double hitungTotalBayar(double jumlahCup)
        {
            return jumlahCup * hargaPerCup;
        }
        public void TampilkanTotal()
        {
            Console.WriteLine($"Total: Rp{hitungTotalBayar(2)}");
        }

    }

    class PesananTakeAway : PesananKopi
    {
        public double hargaPerCup;
        public double biayaKemasan;

        public PesananTakeAway(string namaPelanggan, string nomorAntrian, string menuKopi, double hargaPerCup, double biayaKemasan) : base(namaPelanggan, nomorAntrian, menuKopi)
        {
            this.hargaPerCup = hargaPerCup;
            this.biayaKemasan = biayaKemasan;
        }
        public override double hitungTotalBayar(double jumlahCup)
        {
            return (jumlahCup * hargaPerCup) + biayaKemasan;
        }
        public void TampilkanTotal()
        {
            Console.WriteLine($"Total: Rp{hitungTotalBayar(2)}");
        }
    }

    //class RiwayatTransaksi: PesananKopi
    //{

    //}

}

class Program
{
    static void Main(string[] args)
    {
        PesananTakeAway pesanan1 = new PesananTakeAway("Siti", "A01", "Latte", 25000, 3000);
        pesanan1.tampilInfo();
        pesanan1.hitungTotalBayar(2);
        pesanan1.TampilkanTotal();
    }
}
