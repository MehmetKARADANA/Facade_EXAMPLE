internal class Program
{
    private static void Main(string[] args)
    {
        AkilliEvSistemi facade= AkilliEvSistemi.Instance(1,2,5,24);
        facade.tvAc();
        facade.tvKanalArtir();
        facade.tvSesArtir();
        facade.klimaGuncelle(30);
        facade.isikAc();
        facade.UykuModu(25);
      
    }
}

class AkilliEvSistemi //facade
{
    private Isik isik;
    private Televizyon televizyon;
    private Klima klima;
    private Kapi kapi;

    private static AkilliEvSistemi _AkilliEvSistemi;

    private AkilliEvSistemi(int isik1,int tkanal,int tses,int ksicaklik ){
        isik = new Isik(isik1);
        televizyon = new Televizyon(tkanal, tses);
        klima = new Klima(ksicaklik);
        kapi = new Kapi();
    }

    public static AkilliEvSistemi Instance(int isik1, int tkanal, int tses, int ksicaklik)
    {
            
                    if (_AkilliEvSistemi == null)
                    {
                        _AkilliEvSistemi = new AkilliEvSistemi(isik1,tkanal,tses,ksicaklik);
                    }
                
            
            return _AkilliEvSistemi;
        
    }


    public void isikAc() { isik.Ac(); }
    public void isikKapat() { isik.Kapat(); }
    public void tvAc() { televizyon.ac(); }
    public void tvKapat() { televizyon.kapat(); }
    public void tvSesAzalt() { televizyon.SesAzalt(); }
    public void tvSesArtir() { televizyon.SesArtir(); }
    public void tvKanalAzalt() { televizyon.KanalAzalt(); }
    public void tvKanalArtir() { televizyon.KanalArtir(); }
    public void klimaGuncelle(int a) { klima.guncelle(a); }
    public void klimaAc() { klima.ac(); }
    public void klimaKapat() { klima.kapa(); }    
    public void kapiKilitle() { kapi.kilitle(); }
    public void KapiAc() { kapi.kilitAc(); }


    public void UykuModu(int sicaklik) {
        Console.WriteLine("Uyku Moduna geçiliyor yapilan islemler:");
        klimaGuncelle(sicaklik);
        isikKapat();
        tvKapat();
        klimaAc();
        kapiKilitle();
    
    }

    public void SinemaModu(int sicaklik)
    {
        Console.WriteLine("sinema Moduna geçiliyor:");
        klimaGuncelle(sicaklik);
        isikKapat();
        tvAc();
        klimaAc();
        kapiKilitle();

    }
}

class Klima
{
    private int sicaklik;

    public Klima(int sicaklik)
    {
       Sicaklik = sicaklik;
    }

    public int Sicaklik { get => sicaklik; set => sicaklik = value; }


    public void guncelle(int a) {

        Sicaklik = a;
        Console.WriteLine("Sicaklik: "+Sicaklik);

    }

    public void ac()
    {
        Console.WriteLine("klima acildi");
    }

    public void kapa()
    {
        Console.WriteLine("klima kapandı");
    }



}

class Kapi
{
    public void kilitle (){

        Console.WriteLine("kapı kilitle");

    }

    public void kilitAc()
    {

        Console.WriteLine("kapı kilit ac");

    }
}

class Isik
{

    private bool durum;

    public Isik(int d)
    {

        if (d == 1)
        {
            Durum = true;
        }
        if (d==0) {
           Durum = false;

        }
    }

    public bool Durum { get => durum; set => durum = value; }

    public void Ac() {

        Durum = true;
        Console.WriteLine("Işik Acik");

    }

    public void Kapat()
    {
        durum = false;
        Console.WriteLine("Işık Kapali");
    }
}

class Televizyon
{
    private int sesSeviye;
    private int kanalNo;

    public Televizyon(int sesSeviye, int kanalNo)
    {
        SesSeviye = sesSeviye;
        KanalNo = kanalNo;
        
    }

    public int SesSeviye { get => sesSeviye; set => sesSeviye = value; }
    public int KanalNo { get => kanalNo; set => kanalNo = value; }

    public void SesArtir() {  SesSeviye++; Console.WriteLine("ses:"+SesSeviye); }
    public void SesAzalt() { SesSeviye--; Console.WriteLine("ses:" + SesSeviye); }

    public void ac() { Console.WriteLine("televizyon acik"); }
    public void kapat() { Console.WriteLine("televizyon kapali"); }

    public void KanalArtir() { KanalNo++; Console.WriteLine("ses:" + KanalNo); }
    public void KanalAzalt() { KanalNo--; Console.WriteLine("ses:" + KanalNo); }


}