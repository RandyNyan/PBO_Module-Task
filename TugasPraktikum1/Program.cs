class Program
{
    public static void Main()
    {
        Hewan hewan = new Hewan("Kucing", 3, "Meow");
        hewan.Info_Hewan();
        hewan.Suara();

        Mamalia mamalia = new Mamalia("Anjing", 5, 4, "Guk guk");
        mamalia.Info_Hewan();
        mamalia.Suara();
        
        Reptil reptilia = new Reptil("Kodomo", 5, 4.5f, "Auhh Auhh");
        reptilia.Info_Hewan();
        reptilia.Suara();

        Singa singa = new Singa("Leornado", 4, 4, "Aummm");
        Buaya buaya = new Buaya("Croco", 8, 3.5f, "Grrrr");
        Ular ular = new Ular("Snake", 2, 1.5f, "Sssttt");
        Gajah gajah = new Gajah("Elep", 10, 4, "Trumppppp");

        KebunBinatang Kebunnya = new KebunBinatang();
        Kebunnya.Nambah_Hewan(singa);
        Kebunnya.Nambah_Hewan(buaya);
        Kebunnya.Nambah_Hewan(ular);
        Kebunnya.Nambah_Hewan(gajah);

        Kebunnya.TampilkanHewan();
    }
}
public class KebunBinatang
{
    private List<Hewan> DaftarHewan;
    public KebunBinatang()
    {
        DaftarHewan = new List<Hewan>();
    }
    public void Nambah_Hewan(Hewan hewan)
    {
        DaftarHewan.Add(hewan);
        Console.WriteLine($"{hewan.Nama} telah ditambahkan ke kebun binatang.");
    }
    public void TampilkanHewan()
    {
        Console.WriteLine("Daftar hewan di kebun binatang:");
        foreach (var hewan in DaftarHewan)
        {
            hewan.Info_Hewan();
            hewan.Suara();
        }
    }
}
public class Hewan
{
    public string Nama;
    public int Umur;
    public string Bersuara;

    public Hewan(string nama, int umur, string bersuara)
    {
        Nama = nama;
        Umur = umur;
        Bersuara = bersuara;
        Console.WriteLine($"Hewan dengan Nama {Nama} yang berumur {Umur} tahun bersuara {Bersuara}");
    }

    public virtual void Suara()
    {
        Console.WriteLine($"Hewan dengan Nama {Nama} bersuara {Bersuara}");
    }
    public virtual void Info_Hewan()
    {
        Console.WriteLine($"Hewan dengan Nama {Nama} berumur {Umur} tahun");
    }       
}

public class Mamalia : Hewan
{
    public int JumlahKaki;

    public Mamalia(string nama, int umur, int jumlahkaki, string bersuara) : base(nama, umur, bersuara)
    {
        JumlahKaki = jumlahkaki;
        Console.WriteLine($" Hewan Mamalia {Nama} berumur {Umur} tahun berkaki {JumlahKaki} bersuara {Bersuara}");
    }
    public override void Suara()
    {
        Console.WriteLine($"Hewan Mamalia {Nama} bersuara {Bersuara}");
    }
    public override void Info_Hewan()
    {
        Console.WriteLine($"Hewan Mamalia {Nama} berumur {Umur} tahun memiliki {JumlahKaki} kaki");
    }
}

public class Reptil : Hewan
{
    public float PanjangTubuh;

    public Reptil(string nama, int umur, float panjangtubuh, string bersuara) : base(nama, umur, bersuara)
    {
        PanjangTubuh = panjangtubuh;
        Console.WriteLine($" Hewan Mamalia {Nama} berumur {Umur} tahun sepanjang {PanjangTubuh} bersuara {Bersuara}");
    }
    public override void Suara()
    {
        Console.WriteLine($"Hewan Reptil {Nama} bersuara {Bersuara}");
    }
    public override void Info_Hewan()
    {
        Console.WriteLine($"Hewan Reptil {Nama} berumur {Umur} tahun memiliki panjang {PanjangTubuh} meter");
    }
}
public class Singa : Mamalia
{
    public Singa(string nama, int umur, int jumlahkaki, string bersuara) : base(nama, umur, jumlahkaki,bersuara)
    {
        Console.WriteLine($" Hewan Singa bernama {Nama} berumur {Umur} tahun bersuara {Bersuara}");
    }
    public override void Suara()
    {
        Console.WriteLine($"Hewan Singa bernama {Nama} bersuara {Bersuara}");
    }
    public override void Info_Hewan()
    {
        Console.WriteLine($"Hewan Singa bernama {Nama} berumur {Umur} tahun memiliki {JumlahKaki} kaki");
    }
    public void Mengaum()
    {
        Console.WriteLine($"Hewan Singa bernama {Nama} sedang mengaum");
    }
}
public class Gajah : Mamalia
{
    public Gajah(string nama, int umur, int jumlahkaki, string bersuara) : base(nama, umur, jumlahkaki, bersuara)
    {
        Console.WriteLine($" Hewan Gajah bernama {Nama} berumur {Umur} tahun bersuara {Bersuara}");
    }
    public override void Suara()
    {
        Console.WriteLine($"Hewan Gajah bernama {Nama} bersuara {Bersuara}");
    }
    public override void Info_Hewan()
    {
        Console.WriteLine($"Hewan Gajah bernama {Nama} berumur {Umur} tahun memiliki {JumlahKaki} kaki");
    }
}
public class Ular : Reptil
{
    public Ular(string nama, int umur, float panjangtubuh, string bersuara) : base(nama, umur, panjangtubuh, bersuara)
    {
        Console.WriteLine($" Hewan Ular bernama {Nama} berumur {Umur} tahun bersuara {Bersuara}");
    }
    public override void Suara()
    {
        Console.WriteLine($"Hewan Ular bernama {Nama} bersuara {Bersuara}");
    }
    public override void Info_Hewan()
    {
        Console.WriteLine($"Hewan Ular bernama {Nama} berumur {Umur} tahun memiliki panjang {PanjangTubuh} meter");
    }
    public void merayap()
    {
        Console.WriteLine($"Hewan Ular bernama {Nama} sedang merayap");
    }
}
public class Buaya : Reptil
{
    public Buaya(string nama, int umur, float panjangtubuh, string bersuara) : base(nama, umur, panjangtubuh, bersuara)
    {
        Console.WriteLine($" Hewan Buaya bernama {Nama} berumur {Umur} tahun bersuara {Bersuara}");
    }
    public override void Suara()
    {
        Console.WriteLine($"Hewan Buaya bernama {Nama} bersuara {Bersuara}");
    }
    public override void Info_Hewan()
    {
        Console.WriteLine($"Hewan Buaya bernama {Nama} berumur {Umur} tahun memiliki panjang {PanjangTubuh} meter");
    }
}