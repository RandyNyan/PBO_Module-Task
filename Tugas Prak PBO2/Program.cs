class Program
{
    public static void Main()
    {
        Robot Optimus = new Robot("Optimus", 200, 150, 50);
        Robot Bumblebee = new Robot("Bumblebee", 200, 120, 65);
        BosRobot mutanrobot = new BosRobot("BosRobotX", 400, 400);

        Optimus.cetakInformasi();
        Bumblebee.cetakInformasi();

        Optimus.serang(Bumblebee);
        Bumblebee.cetakInformasi();

        Kemampuan perbaikan = new Kemampuan("Repair", 20);
        Optimus.gunakanKemampuan(perbaikan);
        Optimus.cetakInformasi();

        mutanrobot.diserang(Optimus);
        mutanrobot.cetakInformasi();

        Optimus.serang(mutanrobot);
        mutanrobot.cetakInformasi();
    }
}

public abstract class RobotBase
{
    public string nama;
    public int energi;
    public int serangan;

    public RobotBase(string robotNama, int robotEnergi, int robotSerangan)
    {
        nama = robotNama;
        energi = robotEnergi;
        serangan = robotSerangan;
    }

    public abstract void cetakInformasi();
}

public interface IKemampuan
{
    void gunakanKemampuan(Kemampuan kemampuan);
}

public class Robot : RobotBase, IKemampuan
{
    public int armor;

    public Robot(string robotNama, int robotEnergi, int robotArmor, int robotSerangan)
        : base(robotNama, robotEnergi, robotSerangan)
    {
        armor = robotArmor;
    }

    public void serang(object target)
    {
        if (energi <= 0)
        {
            Console.WriteLine($"{nama} tidak memiliki energi untuk menyerang!");
            return;
        }

        if (target is Robot robotTarget)
        {
            int damageToArmor = Math.Min(robotTarget.armor, serangan);
            robotTarget.armor -= damageToArmor;
            int damageToEnergi = Math.Max(0, serangan - damageToArmor);
            robotTarget.energi -= damageToEnergi;

            energi -= 10;
            Console.WriteLine($"{nama} menyerang {robotTarget.nama}. Armor {robotTarget.nama} sekarang {robotTarget.armor}, Energi {robotTarget.nama} sekarang {robotTarget.energi}. Energi {nama} sekarang {energi}");
        }
        else if (target is BosRobot bosTarget)
        {
            int damageToDefense = Math.Min(bosTarget.pertahanan, serangan);
            bosTarget.pertahanan -= damageToDefense;
            int damageToEnergi = Math.Max(0, serangan - damageToDefense);
            bosTarget.energi -= damageToEnergi;

            energi -= 10;
            Console.WriteLine($"{nama} menyerang {bosTarget.nama}. Pertahanan {bosTarget.nama} sekarang {bosTarget.pertahanan}, Energi {bosTarget.nama} sekarang {bosTarget.energi}. Energi {nama} sekarang {energi}");
        }
    }

    public void gunakanKemampuan(Kemampuan kemampuan)
    {
        if (kemampuan.nama == "Repair")
        {
            energi += kemampuan.efek;
            Console.WriteLine($"{nama} menggunakan kemampuan {kemampuan.nama}, energi sekarang {energi}");
        }
    }

    public override void cetakInformasi()
    {
        Console.WriteLine($"Robot: {nama}, Energi: {energi}, Armor: {armor}, Serangan: {serangan}");
    }
}

public class BosRobot : RobotBase
{
    public int pertahanan;

    public BosRobot(string bosNama, int bosEnergi, int bosPertahanan)
        : base(bosNama, bosEnergi, 0)
    {
        pertahanan = bosPertahanan;
    }

    public void diserang(Robot penyerang)
    {
        int damageToDefense = Math.Min(pertahanan, penyerang.serangan);
        pertahanan -= damageToDefense;
        int damageToEnergi = Math.Max(0, penyerang.serangan - damageToDefense);
        energi -= damageToEnergi;

        Console.WriteLine($"{nama} diserang oleh {penyerang.nama}. Pertahanan {nama} sekarang {pertahanan}, Energi {nama} sekarang {energi}");

        if (energi <= 0)
        {
            mati();
        }
    }

    public void mati()
    {
        Console.WriteLine($"{nama} telah mati!");
    }

    public override void cetakInformasi()
    {
        Console.WriteLine($"Bos Robot: {nama}, Energi: {energi}, Pertahanan: {pertahanan}");
    }
}

public class Kemampuan
{
    public string nama;
    public int efek;

    public Kemampuan(string kemampuanNama, int kemampuanEfek)
    {
        nama = kemampuanNama;
        efek = kemampuanEfek;
    }
}
